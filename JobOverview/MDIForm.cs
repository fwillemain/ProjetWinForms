using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JobOverview
{
	public partial class MDIForm : Form
	{
		// Collection des fenêtres filles
		public Dictionary<string, Form> ChildForms { get; private set; }

		public MDIForm()
		{
			InitializeComponent();
			ChildForms = new Dictionary<string, Form>();

			// TODO : Branchement des menus
			// menu1.Click += (object sender, EventArgs e) => ShowChild("MDIApp.Form1");
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
