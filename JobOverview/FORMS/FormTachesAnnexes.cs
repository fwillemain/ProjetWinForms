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
        private List<TacheProd>

        public FormTachesAnnexes()
        {
            InitializeComponent();
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
