namespace JobOverview
{
    partial class FormTachesAnnexes
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
            this.cbPersonne = new System.Windows.Forms.ComboBox();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.dgvTachesAnx = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTachesAnx)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Personne";
            // 
            // cbPersonne
            // 
            this.cbPersonne.FormattingEnabled = true;
            this.cbPersonne.Location = new System.Drawing.Point(120, 32);
            this.cbPersonne.Name = "cbPersonne";
            this.cbPersonne.Size = new System.Drawing.Size(213, 21);
            this.cbPersonne.TabIndex = 1;
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Location = new System.Drawing.Point(376, 32);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(113, 23);
            this.btnEnregistrer.TabIndex = 2;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            // 
            // dgvTachesAnx
            // 
            this.dgvTachesAnx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTachesAnx.Location = new System.Drawing.Point(48, 84);
            this.dgvTachesAnx.Name = "dgvTachesAnx";
            this.dgvTachesAnx.Size = new System.Drawing.Size(441, 346);
            this.dgvTachesAnx.TabIndex = 3;
            // 
            // FormTachesAnnexes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 459);
            this.Controls.Add(this.dgvTachesAnx);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.cbPersonne);
            this.Controls.Add(this.label1);
            this.Name = "FormTachesAnnexes";
            this.Text = "FormTachesAnnexes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTachesAnx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPersonne;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.DataGridView dgvTachesAnx;
    }
}