namespace JobOverview
{
    partial class FormLogiciel
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
            this.cmbLogiciel = new System.Windows.Forms.ComboBox();
            this.lblLogiciel = new System.Windows.Forms.Label();
            this.btnAjoutVersion = new System.Windows.Forms.Button();
            this.btnSupprVersion = new System.Windows.Forms.Button();
            this.dgvVersion = new System.Windows.Forms.DataGridView();
            this.lbModule = new System.Windows.Forms.ListBox();
            this.lblModule = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVersion)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbLogiciel
            // 
            this.cmbLogiciel.FormattingEnabled = true;
            this.cmbLogiciel.Location = new System.Drawing.Point(112, 8);
            this.cmbLogiciel.Name = "cmbLogiciel";
            this.cmbLogiciel.Size = new System.Drawing.Size(140, 21);
            this.cmbLogiciel.TabIndex = 0;
            // 
            // lblLogiciel
            // 
            this.lblLogiciel.AutoSize = true;
            this.lblLogiciel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogiciel.Location = new System.Drawing.Point(30, 9);
            this.lblLogiciel.Name = "lblLogiciel";
            this.lblLogiciel.Size = new System.Drawing.Size(63, 16);
            this.lblLogiciel.TabIndex = 1;
            this.lblLogiciel.Text = "Logiciel";
            // 
            // btnAjoutVersion
            // 
            this.btnAjoutVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjoutVersion.Location = new System.Drawing.Point(27, 421);
            this.btnAjoutVersion.Name = "btnAjoutVersion";
            this.btnAjoutVersion.Size = new System.Drawing.Size(66, 40);
            this.btnAjoutVersion.TabIndex = 4;
            this.btnAjoutVersion.Text = "+";
            this.btnAjoutVersion.UseVisualStyleBackColor = true;
            // 
            // btnSupprVersion
            // 
            this.btnSupprVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprVersion.Location = new System.Drawing.Point(145, 421);
            this.btnSupprVersion.Name = "btnSupprVersion";
            this.btnSupprVersion.Size = new System.Drawing.Size(66, 40);
            this.btnSupprVersion.TabIndex = 5;
            this.btnSupprVersion.Text = "-";
            this.btnSupprVersion.UseVisualStyleBackColor = true;
            // 
            // dgvVersion
            // 
            this.dgvVersion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVersion.Location = new System.Drawing.Point(26, 72);
            this.dgvVersion.Name = "dgvVersion";
            this.dgvVersion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvVersion.Size = new System.Drawing.Size(574, 325);
            this.dgvVersion.TabIndex = 2;
            // 
            // lbModule
            // 
            this.lbModule.FormattingEnabled = true;
            this.lbModule.Location = new System.Drawing.Point(663, 72);
            this.lbModule.Name = "lbModule";
            this.lbModule.Size = new System.Drawing.Size(183, 316);
            this.lbModule.TabIndex = 6;
            // 
            // lblModule
            // 
            this.lblModule.AutoSize = true;
            this.lblModule.Location = new System.Drawing.Point(660, 38);
            this.lblModule.Name = "lblModule";
            this.lblModule.Size = new System.Drawing.Size(54, 13);
            this.lblModule.TabIndex = 7;
            this.lblModule.Text = "Modules";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(33, 49);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(121, 13);
            this.lblVersion.TabIndex = 8;
            this.lblVersion.Text = "Versions et releases";
            // 
            // FormLogiciel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(909, 469);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblModule);
            this.Controls.Add(this.lbModule);
            this.Controls.Add(this.btnSupprVersion);
            this.Controls.Add(this.btnAjoutVersion);
            this.Controls.Add(this.dgvVersion);
            this.Controls.Add(this.lblLogiciel);
            this.Controls.Add(this.cmbLogiciel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormLogiciel";
            this.Text = "FormLogiciel";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVersion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLogiciel;
        private System.Windows.Forms.Label lblLogiciel;
        private System.Windows.Forms.Button btnAjoutVersion;
        private System.Windows.Forms.Button btnSupprVersion;
        private System.Windows.Forms.DataGridView dgvVersion;
        private System.Windows.Forms.ListBox lbModule;
        private System.Windows.Forms.Label lblModule;
        private System.Windows.Forms.Label lblVersion;
    }
}