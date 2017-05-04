using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectionsBD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            btnAfficher.Click += BtnAfficher_Click;

        }

        private void BtnAfficher_Click(object sender, EventArgs e)
        {
            DAL.AjouterAuteur("Pascal Dabère", "Lucky Luke");
            DAL.AjouterAlbum("Le pont sur le Mississippi", "Morris", 1994, "Lucky Luke");
            DAL.MettreTitreMajuscule(15, "Astérix");

            lbTitreAlbum.DataSource = DAL.RécupérerTitreAlbum(1960, 1969);
        }
    }
}
