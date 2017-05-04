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
    public partial class FormLogiciel : Form
    {
        private List<Logiciel> _lstLogiciels;
        private Logiciel _logCourant;

        public FormLogiciel()
        {
            InitializeComponent();

            cmbLogiciel.SelectionChangeCommitted += CmbLogiciel_SelectionChangeCommitted;
            btnSupprVersion.Click += BtnSupprVersion_Click;
            btnAjoutVersion.Click += BtnAjoutVersion_Click;
        }

        private void BtnAjoutVersion_Click(object sender, EventArgs e)
        {
            if (cmbLogiciel.SelectedItem == null) return;

            using (var form = new FormAjoutVersion())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    // TODO : tester si les versions ont des taches de prod associées avant de les supprimer
                    try
                    {
                        DALLogiciel.AjouterVersionBDD(form.VersionAAjouter, cmbLogiciel.SelectedValue.ToString());
                        _logCourant.ListVersions.Add(form.VersionAAjouter);
                        MiseAJourUI();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("L'ajout de la version a échoué. Contacter l'administrateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnSupprVersion_Click(object sender, EventArgs e)
        {
            if (cmbLogiciel.SelectedItem == null) return;

            var result = MessageBox.Show("Souhaitez-vous réellement supprimer les versions seléctionnées?", "Suppression", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in dgvVersion.SelectedRows)
                    {
                        DALLogiciel.SupprimerVersion(cmbLogiciel.SelectedValue.ToString(), (float)row.Cells["NumeroVersion"].Value);
                        MiseAJourUI();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("La suppression a échoué. Contacter l'administrateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CmbLogiciel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MiseAJourUI();
        }

        private void MiseAJourUI()
        {
            _lstLogiciels = DALLogiciel.GetLogiciels();

            string codeLogSelect = cmbLogiciel.SelectedValue.ToString();
            _logCourant = _lstLogiciels.Where(l => l.CodeLogiciel == codeLogSelect).First();

            lbModule.DataSource = _logCourant.ListModules.Select(m => m.LibelléModule).ToList();
            dgvVersion.DataSource = _logCourant.ListVersions
                                             .Select(v => new { v.NumeroVersion, v.ListReleases.Last().NumeroRelease })
                                             .Distinct().ToList();
            dgvVersion.Refresh();
        }

        protected override void OnLoad(EventArgs e)
        {
            _lstLogiciels = DALLogiciel.GetLogiciels();

            cmbLogiciel.DataSource = _lstLogiciels.Select(l => new { l.NomLogiciel, l.CodeLogiciel }).ToList();
            #region Paramétrage cmbLogiciel
            cmbLogiciel.DisplayMember = "NomLogiciel";
            cmbLogiciel.ValueMember = "CodeLogiciel";
            cmbLogiciel.SelectedItem = null;
            cmbLogiciel.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            #region Paramétrage dgvVersion
            dgvVersion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVersion.AllowDrop = false;
            dgvVersion.AllowUserToAddRows = false;
            dgvVersion.AllowUserToDeleteRows = false;
            dgvVersion.AllowUserToOrderColumns = false;
            dgvVersion.AllowUserToResizeColumns = false;
            dgvVersion.AllowUserToResizeRows = false;
            dgvVersion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            #endregion

            base.OnLoad(e);
        }

    }
}
