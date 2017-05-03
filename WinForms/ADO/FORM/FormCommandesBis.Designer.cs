namespace ADO
{
    partial class FormCommandesBis
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
            this.dgvCommandes = new System.Windows.Forms.DataGridView();
            this.dgvDetailsCommande = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRechercheOK = new System.Windows.Forms.Button();
            this.mtbRecherche = new System.Windows.Forms.MaskedTextBox();
            this.btnImportXML = new System.Windows.Forms.Button();
            this.btnExportXML = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailsCommande)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCommandes
            // 
            this.dgvCommandes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommandes.Location = new System.Drawing.Point(12, 92);
            this.dgvCommandes.Name = "dgvCommandes";
            this.dgvCommandes.Size = new System.Drawing.Size(373, 377);
            this.dgvCommandes.TabIndex = 0;
            // 
            // dgvDetailsCommande
            // 
            this.dgvDetailsCommande.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailsCommande.Location = new System.Drawing.Point(406, 92);
            this.dgvDetailsCommande.Name = "dgvDetailsCommande";
            this.dgvDetailsCommande.Size = new System.Drawing.Size(426, 377);
            this.dgvDetailsCommande.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Commande";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(403, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Détail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Recherche";
            // 
            // btnRechercheOK
            // 
            this.btnRechercheOK.Location = new System.Drawing.Point(261, 21);
            this.btnRechercheOK.Name = "btnRechercheOK";
            this.btnRechercheOK.Size = new System.Drawing.Size(75, 23);
            this.btnRechercheOK.TabIndex = 5;
            this.btnRechercheOK.Text = "OK";
            this.btnRechercheOK.UseVisualStyleBackColor = true;
            // 
            // mtbRecherche
            // 
            this.mtbRecherche.Location = new System.Drawing.Point(78, 23);
            this.mtbRecherche.Mask = "99999";
            this.mtbRecherche.Name = "mtbRecherche";
            this.mtbRecherche.Size = new System.Drawing.Size(153, 20);
            this.mtbRecherche.TabIndex = 6;
            this.mtbRecherche.ValidatingType = typeof(int);
            // 
            // btnImportXML
            // 
            this.btnImportXML.Location = new System.Drawing.Point(406, 23);
            this.btnImportXML.Name = "btnImportXML";
            this.btnImportXML.Size = new System.Drawing.Size(110, 23);
            this.btnImportXML.TabIndex = 7;
            this.btnImportXML.Text = "Importer XML";
            this.btnImportXML.UseVisualStyleBackColor = true;
            // 
            // btnExportXML
            // 
            this.btnExportXML.Location = new System.Drawing.Point(574, 23);
            this.btnExportXML.Name = "btnExportXML";
            this.btnExportXML.Size = new System.Drawing.Size(110, 23);
            this.btnExportXML.TabIndex = 8;
            this.btnExportXML.Text = "Exporter XML";
            this.btnExportXML.UseVisualStyleBackColor = true;
            this.btnExportXML.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormCommandesBis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 481);
            this.Controls.Add(this.btnExportXML);
            this.Controls.Add(this.btnImportXML);
            this.Controls.Add(this.mtbRecherche);
            this.Controls.Add(this.btnRechercheOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDetailsCommande);
            this.Controls.Add(this.dgvCommandes);
            this.Name = "FormCommandesBis";
            this.Text = "FormCommandesBis";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailsCommande)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCommandes;
        private System.Windows.Forms.DataGridView dgvDetailsCommande;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRechercheOK;
        private System.Windows.Forms.MaskedTextBox mtbRecherche;
        private System.Windows.Forms.Button btnImportXML;
        private System.Windows.Forms.Button btnExportXML;
    }
}