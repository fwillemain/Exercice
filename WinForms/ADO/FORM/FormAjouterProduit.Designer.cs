namespace ADO
{
    partial class FormAjouterProduit
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
            this.lblNom = new System.Windows.Forms.Label();
            this.lblCatégorie = new System.Windows.Forms.Label();
            this.lblQtéUnitaire = new System.Windows.Forms.Label();
            this.lblPrixUnitaire = new System.Windows.Forms.Label();
            this.lblUnitésStock = new System.Windows.Forms.Label();
            this.lblFournisseur = new System.Windows.Forms.Label();
            this.mtbQtéUnitaire = new System.Windows.Forms.MaskedTextBox();
            this.mtbPrixUnitaire = new System.Windows.Forms.MaskedTextBox();
            this.mtbUnitésStock = new System.Windows.Forms.MaskedTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.cbCatégorie = new System.Windows.Forms.ComboBox();
            this.cbFournisseur = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(56, 25);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(29, 13);
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "Nom";
            // 
            // lblCatégorie
            // 
            this.lblCatégorie.AutoSize = true;
            this.lblCatégorie.Location = new System.Drawing.Point(33, 66);
            this.lblCatégorie.Name = "lblCatégorie";
            this.lblCatégorie.Size = new System.Drawing.Size(52, 13);
            this.lblCatégorie.TabIndex = 1;
            this.lblCatégorie.Text = "Catégorie";
            // 
            // lblQtéUnitaire
            // 
            this.lblQtéUnitaire.AutoSize = true;
            this.lblQtéUnitaire.Location = new System.Drawing.Point(10, 104);
            this.lblQtéUnitaire.Name = "lblQtéUnitaire";
            this.lblQtéUnitaire.Size = new System.Drawing.Size(84, 13);
            this.lblQtéUnitaire.TabIndex = 2;
            this.lblQtéUnitaire.Text = "Quantité unitaire";
            // 
            // lblPrixUnitaire
            // 
            this.lblPrixUnitaire.AutoSize = true;
            this.lblPrixUnitaire.Location = new System.Drawing.Point(33, 141);
            this.lblPrixUnitaire.Name = "lblPrixUnitaire";
            this.lblPrixUnitaire.Size = new System.Drawing.Size(61, 13);
            this.lblPrixUnitaire.TabIndex = 3;
            this.lblPrixUnitaire.Text = "Prix unitaire";
            // 
            // lblUnitésStock
            // 
            this.lblUnitésStock.AutoSize = true;
            this.lblUnitésStock.Location = new System.Drawing.Point(13, 178);
            this.lblUnitésStock.Name = "lblUnitésStock";
            this.lblUnitésStock.Size = new System.Drawing.Size(81, 13);
            this.lblUnitésStock.TabIndex = 4;
            this.lblUnitésStock.Text = "Unités en stock";
            // 
            // lblFournisseur
            // 
            this.lblFournisseur.AutoSize = true;
            this.lblFournisseur.Location = new System.Drawing.Point(33, 217);
            this.lblFournisseur.Name = "lblFournisseur";
            this.lblFournisseur.Size = new System.Drawing.Size(61, 13);
            this.lblFournisseur.TabIndex = 5;
            this.lblFournisseur.Text = "Fournisseur";
            // 
            // mtbQtéUnitaire
            // 
            this.mtbQtéUnitaire.Location = new System.Drawing.Point(100, 101);
            this.mtbQtéUnitaire.Mask = "99";
            this.mtbQtéUnitaire.Name = "mtbQtéUnitaire";
            this.mtbQtéUnitaire.Size = new System.Drawing.Size(100, 20);
            this.mtbQtéUnitaire.TabIndex = 8;
            // 
            // mtbPrixUnitaire
            // 
            this.mtbPrixUnitaire.Location = new System.Drawing.Point(100, 138);
            this.mtbPrixUnitaire.Mask = "9999.99";
            this.mtbPrixUnitaire.Name = "mtbPrixUnitaire";
            this.mtbPrixUnitaire.Size = new System.Drawing.Size(100, 20);
            this.mtbPrixUnitaire.TabIndex = 9;
            // 
            // mtbUnitésStock
            // 
            this.mtbUnitésStock.Location = new System.Drawing.Point(100, 175);
            this.mtbUnitésStock.Mask = "999";
            this.mtbUnitésStock.Name = "mtbUnitésStock";
            this.mtbUnitésStock.Size = new System.Drawing.Size(100, 20);
            this.mtbUnitésStock.TabIndex = 10;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(256, 260);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(350, 260);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuler.TabIndex = 13;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(100, 25);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(325, 20);
            this.tbNom.TabIndex = 6;
            // 
            // cbCatégorie
            // 
            this.cbCatégorie.FormattingEnabled = true;
            this.cbCatégorie.Location = new System.Drawing.Point(100, 63);
            this.cbCatégorie.Name = "cbCatégorie";
            this.cbCatégorie.Size = new System.Drawing.Size(165, 21);
            this.cbCatégorie.TabIndex = 14;
            // 
            // cbFournisseur
            // 
            this.cbFournisseur.FormattingEnabled = true;
            this.cbFournisseur.Location = new System.Drawing.Point(100, 208);
            this.cbFournisseur.Name = "cbFournisseur";
            this.cbFournisseur.Size = new System.Drawing.Size(165, 21);
            this.cbFournisseur.TabIndex = 15;
            // 
            // FormAjouterProduit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 297);
            this.Controls.Add(this.cbFournisseur);
            this.Controls.Add(this.cbCatégorie);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.mtbUnitésStock);
            this.Controls.Add(this.mtbPrixUnitaire);
            this.Controls.Add(this.mtbQtéUnitaire);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.lblFournisseur);
            this.Controls.Add(this.lblUnitésStock);
            this.Controls.Add(this.lblPrixUnitaire);
            this.Controls.Add(this.lblQtéUnitaire);
            this.Controls.Add(this.lblCatégorie);
            this.Controls.Add(this.lblNom);
            this.Name = "FormAjouterProduit";
            this.Text = "Saisie d\'un produit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblCatégorie;
        private System.Windows.Forms.Label lblQtéUnitaire;
        private System.Windows.Forms.Label lblPrixUnitaire;
        private System.Windows.Forms.Label lblUnitésStock;
        private System.Windows.Forms.Label lblFournisseur;
        private System.Windows.Forms.MaskedTextBox mtbQtéUnitaire;
        private System.Windows.Forms.MaskedTextBox mtbPrixUnitaire;
        private System.Windows.Forms.MaskedTextBox mtbUnitésStock;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.ComboBox cbCatégorie;
        private System.Windows.Forms.ComboBox cbFournisseur;
    }
}