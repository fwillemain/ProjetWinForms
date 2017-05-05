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
            this.chkTachesTerm = new System.Windows.Forms.CheckBox();
            this.lblPersonne = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnAjout = new System.Windows.Forms.Button();
            this.btnSuppr = new System.Windows.Forms.Button();
            this.tacheProdTableAdapter1 = new JobOverview.JobOverviewDataSetTableAdapters.TacheProdTableAdapter();
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
            this.dgvTachesProd.Size = new System.Drawing.Size(599, 318);
            this.dgvTachesProd.TabIndex = 1;
            // 
            // chkTachesTerm
            // 
            this.chkTachesTerm.AutoSize = true;
            this.chkTachesTerm.Checked = true;
            this.chkTachesTerm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTachesTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTachesTerm.Location = new System.Drawing.Point(482, 66);
            this.chkTachesTerm.Name = "chkTachesTerm";
            this.chkTachesTerm.Size = new System.Drawing.Size(130, 17);
            this.chkTachesTerm.TabIndex = 2;
            this.chkTachesTerm.Text = "Taches Terminées";
            this.chkTachesTerm.UseVisualStyleBackColor = true;
            // 
            // lblPersonne
            // 
            this.lblPersonne.AutoSize = true;
            this.lblPersonne.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonne.Location = new System.Drawing.Point(18, 15);
            this.lblPersonne.Name = "lblPersonne";
            this.lblPersonne.Size = new System.Drawing.Size(60, 13);
            this.lblPersonne.TabIndex = 3;
            this.lblPersonne.Text = "Personne";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(18, 49);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(49, 13);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Version";
            // 
            // btnAjout
            // 
            this.btnAjout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjout.Location = new System.Drawing.Point(628, 209);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(108, 95);
            this.btnAjout.TabIndex = 4;
            this.btnAjout.Text = "Ajout Tâche";
            this.btnAjout.UseVisualStyleBackColor = true;
            // 
            // btnSuppr
            // 
            this.btnSuppr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuppr.Location = new System.Drawing.Point(628, 310);
            this.btnSuppr.Name = "btnSuppr";
            this.btnSuppr.Size = new System.Drawing.Size(108, 95);
            this.btnSuppr.TabIndex = 5;
            this.btnSuppr.Text = "Suppression Tâche";
            this.btnSuppr.UseVisualStyleBackColor = true;
            // 
            // tacheProdTableAdapter1
            // 
            this.tacheProdTableAdapter1.ClearBeforeFill = true;
            // 
            // FormTachesProduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(902, 520);
            this.Controls.Add(this.btnSuppr);
            this.Controls.Add(this.btnAjout);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblPersonne);
            this.Controls.Add(this.chkTachesTerm);
            this.Controls.Add(this.dgvTachesProd);
            this.Controls.Add(this.cmbVersion);
            this.Controls.Add(this.cmbPersonnes);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Name = "FormTachesProduction";
            this.Text = "Taches de Production";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTachesProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPersonnes;
        private System.Windows.Forms.ComboBox cmbVersion;
        private System.Windows.Forms.DataGridView dgvTachesProd;
        private System.Windows.Forms.CheckBox chkTachesTerm;
        private System.Windows.Forms.Label lblPersonne;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnAjout;
        private System.Windows.Forms.Button btnSuppr;
        private JobOverviewDataSetTableAdapters.TacheProdTableAdapter tacheProdTableAdapter1;
    }
}