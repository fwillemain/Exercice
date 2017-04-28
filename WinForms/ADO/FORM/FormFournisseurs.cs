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
    public partial class FormFournisseurs : Form
    {
        public FormFournisseurs()
        {
            InitializeComponent();
            clPaysFournisseurs.SelectedValueChanged += (object o, EventArgs e) =>
            {
                dgvFournisseurs.DataSource = DAL.RécupérerFournisseurs(clPaysFournisseurs.SelectedValue.ToString());
                lblNbProdPays.Text = DAL.RécupérerNbProduitsPaysFournisseur(clPaysFournisseurs.SelectedValue.ToString()).ToString();
            };
            dgvFournisseurs.SelectionChanged += (object o, EventArgs e) =>
                dgvProduits.DataSource = DAL.RécupérerProduitsFournisseur(((Fournisseur)dgvFournisseurs.CurrentRow.DataBoundItem).Id);

        }

        protected override void OnLoad(EventArgs e)
        {
            clPaysFournisseurs.DataSource = DAL.RécupérerPaysFournisseurs();

            base.OnLoad(e);
        }
    }
}
