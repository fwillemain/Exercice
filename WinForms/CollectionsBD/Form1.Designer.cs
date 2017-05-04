namespace CollectionsBD
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
            this.lbTitreAlbum = new System.Windows.Forms.ListBox();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTitreAlbum
            // 
            this.lbTitreAlbum.FormattingEnabled = true;
            this.lbTitreAlbum.Location = new System.Drawing.Point(36, 106);
            this.lbTitreAlbum.Name = "lbTitreAlbum";
            this.lbTitreAlbum.Size = new System.Drawing.Size(226, 251);
            this.lbTitreAlbum.TabIndex = 0;
            // 
            // btnAfficher
            // 
            this.btnAfficher.Location = new System.Drawing.Point(36, 27);
            this.btnAfficher.Name = "btnAfficher";
            this.btnAfficher.Size = new System.Drawing.Size(127, 26);
            this.btnAfficher.TabIndex = 1;
            this.btnAfficher.Text = "Afficher";
            this.btnAfficher.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 403);
            this.Controls.Add(this.btnAfficher);
            this.Controls.Add(this.lbTitreAlbum);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbTitreAlbum;
        private System.Windows.Forms.Button btnAfficher;
    }
}

