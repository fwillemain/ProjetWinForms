using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private List<Tache> _lstTachesAModifier;

        public FormTachesAnnexes()
        {
            InitializeComponent();
            cbPersonne.SelectionChangeCommitted += CbPersonne_SelectionChangeCommitted;
            dgvTachesAnx.Click += DgvTachesAnx_Click;
            btnEnregistrer.Click += BtnEnregistrer_Click;

            // TODO : gérer l'enregistrement sur la BDD avec le bouton
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            // Désactive le clic sur le btn tant qu'une personne n'a pas été sélectionnée
            if (cbPersonne.SelectedValue == null) return;

            try
            {
                // Enregistrer sur la BDD avec DALLogiciel
                DALActivité.ModifierTachesAnxBDD(_lstTachesAModifier, cbPersonne.SelectedValue.ToString());
                _lstTachesAModifier.Clear();
            }
            catch(SqlException se)
            {
                if (se.Number == 547)
                    MessageBox.Show("Impossible de supprimer les taches annexes : du temps de travail a été saisi.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    throw;
            }
            catch (Exception)
            {
                MessageBox.Show("Impossible de modifier les taches annexes. Contactez l'administrateur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Gérer les exceptions
            }
        }

        private void DgvTachesAnx_Click(object sender, EventArgs e)
        {
            // Désactive le clic sur la dgv tant qu'une personne n'a pas été sélectionnée
            if (cbPersonne.SelectedValue == null) return;

            // Pour toutes les lignes sélectionnées dans la dgv (sélection multiples possible)
            foreach (DataGridViewRow row in dgvTachesAnx.SelectedRows)
            {
                // Cliquer sur une ligne check automatiquement la checkbox associée
                // Indispensable car la dgv est en ReadOnly (voir paramètres dgv)
                row.Cells["CheckedColumn"].Value = row.Cells["CheckedColumn"].Value ?? false;
                row.Cells["CheckedColumn"].Value = !((bool)row.Cells["CheckedColumn"].Value);

                var tache = new Tache()
                {
                    Libellé = row.Cells["Libellé"].Value.ToString(),
                    CodeActivité = row.Cells["CodeActivité"].Value.ToString()
                };

                // si déjà présent dans la liste, la modification est annulée et l'objet retiré de la liste 
                // sinon il est rajouté à la liste
                if (_lstTachesAModifier.Contains(tache))
                    _lstTachesAModifier.Remove(tache);
                else
                    _lstTachesAModifier.Add(tache);
            }
        }

        private void CbPersonne_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string loginSelected = cbPersonne.SelectedValue.ToString();

            // TODO : Gérer le refresh de la dgv
            foreach(DataGridViewRow row in dgvTachesAnx.Rows)
            {
                string codeActivitéCourant = ((DataGridViewCell)row.Cells["CodeActivité"]).Value.ToString();
                bool check = _lstPersonnes.Where(p => p.Login == loginSelected).First().ListTaches.Where(t => t.CodeActivité == codeActivitéCourant).Any();
                ((DataGridViewCheckBoxCell)row.Cells["CheckedColumn"]).Value = check;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            _lstActivitésAnx = DALActivité.GetActivitésAnnexes();
            _lstPersonnes = DALActivité.GetPersonnes();
            _lstTachesAModifier = new List<Tache>();

            cbPersonne.DataSource = _lstPersonnes.OrderBy(p => p.Nom).Select(p => new { NomComplet = p.Nom + " " + p.Prénom, p.Login }).ToList();
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

            dgvTachesAnx.DataSource = _lstActivitésAnx;
            dgvTachesAnx.Columns.Add(checkedColumn);
            #region Paramétrage dgvTachesAnx
            dgvTachesAnx.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTachesAnx.ReadOnly = true;
            dgvTachesAnx.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTachesAnx.Columns["CodeActivité"].Visible = false;
            dgvTachesAnx.AllowDrop = false;
            dgvTachesAnx.AllowUserToAddRows = false;
            dgvTachesAnx.AllowUserToOrderColumns = false;
            dgvTachesAnx.AllowUserToResizeColumns = false;
            dgvTachesAnx.AllowUserToResizeRows = false;
            #endregion

            base.OnLoad(e);
        }
    }
}
