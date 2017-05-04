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

        }

        private void CmbLogiciel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string codeSelect = cmbLogiciel.SelectedValue.ToString();
            // TODO : faire le select
            dgvVersion.DataSource = _lstLogiciels.Where(l => l.Code == codeSelect);
        }

        protected override void OnLoad(EventArgs e)
        {
            // TODO OnLoad() : charger contenu comboBox
            _lstLogiciels = DALLogiciel.GetLogiciels();

            cmbLogiciel.DataSource = _lstLogiciels.Select(l => new { l.Nom, l.Code }).ToList();
            #region Paramétrage cmbLogiciel
            cmbLogiciel.DisplayMember = "Nom";
            cmbLogiciel.ValueMember = "Code";
            cmbLogiciel.SelectedItem = null;
            cmbLogiciel.DropDownStyle = ComboBoxStyle.DropDownList; 
            #endregion

            base.OnLoad(e);
        }

    }
}
