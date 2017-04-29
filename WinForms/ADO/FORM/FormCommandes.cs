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
    public partial class FormCommandes : Form
    {
        public FormCommandes()
        {
            InitializeComponent();
            lbClients.DoubleClick += (object o, EventArgs e) =>
               dgvCommandes.DataSource = DAL.RécupérerCommandeClient(lbClients.SelectedValue.ToString());
        }

        protected override void OnLoad(EventArgs e)
        {
            lbClients.DataSource = DAL.RécupérerClients();
            lbClients.DisplayMember = "NomEntreprise";
            lbClients.ValueMember = "Id";

            base.OnLoad(e);
        }
    }
}
