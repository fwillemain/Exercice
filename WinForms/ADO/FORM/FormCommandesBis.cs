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
    public partial class FormCommandesBis : Form
    {
        private List<Commande> _lstCommandes;

        public FormCommandesBis()
        {
            InitializeComponent();
            dgvCommandes.SelectionChanged += DgvCommandes_SelectionChanged;
            btnRechercheOK.Click += BtnRechercheOK_Click;
            btnImportXML.Click += BtnImportXML_Click;
            btnExportXML.Click += BtnExportXML_Click;
        }

        private void BtnExportXML_Click(object sender, EventArgs e)
        {
            DAL.ExporterXml(_lstCommandes);
        }

        private void BtnImportXML_Click(object sender, EventArgs e)
        {
            _lstCommandes = DAL.ImporterXml();
        }

        private void BtnRechercheOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mtbRecherche.Text))
            {
                int id = int.Parse(mtbRecherche.Text);
                dgvCommandes.DataSource = _lstCommandes.Where(c => c.IdCommande == id).ToList();
                dgvDetailsCommande.DataSource = _lstCommandes.Where(c => c.IdCommande == id).Select(c => c.LstLignesCommandes).FirstOrDefault();
            }
            else
            {
                dgvCommandes.DataSource = _lstCommandes;
                dgvDetailsCommande.ClearSelection();
                dgvDetailsCommande.DataSource = null;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            _lstCommandes = DAL.RécupérerCommandes();
            dgvCommandes.DataSource = _lstCommandes; //.Select(c => new { c.IdCommande, c.IdClient, c.Date }) ;

            #region Paramétrage dgvCommandes
            dgvCommandes.Columns["Id"].Visible = false;
            dgvCommandes.Columns["DateEnvoi"].Visible = false;
            dgvCommandes.Columns["NbArticles"].Visible = false;
            dgvCommandes.Columns["MontantTot"].Visible = false;
            dgvCommandes.Columns["FraisEnvoi"].Visible = false;
            dgvCommandes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCommandes.ReadOnly = true;
            dgvCommandes.MultiSelect = false;
            #endregion

            dgvDetailsCommande.MultiSelect = false;
            dgvDetailsCommande.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetailsCommande.ReadOnly = true;

            base.OnLoad(e);
        }
        private void DgvCommandes_SelectionChanged(object sender, EventArgs e)
        {
            if (!dgvCommandes.Focused) return;

            int idSelected = (int)dgvCommandes.SelectedRows[0].Cells["IdCommande"].Value;
            var lst = _lstCommandes.Where(c => c.IdCommande == idSelected).Select(c => c.LstLignesCommandes).First();
            dgvDetailsCommande.DataSource = lst;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
