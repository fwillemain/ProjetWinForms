using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace JobOverview
{
    public partial class FormConfig : Form
    {

        public FormConfig()
        {
            InitializeComponent();
            btnOk.Click += (object sender, EventArgs e) =>
                {
                    if (cbChaineCnx.SelectedValue == null) return;

                    var prop = new SettingsProperty("SelectedConnexionString");
                    prop.DefaultValue = cbChaineCnx.SelectedValue.ToString();
                    Properties.Settings.Default.Properties.Add(prop);

                    Close();
                };
        }

        protected override void OnLoad(EventArgs e)
        {
            this.ControlBox = false;

            List<object> lstCnxString = new List<object>();

            foreach(SettingsProperty p in Properties.Settings.Default.Properties)
            {
                if (p.Name.Contains("JobOverviewConnectionString"))
                    lstCnxString.Add(new { p.Name, p.DefaultValue });
            }

            cbChaineCnx.DataSource = lstCnxString;
            #region Paramétrage de cbChaineCnx
            cbChaineCnx.DisplayMember = "Name";
            cbChaineCnx.ValueMember = "DefaultValue";
            cbChaineCnx.SelectedItem = null;
            cbChaineCnx.DropDownStyle = ComboBoxStyle.DropDownList; 
            #endregion

            base.OnLoad(e);
        }
    }
}
