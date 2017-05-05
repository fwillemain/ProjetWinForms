namespace JobOverview
{
    partial class FormTachesProduction
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
            this.cmbPersonnes = new System.Windows.Forms.ComboBox();
            this.cmbVersion = new System.Windows.Forms.ComboBox();
            this.dgvTachesProd = new System.Windows.Forms.DataGridView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.lblPersonne = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnAjout = new System.Windows.Forms.Button();
            this.btnSuppr = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTachesProd)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPersonnes
            // 
            this.cmbPersonnes.FormattingEnabled = true;
            this.cmbPersonnes.Location = new System.Drawing.Point(91, 12);
            this.cmbPersonnes.Name = "cmbPersonnes";
            this.cmbPersonnes.Size = new System.Drawing.Size(121, 21);
            this.cmbPersonnes.TabIndex = 0;
            // 
            // cmbVersion
            // 
            this.cmbVersion.FormattingEnabled = true;
            this.cmbVersion.Location = new System.Drawing.Point(91, 49);
            this.cmbVersion.Name = "cmbVersion";
            this.cmbVersion.Size = new System.Drawing.Size(121, 21);
            this.cmbVersion.TabIndex = 0;
            // 
            // dgvTachesProd
            // 
            this.dgvTachesProd.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvTachesProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTachesProd.Location = new System.Drawing.Point(13, 101);
            this.dgvTachesProd.Name = "dgvTachesProd";
            this.dgvTachesProd.Size = new System.Drawing.Size(529, 318);
            this.dgvTachesProd.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(462, 69);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(586, 69);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(80, 17);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "checkBox1";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // lblPersonne
            // 
            this.lblPersonne.AutoSize = true;
            this.lblPersonne.Location = new System.Drawing.Point(18, 15);
            this.lblPersonne.Name = "lblPersonne";
            this.lblPersonne.Size = new System.Drawing.Size(52, 13);
            this.lblPersonne.TabIndex = 3;
            this.lblPersonne.Text = "Personne";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(18, 49);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Version";
            // 
            // btnAjout
            // 
            this.btnAjout.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjout.Location = new System.Drawing.Point(567, 299);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(75, 39);
            this.btnAjout.TabIndex = 4;
            this.btnAjout.Text = "+";
            this.btnAjout.UseVisualStyleBackColor = true;
            // 
            // btnSuppr
            // 
            this.btnSuppr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuppr.Location = new System.Drawing.Point(567, 363);
            this.btnSuppr.Name = "btnSuppr";
            this.btnSuppr.Size = new System.Drawing.Size(75, 42);
            this.btnSuppr.TabIndex = 5;
            this.btnSuppr.Text = "-";
            this.btnSuppr.UseVisualStyleBackColor = true;
            // 
            // FormTachesProduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(678, 444);
            this.Controls.Add(this.btnSuppr);
            this.Controls.Add(this.btnAjout);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblPersonne);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dgvTachesProd);
            this.Controls.Add(this.cmbVersion);
            this.Controls.Add(this.cmbPersonnes);
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Name = "FormTachesProduction";
            this.Text = "FormTachesProduction";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTachesProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPersonnes;
        private System.Windows.Forms.ComboBox cmbVersion;
        private System.Windows.Forms.DataGridView dgvTachesProd;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label lblPersonne;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnAjout;
        private System.Windows.Forms.Button btnSuppr;
    }
}