using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExplorateurFichiers;
using System.IO;

namespace ExercicesWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            btnBrowseDirectory.Click += BtnBrowse_Click;
            cbNameLongFile.CheckedChanged += CbNameLongFile_CheckedChanged;
            cbNbCsFiles.CheckedChanged += (object sender, EventArgs e) => tbNbCsFiles.Visible = !tbNbCsFiles.Visible;
            cbNbTotFile.CheckedChanged += CbNbTotFile_CheckedChanged;
            cbProjFileList.CheckedChanged += CbProjFileList_CheckedChanged;
            btnAnalyser.Click += BtnAnalyser_Click;
        }

        protected override void OnLoad(EventArgs e)
        {
            tbBrowseDirectory.Text = Properties.Settings.Default.SelectedDirectory;
            cbNameLongFile.Checked = Properties.Settings.Default.cbNameLongFileChecked;
            cbNbCsFiles.Checked = Properties.Settings.Default.cbNbCsFilesChecked;
            cbNbTotFile.Checked = Properties.Settings.Default.cbNbTotFileChecked;
            cbProjFileList.Checked = Properties.Settings.Default.cbProjFileListChecked;

            this.Text = Properties.Resources.ApplicationTitle;
            base.OnLoad(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // REMARQUE : Impossible de gérer la localisation sur l'intitulé des boutons du MessageBox
            DialogResult result = MessageBox.Show(Properties.Resources.SaveBoxMessage,
                        Properties.Resources.SaveBoxTitle, MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Properties.Settings.Default.SelectedDirectory = tbBrowseDirectory.Text;

                Properties.Settings.Default.cbNameLongFileChecked = cbNameLongFile.Checked;
                Properties.Settings.Default.cbNbCsFilesChecked = cbNbCsFiles.Checked;
                Properties.Settings.Default.cbNbTotFileChecked = cbNbTotFile.Checked;
                Properties.Settings.Default.cbProjFileListChecked = cbProjFileList.Checked;
            }

            Properties.Settings.Default.Save();

            base.OnFormClosing(e);
        }

        private void BtnAnalyser_Click(object sender, EventArgs e)
        {
            UpdateInfoDirectory(tbBrowseDirectory.Text);
        }

        private void CbProjFileList_CheckedChanged(object sender, EventArgs e)
        {
            lbProjFileList.Visible = !lbProjFileList.Visible;
            pnlProjFileList.Visible = !pnlProjFileList.Visible;
        }

        private void CbNbTotFile_CheckedChanged(object sender, EventArgs e)
        {
            tbNbTotFile.Visible = !tbNbTotFile.Visible;
        }

        private void CbNbCsFiles_CheckedChanged(object sender, EventArgs e)
        {
            tbNbCsFiles.Visible = !tbNbCsFiles.Visible;
        }

        private void CbNameLongFile_CheckedChanged(object sender, EventArgs e)
        {
            lblNameLongFile.Visible = !lblNameLongFile.Visible;
            tblNameLongFile.Visible = !tblNameLongFile.Visible;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult dr = fbd.ShowDialog();
                if (dr == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tbBrowseDirectory.Text = fbd.SelectedPath;
                }
                else if (dr == DialogResult.Cancel || dr == DialogResult.Abort)
                    tbBrowseDirectory.Text = string.Empty;
            }
        }

        private void UpdateInfoDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                Analyseur.AnalyserDossier(path);

                lbProjFileList.Items.Clear();
                foreach (var a in Analyseur.ListeFichiersProj)
                    lbProjFileList.Items.Add(Path.GetFileNameWithoutExtension(a.Name));

                tbValNbCsFiles.Text = Analyseur.CompteFichiersCs.ToString();
                tbValNbTotFile.Text = Analyseur.CompteFichiers.ToString();
                lblNameLongFile.Text = Analyseur.FichierLePlusLong;
            }
        }
    }
}
