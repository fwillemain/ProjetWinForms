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
        }

        protected override void OnLoad(EventArgs e)
        {
            _lstActivitésAnx = DALLogiciel.GetActivitésAnnexes();
            // TODO : récupérer listePersonne

            //cbPersonne.DataSource = _
            #region Paramétrage cmbLogiciel
            // TODO : finir param
            //cbPersonne.DisplayMember = ;
            //cbPersonne.ValueMember = ;
            cbPersonne.SelectedItem = null;
            cbPersonne.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion


            base.OnLoad(e);
        }
    }
}
