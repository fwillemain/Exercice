namespace ADO
{
    partial class FormFournisseurs
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
            this.dgvFournisseurs = new System.Windows.Forms.DataGridView();
            this.clPaysFournisseurs = new System.Windows.Forms.ComboBox();
            this.lblNbProdPays = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvProduits = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFournisseurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduits)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFournisseurs
            // 
            this.dgvFournisseurs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvFournisseurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFournisseurs.Location = new System.Drawing.Point(12, 55);
            this.dgvFournisseurs.Name = "dgvFournisseurs";
            this.dgvFournisseurs.ReadOnly = true;
            this.dgvFournisseurs.Size = new System.Drawing.Size(968, 188);
            this.dgvFournisseurs.TabIndex = 0;
            // 
            // clPaysFournisseurs
            // 
            this.clPaysFournisseurs.FormattingEnabled = true;
            this.clPaysFournisseurs.Location = new System.Drawing.Point(12, 12);
            this.clPaysFournisseurs.Name = "clPaysFournisseurs";
            this.clPaysFournisseurs.Size = new System.Drawing.Size(205, 21);
            this.clPaysFournisseurs.TabIndex = 1;
            // 
            // lblNbProdPays
            // 
            this.lblNbProdPays.AutoSize = true;
            this.lblNbProdPays.Location = new System.Drawing.Point(304, 22);
            this.lblNbProdPays.Name = "lblNbProdPays";
            this.lblNbProdPays.Size = new System.Drawing.Size(0, 13);
            this.lblNbProdPays.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "produits livrés dans le pays séléctionné.";
            // 
            // dgvProduits
            // 
            this.dgvProduits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduits.Location = new System.Drawing.Point(12, 260);
            this.dgvProduits.Name = "dgvProduits";
            this.dgvProduits.ReadOnly = true;
            this.dgvProduits.Size = new System.Drawing.Size(968, 303);
            this.dgvProduits.TabIndex = 4;
            // 
            // FormFournisseurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 575);
            this.Controls.Add(this.dgvProduits);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNbProdPays);
            this.Controls.Add(this.clPaysFournisseurs);
            this.Controls.Add(this.dgvFournisseurs);
            this.Name = "FormFournisseurs";
            this.Text = "FormFournisseurs";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFournisseurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFournisseurs;
        private System.Windows.Forms.ComboBox clPaysFournisseurs;
        private System.Windows.Forms.Label lblNbProdPays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvProduits;
    }
}