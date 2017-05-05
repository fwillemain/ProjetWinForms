namespace JobOverview
{
	partial class MDIForm
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.menuGeneral = new System.Windows.Forms.MenuStrip();
            this.mnLogiciel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTachesProd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnechanges = new System.Windows.Forms.ToolStripMenuItem();
            this.mnImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTachesAnx = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuGeneral
            // 
            this.menuGeneral.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnLogiciel,
            this.mnTachesProd,
            this.mnTachesAnx,
            this.mnechanges,
            this.menuWindows});
            this.menuGeneral.Location = new System.Drawing.Point(0, 0);
            this.menuGeneral.Name = "menuGeneral";
            this.menuGeneral.Size = new System.Drawing.Size(787, 24);
            this.menuGeneral.TabIndex = 0;
            this.menuGeneral.Text = "menuStrip1";
            // 
            // mnLogiciel
            // 
            this.mnLogiciel.Name = "mnLogiciel";
            this.mnLogiciel.Size = new System.Drawing.Size(127, 20);
            this.mnLogiciel.Text = "Version des Logiciels";
            // 
            // mnTachesProd
            // 
            this.mnTachesProd.Name = "mnTachesProd";
            this.mnTachesProd.Size = new System.Drawing.Size(117, 20);
            this.mnTachesProd.Text = "Taches Production";
            // 
            // mnechanges
            // 
            this.mnechanges.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnImport,
            this.mnExport});
            this.mnechanges.Name = "mnechanges";
            this.mnechanges.Size = new System.Drawing.Size(69, 20);
            this.mnechanges.Text = "Echanges";
            // 
            // mnImport
            // 
            this.mnImport.Name = "mnImport";
            this.mnImport.Size = new System.Drawing.Size(211, 22);
            this.mnImport.Text = "Import Tâches Production";
            // 
            // mnExport
            // 
            this.mnExport.Name = "mnExport";
            this.mnExport.Size = new System.Drawing.Size(211, 22);
            this.mnExport.Text = "Export Tâches  Equipe";
            // 
            // mnTachesAnx
            // 
            this.mnTachesAnx.Name = "mnTachesAnx";
            this.mnTachesAnx.Size = new System.Drawing.Size(100, 20);
            this.mnTachesAnx.Text = "Taches annexes";
            // 
            // menuWindows
            // 
            this.menuWindows.Name = "menuWindows";
            this.menuWindows.Size = new System.Drawing.Size(63, 20);
            this.menuWindows.Text = "Fenêtres";
            // 
            // MDIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 514);
            this.Controls.Add(this.menuGeneral);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuGeneral;
            this.Name = "MDIForm";
            this.Text = "JobOverview";
            this.menuGeneral.ResumeLayout(false);
            this.menuGeneral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuGeneral;
		private System.Windows.Forms.ToolStripMenuItem mnLogiciel;
		private System.Windows.Forms.ToolStripMenuItem menuWindows;
		private System.Windows.Forms.ToolStripMenuItem mnTachesProd;
        private System.Windows.Forms.ToolStripMenuItem mnechanges;
        private System.Windows.Forms.ToolStripMenuItem mnImport;
        private System.Windows.Forms.ToolStripMenuItem mnExport;
        private System.Windows.Forms.ToolStripMenuItem mnTachesAnx;
    }
}

