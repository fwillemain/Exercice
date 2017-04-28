namespace ADO
{
    partial class FormProduits
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
            this.btnAjoutPdt = new System.Windows.Forms.Button();
            this.btnSupPdt = new System.Windows.Forms.Button();
            this.dgvProduits = new System.Windows.Forms.DataGridView();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduits)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAjoutPdt
            // 
            this.btnAjoutPdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjoutPdt.Location = new System.Drawing.Point(12, 12);
            this.btnAjoutPdt.Name = "btnAjoutPdt";
            this.btnAjoutPdt.Size = new System.Drawing.Size(54, 45);
            this.btnAjoutPdt.TabIndex = 0;
            this.btnAjoutPdt.Text = "+";
            this.btnAjoutPdt.UseVisualStyleBackColor = true;
            // 
            // btnSupPdt
            // 
            this.btnSupPdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupPdt.Location = new System.Drawing.Point(72, 12);
            this.btnSupPdt.Name = "btnSupPdt";
            this.btnSupPdt.Size = new System.Drawing.Size(54, 45);
            this.btnSupPdt.TabIndex = 1;
            this.btnSupPdt.Text = "-";
            this.btnSupPdt.UseVisualStyleBackColor = true;
            // 
            // dgvProduits
            // 
            this.dgvProduits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvProduits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduits.Location = new System.Drawing.Point(12, 63);
            this.dgvProduits.Name = "dgvProduits";
            this.dgvProduits.Size = new System.Drawing.Size(921, 424);
            this.dgvProduits.TabIndex = 2;
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Location = new System.Drawing.Point(145, 24);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(105, 23);
            this.btnEnregistrer.TabIndex = 3;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            // 
            // FormProduits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 499);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.dgvProduits);
            this.Controls.Add(this.btnSupPdt);
            this.Controls.Add(this.btnAjoutPdt);
            this.Name = "FormProduits";
            this.Text = "Produits";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSupPdt;
        private System.Windows.Forms.DataGridView dgvProduits;
        private System.Windows.Forms.Button btnAjoutPdt;
        private System.Windows.Forms.Button btnEnregistrer;
    }
}