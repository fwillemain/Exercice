namespace FileExplorerWF
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbDossierSelectionne = new System.Windows.Forms.TextBox();
            this.btBrowse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbNbFichiers = new System.Windows.Forms.CheckBox();
            this.cbNbFichierCs = new System.Windows.Forms.CheckBox();
            this.cbNomFichierLePlusLong = new System.Windows.Forms.CheckBox();
            this.cbListeFichierCsproj = new System.Windows.Forms.CheckBox();
            this.lbListeFichierCsproj = new System.Windows.Forms.ListBox();
            this.tbValNbFichiers = new System.Windows.Forms.TextBox();
            this.tbNbFichiers = new System.Windows.Forms.TextBox();
            this.tbValNbFichierCs = new System.Windows.Forms.TextBox();
            this.tbNbFichierCs = new System.Windows.Forms.TextBox();
            this.lblNomFichierLePlusLong = new System.Windows.Forms.Label();
            this.tbValNomFichierLePlusLong = new System.Windows.Forms.TextBox();
            this.btAnalyser = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dossier séléctionné";
            // 
            // tbDossierSelectionne
            // 
            this.tbDossierSelectionne.Location = new System.Drawing.Point(43, 50);
            this.tbDossierSelectionne.Name = "tbDossierSelectionne";
            this.tbDossierSelectionne.Size = new System.Drawing.Size(486, 20);
            this.tbDossierSelectionne.TabIndex = 1;
            // 
            // btBrowse
            // 
            this.btBrowse.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBrowse.Location = new System.Drawing.Point(553, 48);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(75, 23);
            this.btBrowse.TabIndex = 2;
            this.btBrowse.Text = "...";
            this.btBrowse.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbListeFichierCsproj);
            this.groupBox1.Controls.Add(this.cbNomFichierLePlusLong);
            this.groupBox1.Controls.Add(this.cbNbFichierCs);
            this.groupBox1.Controls.Add(this.cbNbFichiers);
            this.groupBox1.Location = new System.Drawing.Point(43, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 130);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Afficher";
            // 
            // cbNbFichiers
            // 
            this.cbNbFichiers.AutoSize = true;
            this.cbNbFichiers.Checked = true;
            this.cbNbFichiers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNbFichiers.Location = new System.Drawing.Point(11, 22);
            this.cbNbFichiers.Name = "cbNbFichiers";
            this.cbNbFichiers.Size = new System.Drawing.Size(114, 17);
            this.cbNbFichiers.TabIndex = 0;
            this.cbNbFichiers.Text = "Nombre de fichiers";
            this.cbNbFichiers.UseVisualStyleBackColor = true;
            // 
            // cbNbFichierCs
            // 
            this.cbNbFichierCs.AutoSize = true;
            this.cbNbFichierCs.Checked = true;
            this.cbNbFichierCs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNbFichierCs.Location = new System.Drawing.Point(11, 46);
            this.cbNbFichierCs.Name = "cbNbFichierCs";
            this.cbNbFichierCs.Size = new System.Drawing.Size(131, 17);
            this.cbNbFichierCs.TabIndex = 1;
            this.cbNbFichierCs.Text = "Nombre de fichiers .cs";
            this.cbNbFichierCs.UseVisualStyleBackColor = true;
            // 
            // cbNomFichierLePlusLong
            // 
            this.cbNomFichierLePlusLong.AutoSize = true;
            this.cbNomFichierLePlusLong.Checked = true;
            this.cbNomFichierLePlusLong.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNomFichierLePlusLong.Location = new System.Drawing.Point(11, 70);
            this.cbNomFichierLePlusLong.Name = "cbNomFichierLePlusLong";
            this.cbNomFichierLePlusLong.Size = new System.Drawing.Size(150, 17);
            this.cbNomFichierLePlusLong.TabIndex = 2;
            this.cbNomFichierLePlusLong.Text = "Nom de fichier le plus long";
            this.cbNomFichierLePlusLong.UseVisualStyleBackColor = true;
            // 
            // cbListeFichierCsproj
            // 
            this.cbListeFichierCsproj.AutoSize = true;
            this.cbListeFichierCsproj.Checked = true;
            this.cbListeFichierCsproj.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbListeFichierCsproj.Location = new System.Drawing.Point(11, 94);
            this.cbListeFichierCsproj.Name = "cbListeFichierCsproj";
            this.cbListeFichierCsproj.Size = new System.Drawing.Size(138, 17);
            this.cbListeFichierCsproj.TabIndex = 3;
            this.cbListeFichierCsproj.Text = "Liste des fichiers .csproj";
            this.cbListeFichierCsproj.UseVisualStyleBackColor = true;
            // 
            // lbListeFichierCsproj
            // 
            this.lbListeFichierCsproj.FormattingEnabled = true;
            this.lbListeFichierCsproj.Location = new System.Drawing.Point(281, 98);
            this.lbListeFichierCsproj.Name = "lbListeFichierCsproj";
            this.lbListeFichierCsproj.Size = new System.Drawing.Size(347, 212);
            this.lbListeFichierCsproj.TabIndex = 4;
            // 
            // tbValNbFichiers
            // 
            this.tbValNbFichiers.Location = new System.Drawing.Point(54, 262);
            this.tbValNbFichiers.Name = "tbValNbFichiers";
            this.tbValNbFichiers.Size = new System.Drawing.Size(44, 20);
            this.tbValNbFichiers.TabIndex = 5;
            // 
            // tbNbFichiers
            // 
            this.tbNbFichiers.Location = new System.Drawing.Point(104, 262);
            this.tbNbFichiers.Name = "tbNbFichiers";
            this.tbNbFichiers.Size = new System.Drawing.Size(100, 20);
            this.tbNbFichiers.TabIndex = 6;
            this.tbNbFichiers.Text = "fichiers";
            // 
            // tbValNbFichierCs
            // 
            this.tbValNbFichierCs.Location = new System.Drawing.Point(54, 286);
            this.tbValNbFichierCs.Name = "tbValNbFichierCs";
            this.tbValNbFichierCs.Size = new System.Drawing.Size(44, 20);
            this.tbValNbFichierCs.TabIndex = 5;
            // 
            // tbNbFichierCs
            // 
            this.tbNbFichierCs.Location = new System.Drawing.Point(104, 286);
            this.tbNbFichierCs.Name = "tbNbFichierCs";
            this.tbNbFichierCs.Size = new System.Drawing.Size(100, 20);
            this.tbNbFichierCs.TabIndex = 6;
            this.tbNbFichierCs.Text = "fichiers .cs";
            // 
            // lblNomFichierLePlusLong
            // 
            this.lblNomFichierLePlusLong.AutoSize = true;
            this.lblNomFichierLePlusLong.Location = new System.Drawing.Point(54, 325);
            this.lblNomFichierLePlusLong.Name = "lblNomFichierLePlusLong";
            this.lblNomFichierLePlusLong.Size = new System.Drawing.Size(131, 13);
            this.lblNomFichierLePlusLong.TabIndex = 7;
            this.lblNomFichierLePlusLong.Text = "Nom de fichier le plus long";
            // 
            // tbValNomFichierLePlusLong
            // 
            this.tbValNomFichierLePlusLong.Location = new System.Drawing.Point(54, 350);
            this.tbValNomFichierLePlusLong.MaximumSize = new System.Drawing.Size(500, 20);
            this.tbValNomFichierLePlusLong.Name = "tbValNomFichierLePlusLong";
            this.tbValNomFichierLePlusLong.Size = new System.Drawing.Size(180, 20);
            this.tbValNomFichierLePlusLong.TabIndex = 8;
            this.tbValNomFichierLePlusLong.Text = "Test d\'un nom de fichier super long pour dépasser en longueur";
            // 
            // btAnalyser
            // 
            this.btAnalyser.Location = new System.Drawing.Point(53, 94);
            this.btAnalyser.Name = "btAnalyser";
            this.btAnalyser.Size = new System.Drawing.Size(190, 23);
            this.btAnalyser.TabIndex = 9;
            this.btAnalyser.Text = "Analyser";
            this.btAnalyser.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 419);
            this.Controls.Add(this.btAnalyser);
            this.Controls.Add(this.tbValNomFichierLePlusLong);
            this.Controls.Add(this.lblNomFichierLePlusLong);
            this.Controls.Add(this.tbNbFichierCs);
            this.Controls.Add(this.tbValNbFichierCs);
            this.Controls.Add(this.tbNbFichiers);
            this.Controls.Add(this.tbValNbFichiers);
            this.Controls.Add(this.lbListeFichierCsproj);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.tbDossierSelectionne);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDossierSelectionne;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbListeFichierCsproj;
        private System.Windows.Forms.CheckBox cbNomFichierLePlusLong;
        private System.Windows.Forms.CheckBox cbNbFichierCs;
        private System.Windows.Forms.CheckBox cbNbFichiers;
        private System.Windows.Forms.ListBox lbListeFichierCsproj;
        private System.Windows.Forms.TextBox tbValNbFichiers;
        private System.Windows.Forms.TextBox tbNbFichiers;
        private System.Windows.Forms.TextBox tbValNbFichierCs;
        private System.Windows.Forms.TextBox tbNbFichierCs;
        private System.Windows.Forms.Label lblNomFichierLePlusLong;
        private System.Windows.Forms.TextBox tbValNomFichierLePlusLong;
        private System.Windows.Forms.Button btAnalyser;
    }
}

