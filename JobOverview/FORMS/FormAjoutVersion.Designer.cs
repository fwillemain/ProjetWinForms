namespace JobOverview
{
    partial class FormAjoutVersion
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
            this.mtbNumero = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mtbMillesime = new System.Windows.Forms.MaskedTextBox();
            this.dtpDateOuverture = new System.Windows.Forms.DateTimePicker();
            this.dtpDateSortiePrevue = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnValider = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mtbNumero
            // 
            this.mtbNumero.Location = new System.Drawing.Point(26, 34);
            this.mtbNumero.Mask = "99.99";
            this.mtbNumero.Name = "mtbNumero";
            this.mtbNumero.Size = new System.Drawing.Size(170, 20);
            this.mtbNumero.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Millesime";
            // 
            // mtbMillesime
            // 
            this.mtbMillesime.Location = new System.Drawing.Point(26, 84);
            this.mtbMillesime.Mask = "9999";
            this.mtbMillesime.Name = "mtbMillesime";
            this.mtbMillesime.Size = new System.Drawing.Size(170, 20);
            this.mtbMillesime.TabIndex = 3;
            // 
            // dtpDateOuverture
            // 
            this.dtpDateOuverture.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOuverture.Location = new System.Drawing.Point(26, 143);
            this.dtpDateOuverture.Name = "dtpDateOuverture";
            this.dtpDateOuverture.Size = new System.Drawing.Size(170, 20);
            this.dtpDateOuverture.TabIndex = 4;
            // 
            // dtpDateSortiePrevue
            // 
            this.dtpDateSortiePrevue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateSortiePrevue.Location = new System.Drawing.Point(26, 202);
            this.dtpDateSortiePrevue.Name = "dtpDateSortiePrevue";
            this.dtpDateSortiePrevue.Size = new System.Drawing.Size(170, 20);
            this.dtpDateSortiePrevue.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date ouverture";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date Sortie prévue";
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(26, 260);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(75, 23);
            this.btnValider.TabIndex = 7;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(132, 260);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuler.TabIndex = 8;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            // 
            // FormAjoutVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 313);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDateSortiePrevue);
            this.Controls.Add(this.dtpDateOuverture);
            this.Controls.Add(this.mtbMillesime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtbNumero);
            this.Name = "FormAjoutVersion";
            this.Text = "FormAjoutVersion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtbNumero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtbMillesime;
        private System.Windows.Forms.DateTimePicker dtpDateOuverture;
        private System.Windows.Forms.DateTimePicker dtpDateSortiePrevue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnAnnuler;
    }
}