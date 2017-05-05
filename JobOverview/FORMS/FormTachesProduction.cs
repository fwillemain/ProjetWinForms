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
        #region Champs privés
        private List<Version> _lstVersions;
        private List<Personne> _lstPersonnes;
        private List<TacheProd> _lstTachesProd;
        private List<TacheProd> _lstTachesProdCourante;
        #endregion

        #region Constructeur
        public FormTachesProduction()
        {
            InitializeComponent();

            cmbVersion.SelectionChangeCommitted += CmbVersion_SelectionChangeCommitted;
            cmbPersonnes.SelectionChangeCommitted += CmbPersonnes_SelectionChangeCommitted;

            btnAjout.Click += BtnAjout_Click;
            btnSuppr.Click += BtnSuppr_Click;
            chkTachesTerm.CheckedChanged += ChkTachesTerm_CheckedChanged;
        }
        #endregion

        #region Méthodes Privées ou Protected

        private void ChkTachesTerm_CheckedChanged(object sender, EventArgs e)
        {
            //Impossibilité de cocher la checkBox s'il n'y a rien d'affiché dans la datagridview
            if (dgvTachesProd.DataSource == null)
            {
                chkTachesTerm.Checked = true;
                return;
            }

            //Affichage des tâches terminées dans le datagridview si la checkBox est cochée 
            //et des tâches non terminées dans le datagridview si la checkBox n'est pas cochée
            if (chkTachesTerm.Checked == true)
            {
                dgvTachesProd.DataSource = _lstTachesProdCourante.Where(t => t.DureeRest == 0).ToList();
            }
            else
                dgvTachesProd.DataSource = _lstTachesProdCourante.Where(t => t.DureeRest != 0).ToList();
        }

        private void CmbPersonnes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Affichage des taches de production dans la datagridview filtrées en fonction de la sélection de la personne et/ou de la version
            if (cmbVersion.SelectedItem == null)
                _lstTachesProdCourante = _lstTachesProd
                                         .Where(t => t.Personne.Equals(cmbPersonnes.SelectedValue.ToString())).ToList();
            else
                _lstTachesProdCourante = _lstTachesProd.Where(t => (t.Version == (float)cmbVersion.SelectedValue) && (t.Personne.Equals(cmbPersonnes.SelectedValue.ToString()))).ToList();
            dgvTachesProd.DataSource = _lstTachesProdCourante;

            ConfigDGV();

            //Affichage des tâches terminées ou non terminées dès le 1er filtrage des personnes
            ChkTachesTerm_CheckedChanged(sender, null);

        }

        private void CmbVersion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Affichage des taches de production dans la datagridview filtrées en fonction de la sélection de la version et/ ou de la personne 
            if (cmbPersonnes.SelectedItem == null)
                _lstTachesProdCourante = _lstTachesProd
                                        .Where(t => t.Version == (float)cmbVersion.SelectedValue).ToList();
            else
                _lstTachesProdCourante = _lstTachesProd
                                        .Where(t => t.Version == (float)cmbVersion.SelectedValue && t.Personne.Equals(cmbPersonnes.SelectedValue.ToString())).ToList();

            dgvTachesProd.DataSource = _lstTachesProdCourante;

            ConfigDGV();

            //Affichage des tâches terminées ou non terminées dès le 1er filtrage des versions
            ChkTachesTerm_CheckedChanged(sender, null);

        }

        private void ConfigDGV()
        {
            //Paramétrage des colonnes de la datagridview
            dgvTachesProd.Columns["Numéro"].DisplayIndex = 0;
            dgvTachesProd.Columns["Personne"].Visible = false;
            dgvTachesProd.Columns["Version"].Visible = false;
            dgvTachesProd.Columns["DureeRest"].Visible = false;
        }

        private void BtnSuppr_Click(object sender, EventArgs e)
        {
            //TODO: Faire Implémentation du bouton suppr
        }

        private void BtnAjout_Click(object sender, EventArgs e)
        {
            using (FormAjoutTacheProd formATP = new FormAjoutTacheProd())
            {
                //  TODO: Faire Implémentation en récupérant le dialogResult de SaisieTacheProd;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            // Affichage des listes personnes et version dans les comboBox au chargement de la fenêtre
            _lstPersonnes = DALLogiciel.GetPersonnes();
            _lstVersions = DALLogiciel.GetVersion();
            _lstTachesProd = DALXmlcs.GetTachesProd();

            cmbPersonnes.DataSource = _lstPersonnes.Select(p => p.Login).Distinct().ToList();
            cmbPersonnes.SelectedItem = null;

            cmbVersion.DataSource = _lstVersions.Select(v => v.NumeroVersion).ToList();
            cmbVersion.SelectedItem = null;

            base.OnLoad(e);
        }
        #endregion
    }
}


