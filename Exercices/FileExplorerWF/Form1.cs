using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileExplorer;
using System.IO;

namespace FileExplorerWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            cbListeFichierCsproj.CheckedChanged += CbListeFichierCsproj_CheckedChanged;
            cbNbFichierCs.CheckedChanged += CbNbFichierCs_CheckedChanged;
            cbNbFichiers.CheckedChanged += CbNbFichiers_CheckedChanged;
            cbNomFichierLePlusLong.CheckedChanged += CbNomFichierLePlusLong_CheckedChanged;

            btBrowse.Click += BtBrowse_Click;
            btAnalyser.Click += BtAnalyser_Click;

            this.Load += Form1_Load;
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbListeFichierCsproj.Checked= Properties.Settings.Default.SaveCheckedListeFichiersCsproj;
            cbNbFichiers.Checked= Properties.Settings.Default.SaveCheckedNbFichier;
            cbNbFichierCs.Checked = Properties.Settings.Default.SaveCheckedNbFichierCs;
            cbNomFichierLePlusLong.Checked= Properties.Settings.Default.SaveCheckedNomFichierLePlusLong;
            tbDossierSelectionne.Text = Properties.Settings.Default.SaveDossierSelectionne;
            tbNbFichiers.Text = Properties.Settings.Default.SaveNbFichier;
            tbNbFichierCs.Text = Properties.Settings.Default.SaveNbFichierCs;
            tbValNomFichierLePlusLong.Text = Properties.Settings.Default.SaveNomFichierLePlusLong;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("Souhaitez-vous sauvegarder les modifications?", "Sauvegarder?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Properties.Settings.Default.SaveCheckedListeFichiersCsproj = cbListeFichierCsproj.Checked;
                Properties.Settings.Default.SaveCheckedNbFichier = cbNbFichiers.Checked;
                Properties.Settings.Default.SaveCheckedNbFichierCs = cbNbFichierCs.Checked;
                Properties.Settings.Default.SaveCheckedNomFichierLePlusLong = cbNomFichierLePlusLong.Checked;
                Properties.Settings.Default.SaveDossierSelectionne = tbDossierSelectionne.Text;
                Properties.Settings.Default.SaveNbFichier = tbNbFichiers.Text;
                Properties.Settings.Default.SaveNbFichierCs = tbNbFichierCs.Text;
                Properties.Settings.Default.SaveNomFichierLePlusLong = tbValNomFichierLePlusLong.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void BtAnalyser_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(tbDossierSelectionne.Text))
            {
                Analyseur analyseur = new Analyseur();
                analyseur.AnalyserDossier(tbDossierSelectionne.Text);

                tbValNbFichiers.Text = analyseur.CompteurFichiers.ToString();
                tbValNbFichierCs.Text = analyseur.CompteurFichiersCs.ToString();
                tbValNomFichierLePlusLong.Text = analyseur.NomFichierLePlusLong;

                lbListeFichierCsproj.Items.Clear();
                foreach (var f in analyseur.ListeFichiersCsproj)
                    lbListeFichierCsproj.Items.Add(f);

            }
        }

        private void BtBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            var res = dialog.ShowDialog();
            if(res == DialogResult.OK)
                tbDossierSelectionne.Text = dialog.SelectedPath;
        }

        private void CbNomFichierLePlusLong_CheckedChanged(object sender, EventArgs e)
        {
            lblNomFichierLePlusLong.Visible = !lblNomFichierLePlusLong.Visible;
            tbValNomFichierLePlusLong.Visible = !tbValNomFichierLePlusLong.Visible;
        }

        private void CbNbFichiers_CheckedChanged(object sender, EventArgs e)
        {
            tbNbFichiers.Visible = !tbNbFichiers.Visible;
            tbValNbFichiers.Visible = !tbValNbFichiers.Visible;
        }

        private void CbNbFichierCs_CheckedChanged(object sender, EventArgs e)
        {
            tbNbFichierCs.Visible = !tbNbFichierCs.Visible;
            tbValNbFichierCs.Visible = !tbValNbFichierCs.Visible;
        }

        private void CbListeFichierCsproj_CheckedChanged(object sender, EventArgs e)
        {
            lbListeFichierCsproj.Visible = !lbListeFichierCsproj.Visible;
        }
    }
}
