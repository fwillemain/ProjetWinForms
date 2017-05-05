using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace JobOverview
{
	public partial class MDIForm : Form
	{
		// Collection des fenêtres filles
		public Dictionary<string, Form> ChildForms { get; private set; }
        //Champs privés
        private List<TacheProd> _ListTachesProd;
        public MDIForm()
		{
			InitializeComponent();
			ChildForms = new Dictionary<string, Form>();

            // TODO : Branchement des menus
            mnLogiciel.Click += (object sender, EventArgs e) => ShowChild("JobOverview.FormLogiciel");
            mnTachesProd.Click += (object sender, EventArgs e) => ShowChild("JobOverview.FormTachesProduction");

            mnImport.Click += MnImport_Click;
            mnExport.Click += MnExport_Click;
        }

        protected override void OnLoad(EventArgs e)
        {
            var result = new FormConfig().ShowDialog();

            if (result != DialogResult.OK)
                Close();

            base.OnLoad(e);
        }


        private void MnExport_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Confirmez-vous l'export des données depuis la base?", "Export des données", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                try
                {
                    DALXmlcs.ExporterXml(_ListTachesProd);
                    MessageBox.Show("L'export des données a été executé correctement", "Export des données");
                }
                catch (Exception)
                {

                    MessageBox.Show("L'Export des données n'a pas été executé correctement", "Export des données");
                }
                
            }
        }

        private void MnImport_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Confirmez-vous l'import des données dans la base?", "Import des données", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                try
                {
                    _ListTachesProd = DALXmlcs.Importerfichier();

                    DALLogiciel.AjoutTachesProdBDD(_ListTachesProd);
                    MessageBox.Show("L'import des données a été executé correctement", "Import des données");
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Attention : L'import des données n'a pas été executé correctement", "Import des données");
                    // TODO : gérer l'erreur si nécessaire
                }
            }
        }

        // Affichage d'une fenêtre fille
        private void ShowChild(string name)
		{
			// Dans la collection des fenêtres filles, on recherche une fenêtre
			// dont le nom correspond à celui passé en paramètre...
			this.SuspendLayout();   // On stope le rafraîchissement du visuel
			Form form;
			if (!ChildForms.TryGetValue(name, out form))
			{
				// Si on n'en a pas trouvé, on crée une instance de cette fenêtre
				Type t = Type.GetType(name);
				form = (Form)Activator.CreateInstance(t);
				form.Name = name;

				form.MdiParent = this;
				form.FormClosed += (object sender, FormClosedEventArgs e) => RemoveChild(form);
				form.MaximizeBox = false;
				form.MinimizeBox = false;
				form.Show();

				// on ajoute la fenêtre à la collection des fenêtres filles
				// et on crée un menu associé
				AddChild(form);
				menuWindows.Visible = true;
			}

			// On maximise la taille de la fenêtre
			form.Select();
			form.WindowState = FormWindowState.Maximized;
			this.ResumeLayout(); // Rafraîchit le visuel
		}

		// Ajoute une fenêtre fille et son entrée dans le menu Fenêtres
		private void AddChild(Form f)
		{
			ChildForms.Add(f.Name, f);
			var it = menuWindows.DropDownItems.Add(f.Text);
			it.Name = f.Name;
			it.Click += (object sender, EventArgs e) => ShowChild(it.Name);
		}


		// Supprime une fenêtre fille et son entrée dans le menu Fenêtres
		private void RemoveChild(Form f)
		{
			ChildForms.Remove(f.Name);
			menuWindows.DropDownItems.RemoveByKey(f.Name);
			if (ChildForms.Count == 0) menuWindows.Visible = false;
		}

	}
}
