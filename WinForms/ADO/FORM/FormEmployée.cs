using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO
{
    public partial class FormEmployée : Form
    {
        // Liste de toutes les régions et leur territoire
        private BindingList<TerritoireRégion> _blstTerritoiresRégions;

        // Liste des employés et leurs territoires associés
        private List<TerritoireEmployé> _lstTerritoiresEmployés;

        // Liste des territoires à associer et/ou desassocier pour un employé
        private List<TerritoireEmployé> _lstTerritoiresEmployésAModifier;

        public FormEmployée()
        {
            InitializeComponent();

            // Event que quand la sélection dans la cb est confirmée
            // Permet d'éviter son activation lors du loading des données dans la cb
            cbEmployée.SelectionChangeCommitted += CbEmployée_SelectionChangeCommitted;
            dgvRegTerr.Click += DgvRegTerr_Click;
            btnEnregistrer.Click += BtnEnregistrer_Click;
            btnAnnuler.Click += BtnAnnuler_Click;

            // TODO : gérer le clic sur la Cell en haut à gauche ou la desactiver
            // Nécessaire de dériver la classe DataGridView et override OnCellClickMouse()
        }

        protected override void OnLoad(EventArgs e)
        {
            // Chargement des listes avec les infos de la BDD
            _blstTerritoiresRégions = DAL.RécupérerTerritoiresRégions();
            _lstTerritoiresEmployés = DAL.RécupérerTerritoiresEmployés();

            // Inialisation de la liste
            _lstTerritoiresEmployésAModifier = new List<TerritoireEmployé>();

            // Binding de la liste à la dgv
            dgvRegTerr.DataSource = _blstTerritoiresRégions;
            #region Paramétrage dgvRegTerr
            // Masque les colonnes inutiles pour l'utilisateur
            dgvRegTerr.Columns["IdRégion"].Visible = false;
            dgvRegTerr.Columns["CodeTerritoire"].Visible = false;
            dgvRegTerr.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvRegTerr.ReadOnly = true;
            dgvRegTerr.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            #endregion

            // Création d'une colonne checkbox pour la dgv
            var cbCol = new DataGridViewCheckBoxColumn();
            #region Paramétrage cbCol
            cbCol.HeaderText = "";
            cbCol.Width = 30;
            cbCol.Name = "checkBoxColumn";
            // Inialise les valeurs "True" et "False" à true et false (possible de mettre n'importe quoi) pour les checkbox de la colonne
            cbCol.TrueValue = true;
            cbCol.FalseValue = false;
            #endregion
            dgvRegTerr.Columns.Insert(0, cbCol);

            // Création du header checkbox pour la colonne checkbox en index 0
            ShowChkBox();

            // Chargement des employés de la cb 
            cbEmployée.DataSource = DAL.RécupérerEmployées();
            #region Paramétrage cbEmployée
            // Colonne utilisée pour la valeur retournée à la sélection d'un employé
            cbEmployée.ValueMember = "Id";
            // Colonne utilisée pour l'affichage d'un employé dans la cb
            cbEmployée.DisplayMember = "NomComplet";
            // Désactive la possibilité de saisir du texte dans la cb
            cbEmployée.DropDownStyle = ComboBoxStyle.DropDownList;
            // Aucun employé séléctionné au chargement de la cb
            cbEmployée.SelectedItem = null;
            #endregion

            base.OnLoad(e);
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            // Appelle le gestionnaire d'event de la cb sans changer l'employé donc reset de toutes les variables utiles pour la dgv
            CbEmployée_SelectionChangeCommitted(cbEmployée, null);
        }

        private void DgvRegTerr_Click(object sender, EventArgs e)
        {
            // Désactive le clic sur la dgv tant qu'un employé n'a pas été sélectionné
            if (cbEmployée.SelectedValue == null)
                return;

            // Pour toutes les lignes sélectionnées dans la dgv (sélection multiples possible)
            foreach (DataGridViewRow row in dgvRegTerr.SelectedRows)
            {
                // Cliquer sur une ligne check automatiquement la checkbox associée
                // Indispensable car la dgv est en ReadOnly (voir paramètres dgv)
                row.Cells["checkBoxColumn"].Value = row.Cells["checkBoxColumn"].Value ?? false;
                row.Cells["checkBoxColumn"].Value = !((bool)row.Cells["checkBoxColumn"].Value);

                var te = new TerritoireEmployé()
                {
                    IdEmployé = (int)cbEmployée.SelectedValue,
                    CodeTerritoire = row.Cells["CodeTerritoire"].Value.ToString()
                };

                // si déjà présent dans la liste, la modification est annulée et l'objet retiré de la liste 
                // sinon il est rajouté à la liste
                if (_lstTerritoiresEmployésAModifier.Contains(te))
                    _lstTerritoiresEmployésAModifier.Remove(te);
                else
                    _lstTerritoiresEmployésAModifier.Add(te);
            }
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                // Maj la BDD
                DAL.MajTerritoireEmployéBDD(_lstTerritoiresEmployésAModifier);

                // Raz la liste des modifs à effectuer
                _lstTerritoiresEmployésAModifier.Clear();

                // Maj de la liste avec le contenu de la BDD
                _lstTerritoiresEmployés = DAL.RécupérerTerritoiresEmployés();

                // Desélectionne toutes les lignes de la dgv
                dgvRegTerr.ClearSelection();

                MessageBox.Show("Enregistrement réussi", "Information");
            }
            catch (SqlException)
            {
                MessageBox.Show("Echec de l'enregistrement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Gestion plus poussée des erreurs possibles
            }
        }

        private void CbEmployée_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Maj de l'affichage de la dgv en fonction de l'employé sélectionné
            MajListeTR(((Employée)cbEmployée.SelectedItem).Id);

            // Réinitialise la liste des employés/territoires à modifier
            _lstTerritoiresEmployésAModifier.Clear();

            // Décoche la checkbox en header si elle l'était
            ((CheckBox)dgvRegTerr.Controls["checkboxHeader"]).Checked = false;

            // Desélectionne toutes les lignes de la dgv qui pouvait l'être
            dgvRegTerr.ClearSelection();
        }

        /// <summary>
        /// Met à jour _blstTerritoiresRégions pour l'employé dont l'Id est passé en paramètre
        /// </summary>
        /// <param name="selectedValue"></param>
        private void MajListeTR(int IdEmployé)
        {
            // Liste des codes territoire auquel l'employé IdEmployé est associé
            var lstTer = _lstTerritoiresEmployés.Where(te => te.IdEmployé == IdEmployé).Select(t => t.CodeTerritoire).ToList();

            // Check la box pour chaque ligne de la dgv présent dans la liste précédente
            foreach (DataGridViewRow row in dgvRegTerr.Rows)
                row.Cells["checkBoxColumn"].Value = lstTer.Contains(row.Cells["CodeTerritoire"].Value.ToString());
        }

        /// <summary>
        /// Création d'un header checkbox pour la dgv
        /// </summary>
        private void ShowChkBox()
        {
            // Rectangle identique au header dans lequel la checkbox sera (taille et position)
            Rectangle rect = dgvRegTerr.GetCellDisplayRectangle(0, -1, true);
            rect.Y = 3;

            // Se place au centre du header
            rect.X = rect.Location.X + (rect.Width / 6);

            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.Name = "checkboxHeader";
            checkboxHeader.Size = new Size(18, 18);
            
            // Place la checkbox à la place du rectangle
            checkboxHeader.Location = rect.Location;

            // Abonnement à l'event check sur la checkboxHeader
            checkboxHeader.CheckedChanged += CheckboxHeader_CheckedChanged;

            // Intégration de la checkboxHeader à la dgv
            dgvRegTerr.Controls.Add(checkboxHeader);
        }

        /// <summary>
        /// Gestion de l'event check du header checkbox (check ou uncheck toute la colonne checkbox) 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            // Si un employé n'est pas sélectionné, bloquer l'action du checkboxHeader (et le laisser à false/unchecked)
            if (cbEmployée.SelectedValue == null)
            {
                ((CheckBox)dgvRegTerr.Controls["checkboxHeader"]).Checked = false;
                return;
            }

            // Récupère l'état du checkboxHeader (checked/unchecked)
            bool isHeaderChecked = ((CheckBox)dgvRegTerr.Controls["checkboxHeader"]).Checked;

            // Interrompt toute éventuelle écriture dans la dgv (qui empêcherait la maj des lignes concernées car bloquant)
            dgvRegTerr.EndEdit();

            // Desélectionne toutes les lignes de la dgv
            dgvRegTerr.ClearSelection();

            // Sélectionne les lignes à modifier
            foreach (DataGridViewRow row in dgvRegTerr.Rows)
                row.Selected = (bool)row.Cells["checkBoxColumn"].Value != isHeaderChecked;

            // Appel le gestionnaire d'event clic de la dgvp pour mettre à jour la liste _lstTerritoiresEmployésAModifier et le dgv
            // en fonction des lignes sélectionnées
            DgvRegTerr_Click(dgvRegTerr, null);
        }
    }
}








