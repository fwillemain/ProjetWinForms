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
    public partial class FormAjoutTacheProd : Form
    {
        // Liste de tous les logiciels dans la BDD
        private List<Logiciel> _lstLogiciels;
        // Liste de toutes les personnes dans la BDD
        private List<Personne> _lstPersonnes;
        // Liste des taches de production qui seront à créer dans la BDD
        private List<TacheProd> _lstTachesProdACréer;

        public FormAjoutTacheProd()
        {
            InitializeComponent();

            cbLogiciel.SelectionChangeCommitted += CbLogiciel_SelectionChangeCommitted;
            cbPersonne.SelectionChangeCommitted += CbPersonne_SelectionChangeCommitted;
            btnValiderCréation.Click += BtnValiderCréation_Click;
            btnSuppr.Click += BtnSuppr_Click;
            btnEnregistrer.Click += BtnEnregistrer_Click;
            btnQuitter.Click += BtnQuitter_Click;
        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            // Si la liste est vide quitter sans message
            if (_lstTachesProdACréer.Any())
            {
                // Sinon proposer d'enregistrer les créations avant de quitter la fenêtre
                var result = MessageBox.Show("Souhaitez-vous enregistrer les taches créées avant de quitter la fenêtre?", "Attention", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                    BtnEnregistrer_Click(sender, null);
            }

            DialogResult = DialogResult.Cancel;
            Close();

        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            // Si il y a des taches à créer lancer la méthode
            if (_lstTachesProdACréer.Any())
            {
                try
                {
                    DALActivité.AjoutTachesProdSansTravailBDD(_lstTachesProdACréer);
                    _lstTachesProdACréer.Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Impossible de créer les taches de productions", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // TODO : mieux gérer les exceptions et l'affichage
                }
            }
        }

        private void BtnSuppr_Click(object sender, EventArgs e)
        {
            // Ne fait rien si aucune tache n'est sélectionnée
            if (lbTachesValidées.SelectedItem == null) return;

            // Retire la tache sélectionnée de la liste
            _lstTachesProdACréer.Remove((TacheProd)lbTachesValidées.SelectedItem);

            // Raffraichi l'affichage de la lb
            lbTachesValidées.DataSource = null;
            lbTachesValidées.DataSource = _lstTachesProdACréer;
            lbTachesValidées.DisplayMember = "Libelle";
        }

        private void BtnValiderCréation_Click(object sender, EventArgs e)
        {
            // Désactive le bouton si toutes les cb n'ont pas été utilisées
            if (cbLogiciel.SelectedItem == null || cbModule.SelectedItem == null ||
                cbPersonne.SelectedItem == null || cbVersion.SelectedItem == null || cbActivité.SelectedItem == null) return;

            // Renvoi un message d'erreur si tous les champs obligatoires ne sont pas renseignés
            if (string.IsNullOrEmpty(mtbDuréePrev.Text) || string.IsNullOrEmpty(mtbDuréeRestEst.Text) || string.IsNullOrEmpty(tbLibellé.Text))
            {
                MessageBox.Show("Veuillez bien renseigner tous les champs obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Création d'une tache prod avec toutes les informations nécessaires
            var tp = new TacheProd()
            {
                Logiciel = cbLogiciel.SelectedValue.ToString(),
                Module = cbModule.SelectedValue.ToString(),
                Personne = cbPersonne.SelectedValue.ToString(),
                Activite = cbActivité.SelectedValue.ToString(),
                Version = (float)cbVersion.SelectedValue,
                Libelle = tbLibellé.Text,
                DureePrev = float.Parse(mtbDuréePrev.Text),
                DureeRest = float.Parse(mtbDuréeRestEst.Text),
                Travaux = new List<Travail>()
            };

            if (!string.IsNullOrEmpty(tbDescription.Text))
                tp.Description = tbDescription.Text;

            // Ajoute la tache à la liste des taches à créer sur la BDD
            _lstTachesProdACréer.Add(tp);

            // Raffraichi l'affichage de la lb
            lbTachesValidées.DataSource = null;
            lbTachesValidées.DataSource = _lstTachesProdACréer;
            lbTachesValidées.DisplayMember = "Libelle";
        }

        private void CbPersonne_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Récupère les activités liés au métier de la personne sélectionnée dans la cb
            cbActivité.DataSource = _lstPersonnes.Where(p => p.Login == cbPersonne.SelectedValue.ToString())
                                                 .Select(p => p.Métier)
                                                 .Select(m => m.ListActivités).First().ToList();

            #region Paramétrage cbActivité
            cbActivité.DisplayMember = "Libellé";
            cbActivité.ValueMember = "CodeActivité";
            cbActivité.SelectedItem = null;
            #endregion
        }

        private void CbLogiciel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Récupère toutes les versions du logiciel sélectionné
            cbVersion.DataSource = _lstLogiciels.Where(l => l.CodeLogiciel == cbLogiciel.SelectedValue.ToString())
                                                .Select(l => l.ListVersions).First()
                                                .Select(v => v.NumeroVersion).ToList();
            #region Paramétrage cbVersion
            cbVersion.SelectedItem = null;
            #endregion

            // Récupère tous les modules du logiciel sélectionné
            cbModule.DataSource = _lstLogiciels.Where(l => l.CodeLogiciel == cbLogiciel.SelectedValue.ToString())
                                                .Select(l => l.ListModules).First();
            #region Paramétrage cbModule
            cbModule.DisplayMember = "LibelléModule";
            cbModule.ValueMember = "CodeModule";
            cbModule.SelectedItem = null;
            #endregion
        }

        protected override void OnLoad(EventArgs e)
        {
            // Initialise les listes             _lstLogiciels = DALLogiciel.GetLogiciels();
            _lstPersonnes = DALActivité.GetPersonnes();
            _lstTachesProdACréer = new List<TacheProd>();

            cbLogiciel.DataSource = _lstLogiciels.Select(l => new { l.NomLogiciel, l.CodeLogiciel }).ToList();
            #region Paramétrage cbLogiciel
            cbLogiciel.DisplayMember = "NomLogiciel";
            cbLogiciel.ValueMember = "CodeLogiciel";
            cbLogiciel.SelectedItem = null;
            cbLogiciel.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            cbPersonne.DataSource = _lstPersonnes.Select(p => new { NomComplet = p.Nom + " " + p.Prénom, p.Login }).ToList();
            #region Paramétrage cbPersonne
            cbPersonne.DisplayMember = "NomComplet";
            cbPersonne.ValueMember = "Login";
            cbPersonne.SelectedItem = null;
            cbPersonne.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            cbActivité.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVersion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbModule.DropDownStyle = ComboBoxStyle.DropDownList;

            base.OnLoad(e);
        }
    }
}
