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
    public partial class FormTachesAnnexes : Form
    {
        private List<Activité> _lstActivitésAnx;
        private List<Personne> _lstPersonnes;

        public FormTachesAnnexes()
        {
            InitializeComponent();
            cbPersonne.SelectionChangeCommitted += CbPersonne_SelectionChangeCommitted;
            // TODO : gérer la modification des check box avec une liste à modifier (voir FormEmployee sur sln ADO)
        }

        private void CbPersonne_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string loginSelected = cbPersonne.SelectedValue.ToString();

            dgvTachesAnx.DataSource = _lstActivitésAnx;
            dgvTachesAnx.Columns["CodeActivité"].Visible = false;

            // TODO : vérifier le check des box
            foreach(DataGridViewRow row in dgvTachesAnx.Rows)
            {
                string codeActivitéCourant = ((DataGridViewCheckBoxCell)row.Cells["CodeActivité"]).Value.ToString();
                bool check = _lstPersonnes.Where(p => p.Login == loginSelected).First().ListTaches.Where(t => t.CodeActivité == codeActivitéCourant).Any();
                ((DataGridViewCheckBoxCell)row.Cells["CheckedColumn"]).Value = check;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            _lstActivitésAnx = DALLogiciel.GetActivitésAnnexes();
            _lstPersonnes = DALLogiciel.GetPersonnes();
            // TODO : vérifier le remplissage des deux listes

            cbPersonne.DataSource = _lstPersonnes.Select(p => new { NomComplet = p.Nom + " " + p.Prénom, p.Login }).ToList();
            #region Paramétrage cmbLogiciel
            cbPersonne.DisplayMember = "NomComplet";
            cbPersonne.ValueMember = "Login";
            cbPersonne.SelectedItem = null;
            cbPersonne.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            DataGridViewCheckBoxColumn checkedColumn = new DataGridViewCheckBoxColumn()
            {
                Name = "CheckedColumn",
                FalseValue = false,
                TrueValue = true,
                Visible = true
            };
            dgvTachesAnx.Columns.Add(checkedColumn);
            // TODO : finir param

            base.OnLoad(e);
        }
    }
}
