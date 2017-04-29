namespace ADO
{
    partial class FormEmployée
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
            this.cbEmployée = new System.Windows.Forms.ComboBox();
            this.dgvRegTerr = new System.Windows.Forms.DataGridView();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.lblEmployée = new System.Windows.Forms.Label();
            this.btnAnnuler = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegTerr)).BeginInit();
            this.SuspendLayout();
            // 
            // cbEmployée
            // 
            this.cbEmployée.FormattingEnabled = true;
            this.cbEmployée.Location = new System.Drawing.Point(87, 12);
            this.cbEmployée.Name = "cbEmployée";
            this.cbEmployée.Size = new System.Drawing.Size(387, 21);
            this.cbEmployée.TabIndex = 0;
            // 
            // dgvRegTerr
            // 
            this.dgvRegTerr.AllowUserToAddRows = false;
            this.dgvRegTerr.AllowUserToDeleteRows = false;
            this.dgvRegTerr.AllowUserToResizeRows = false;
            this.dgvRegTerr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvRegTerr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegTerr.Location = new System.Drawing.Point(12, 53);
            this.dgvRegTerr.Name = "dgvRegTerr";
            this.dgvRegTerr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRegTerr.Size = new System.Drawing.Size(774, 350);
            this.dgvRegTerr.TabIndex = 1;
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Location = new System.Drawing.Point(12, 421);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(107, 23);
            this.btnEnregistrer.TabIndex = 2;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            // 
            // lblEmployée
            // 
            this.lblEmployée.AutoSize = true;
            this.lblEmployée.Location = new System.Drawing.Point(12, 15);
            this.lblEmployée.Name = "lblEmployée";
            this.lblEmployée.Size = new System.Drawing.Size(53, 13);
            this.lblEmployée.TabIndex = 3;
            this.lblEmployée.Text = "Employée";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(664, 421);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(107, 23);
            this.btnAnnuler.TabIndex = 2;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            // 
            // FormEmployée
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 457);
            this.Controls.Add(this.lblEmployée);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.dgvRegTerr);
            this.Controls.Add(this.cbEmployée);
            this.Name = "FormEmployée";
            this.Text = "FormPersonneMaison";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegTerr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbEmployée;
        private System.Windows.Forms.DataGridView dgvRegTerr;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Label lblEmployée;
        private System.Windows.Forms.Button btnAnnuler;
    }
}