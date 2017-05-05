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
            btnOk.Click += BtnOk_Click;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            // Desactive le bouton tant qu'une chaine de connexion n'a pas été choisie
            if (cbChaineCnx.SelectedValue == null) return;

            // Créé une propriété "SelectedConnexionString" dans les params appli avec comme
            // valeur celle de la chaine de connexion sélectionnée
            var prop = new SettingsProperty("SelectedConnexionString");
            prop.DefaultValue = cbChaineCnx.SelectedValue.ToString();
            Properties.Settings.Default.Properties.Add(prop);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            List<object> lstCnxString = new List<object>();

            // Affiche toutes les chaines de connexion au format "JobOverviewConnectionStringXXX" dans la cb
            foreach (SettingsProperty p in Properties.Settings.Default.Properties)
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
