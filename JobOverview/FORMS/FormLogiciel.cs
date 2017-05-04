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
        public FormLogiciel()
        {
            InitializeComponent();

            cmbLogiciel.SelectionChangeCommitted += CmbLogiciel_SelectionChangeCommitted;
            btnSupprVersion.Click += BtnSupprVersion_Click;
            btnAjoutVersion.Click += BtnAjoutVersion_Click;

            // TODO : ajouter les boutons pour créer/supprimer les versions
        }

        private void BtnAjoutVersion_Click(object sender, EventArgs e)
        {
            if (cmbLogiciel.SelectedItem == null) return;

            // TODO : implémenter le Bouton +
        }

        private void BtnSupprVersion_Click(object sender, EventArgs e)
        {
            if (cmbLogiciel.SelectedItem == null) return;

            var result = MessageBox.Show("Souhaitez-vous réellement supprimer les versions seléctionnées?", "Suppression", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                foreach (var row in dgvVersion.SelectedRows)
                {


                    //  DALLogiciel.SupprimerVersion();
                }
            }
        }

        private void CmbLogiciel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string codeLogSelect = cmbLogiciel.SelectedValue.ToString();
            // TODO : faire le select
            var logSelect = _lstLogiciels.Where(l => l.CodeLogiciel == codeLogSelect).First();

            lbModule.DataSource = logSelect.ListModules.Select(m => m.LibelléModule).ToList();
            dgvVersion.DataSource = logSelect.ListVersions
                                        .Select(v => new { v.NumeroVersion, v.ListReleases.Last().NumeroRelease })
                                        .Distinct().ToList();
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


            base.OnLoad(e);
        }

    }
}
