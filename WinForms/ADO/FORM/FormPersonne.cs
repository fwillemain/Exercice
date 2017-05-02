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
    public partial class FormPersonne : Form
    {
        public FormPersonne()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            cbPersonne.DataSource = DAL.RécupérerEmployés();
            cbPersonne.ValueMember = "Id";
            cbPersonne.DisplayMember = "NomComplet";

            // TODO : Stocker toutes les infos en privé
            dgvPersonne.DataSource = DAL.RécupérerRégionsTerritoires();
            dgvPersonne.Columns["IdRegion"].Visible = false;
            dgvPersonne.Columns["IdTerritoire"].Visible = false;
            dgvPersonne.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "Présent",
                FalseValue = 0,
                TrueValue = 1,
                Visible = true
            });
            // dgvPersonne.Columns["Checked Column"].HeaderCell = new DataGridViewCheckBoxColumn()

            base.OnLoad(e);
        }
    }
}
