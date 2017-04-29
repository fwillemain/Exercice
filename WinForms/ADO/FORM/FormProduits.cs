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
    public partial class FormProduits : Form
    {
        #region Champs privés
        private BindingList<Produit> _lstProduits;
        private List<Produit> _lstProduitsAjoutés;
        private List<Produit> _lstProduitsSupprimés;
        #endregion

        public FormProduits()
        {
            InitializeComponent();

            btnAjoutPdt.Click += BtnAjoutPdt_Click;
            btnSupPdt.Click += BtnSupPdt_Click;
            btnEnregistrer.Click += BtnEnregistrer_Click;
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            EnleverProduitANePasInsérer();

            try
            {
                DAL.AjouterProduitBDD(_lstProduitsAjoutés);
                _lstProduitsAjoutés.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Impossible d'ajouter le produit!", "Message d'erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                DAL.SupprimerProduitBDD(_lstProduitsSupprimés.Select(i => i.Id));
                _lstProduitsSupprimés.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Impossible de supprimer le produit!", "Message d'erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void EnleverProduitANePasInsérer()
        {
            List<int> listeIndexASuppr = new List<int>();
            foreach (var p in _lstProduitsAjoutés)
            {
                if (_lstProduitsSupprimés.Contains(p))
                {
                    listeIndexASuppr.Add(_lstProduitsSupprimés.IndexOf(p));
                    _lstProduitsSupprimés.Remove(p);
                }
            }

            foreach (var i in listeIndexASuppr)
                _lstProduitsAjoutés.RemoveAt(i);
        }

        private void BtnSupPdt_Click(object sender, EventArgs e)
        {
            Produit prod = (Produit)dgvProduits.CurrentRow.DataBoundItem;

            _lstProduitsSupprimés.Add(prod);
            _lstProduits.Remove(prod);
        }

        private void BtnAjoutPdt_Click(object sender, EventArgs e)
        {
            using (var form = new FormAjouterProduit())
            {
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _lstProduitsAjoutés.Add(form.ProduitSaisi);
                    _lstProduits.Add(form.ProduitSaisi);
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            _lstProduits = DAL.RécupérerProduits();
            dgvProduits.DataSource = _lstProduits;

            _lstProduitsAjoutés = new List<Produit>();
            _lstProduitsSupprimés = new List<Produit>();

            // Pour ne pas afficher la colonne ID
            dgvProduits.Columns["Id"].Visible = false;
            base.OnLoad(e);
        }
    }
}
