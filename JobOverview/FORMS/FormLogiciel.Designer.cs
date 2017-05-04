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
            this.dgvVersion = new System.Windows.Forms.DataGridView();
            this.btnAjoutVersion = new System.Windows.Forms.Button();
            this.btnSupprVersion = new System.Windows.Forms.Button();
            this.dgvModule = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModule)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbLogiciel
            // 
            this.cmbLogiciel.FormattingEnabled = true;
            this.cmbLogiciel.Location = new System.Drawing.Point(105, 30);
            this.cmbLogiciel.Name = "cmbLogiciel";
            this.cmbLogiciel.Size = new System.Drawing.Size(140, 21);
            this.cmbLogiciel.TabIndex = 0;
            // 
            // lblLogiciel
            // 
            this.lblLogiciel.AutoSize = true;
            this.lblLogiciel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogiciel.Location = new System.Drawing.Point(23, 31);
            this.lblLogiciel.Name = "lblLogiciel";
            this.lblLogiciel.Size = new System.Drawing.Size(64, 16);
            this.lblLogiciel.TabIndex = 1;
            this.lblLogiciel.Text = "Logiciel";
            // 
            // dgvVersion
            // 
            this.dgvVersion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVersion.Location = new System.Drawing.Point(14, 78);
            this.dgvVersion.Name = "dgvVersion";
            this.dgvVersion.Size = new System.Drawing.Size(418, 325);
            this.dgvVersion.TabIndex = 2;
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
            // dgvModule
            // 
            this.dgvModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModule.Location = new System.Drawing.Point(465, 78);
            this.dgvModule.Name = "dgvModule";
            this.dgvModule.Size = new System.Drawing.Size(418, 325);
            this.dgvModule.TabIndex = 2;
            // 
            // FormLogiciel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 469);
            this.Controls.Add(this.btnSupprVersion);
            this.Controls.Add(this.btnAjoutVersion);
            this.Controls.Add(this.dgvModule);
            this.Controls.Add(this.dgvVersion);
            this.Controls.Add(this.lblLogiciel);
            this.Controls.Add(this.cmbLogiciel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormLogiciel";
            this.Text = "FormLogiciel";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLogiciel;
        private System.Windows.Forms.Label lblLogiciel;
        private System.Windows.Forms.DataGridView dgvVersion;
        private System.Windows.Forms.Button btnAjoutVersion;
        private System.Windows.Forms.Button btnSupprVersion;
        private System.Windows.Forms.DataGridView dgvModule;
    }
}