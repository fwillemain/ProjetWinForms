using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobOverview
{
    public partial class FormTachesProduction : Form
    {

        public FormTachesProduction()
        {
            InitializeComponent();
            btnAjout.Click += BtnAjout_Click;
            btnSuppr.Click += BtnSuppr_Click;
            //TODO: Faire afficher la sélection de personne et version dans la dgv
        }

        private void BtnSuppr_Click(object sender, EventArgs e)
        {
            //TODO: Faire Implémentation du bouton suppr
        }

        private void BtnAjout_Click(object sender, EventArgs e)
        {
            using (FormSaisieTachesProd form = new FormSaisieTachesProd())
            {
                //  TODO: Faire Implémentation en récupérant le dialogResult de SaisieTacheProd;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            //TODO : faire les méthodes dans DALTaches Prod pour afficher par la liste dans les cmb au chargement
            //cmbPersonnes =DALTachesProd. ;
            // cmbVersion =DALTachesProd.;

            base.OnLoad(e); 
        }
    }
}
