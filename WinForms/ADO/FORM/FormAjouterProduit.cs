using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO
{
    public partial class FormAjouterProduit : Form
    {
        #region Propriétés
        public Produit ProduitSaisi { get; private set; }
        #endregion

        #region Méthodes privées
        private Produit CréerProduitSaisi()
        {
            Produit p = new Produit();
            int tmpI;
            decimal tmpD;

            p.Nom = string.IsNullOrEmpty(tbNom.Text) ? "(default)" : tbNom.Text;
            p.IdCatégorie = (int)cbCatégorie.SelectedValue;
            p.QuantitéParUnité = mtbQtéUnitaire.Text;

            if (decimal.TryParse(mtbPrixUnitaire.Text, out tmpD))
                p.PrixUnitaire = tmpD;

            if (int.TryParse(mtbUnitésStock.Text, out tmpI))
                p.QuantitéStock = tmpI;

            p.IdFournisseur = (int)cbFournisseur.SelectedValue;

            return p;
        }
        #endregion

        public FormAjouterProduit()
        {
            InitializeComponent();

            ControlBox = false;
            AcceptButton = btnOK;
            CancelButton = btnAnnuler;

            btnOK.DialogResult = DialogResult.OK;
            btnAnnuler.DialogResult = DialogResult.Cancel;
        }

        protected override void OnLoad(EventArgs e)
        {
            cbCatégorie.DataSource = DAL.RécupérerCatégories();
            cbCatégorie.ValueMember = "Id";
            cbCatégorie.DisplayMember = "Nom";

            cbFournisseur.DataSource = DAL.RécupérerFournisseurs();
            cbFournisseur.ValueMember = "Id";
            cbFournisseur.DisplayMember = "NomEntreprise";

            base.OnLoad(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                ProduitSaisi = CréerProduitSaisi();

            base.OnClosing(e);
        }

    }
}
