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
        private List<Logiciel> _lstLogiciels;
        private List<Personne> _lstPersonnes;
        private List<TacheProd> _lstTachesProdACréer;

        public FormAjoutTacheProd()
        {
            InitializeComponent();
            cbLogiciel.SelectionChangeCommitted += CbLogiciel_SelectionChangeCommitted;
            cbPersonne.SelectionChangeCommitted += CbPersonne_SelectionChangeCommitted;
            btnValiderCréation.Click += BtnValiderCréation_Click;
            btnSuppr.Click += BtnSuppr_Click;
            btnEnregistrer.Click += BtnEnregistrer_Click;
            btnAnnulerTout.Click += BtnAnnulerTout_Click;
        }

        private void BtnAnnulerTout_Click(object sender, EventArgs e)
        {
            if (_lstTachesProdACréer.Any())
            {
                var result = MessageBox.Show("Souhaitez-vous quitter la fenêtre sans enregistrer?", "Attention", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if (_lstTachesProdACréer.Any())
                DALActivité.AjoutTachesProdSansTravailBDD(_lstTachesProdACréer);

            _lstTachesProdACréer.Clear();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnSuppr_Click(object sender, EventArgs e)
        {
            if (lbTachesValidées.SelectedItem == null) return;

            _lstTachesProdACréer.Remove((TacheProd)lbTachesValidées.SelectedItem);

            lbTachesValidées.DataSource = null;
            lbTachesValidées.DataSource = _lstTachesProdACréer;
            lbTachesValidées.DisplayMember = "Libelle";
        }

        private void BtnAnnulerCréation_Click(object sender, EventArgs e)
        {

        }

        private void BtnValiderCréation_Click(object sender, EventArgs e)
        {
            if (cbLogiciel.SelectedItem == null || cbModule.SelectedItem == null ||
                cbPersonne.SelectedItem == null || cbVersion.SelectedItem == null || cbActivité.SelectedItem == null) return;

            if (string.IsNullOrEmpty(mtbDuréePrev.Text) || string.IsNullOrEmpty(mtbDuréeRestEst.Text) || string.IsNullOrEmpty(tbLibellé.Text))
            {
                MessageBox.Show("Veuillez bien renseigner tous les champs obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            _lstTachesProdACréer.Add(tp);

            lbTachesValidées.DataSource = null;
            lbTachesValidées.DataSource = _lstTachesProdACréer;
            lbTachesValidées.DisplayMember = "Libelle";
        }
        private void CbPersonne_SelectionChangeCommitted(object sender, EventArgs e)
        {
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
            cbVersion.DataSource = _lstLogiciels.Where(l => l.CodeLogiciel == cbLogiciel.SelectedValue.ToString())
                                                .Select(l => l.ListVersions).First()
                                                .Select(v => v.NumeroVersion).ToList();
            #region Paramétrage cbVersion
            cbVersion.SelectedItem = null;
            #endregion

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
            _lstLogiciels = DALLogiciel.GetLogiciels();
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
