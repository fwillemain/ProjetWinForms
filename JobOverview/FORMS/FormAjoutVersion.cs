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
    public partial class FormAjoutVersion : Form
    {
        public Version VersionAAjouter { get; set; }
        public FormAjoutVersion()
        {
            InitializeComponent();
            
        }

        protected override void OnLoad(EventArgs e)
        {
            this.ControlBox = false;
            this.AcceptButton = btnValider;
            this.CancelButton = btnAnnuler;

            btnValider.DialogResult = DialogResult.Yes;
            btnAnnuler.DialogResult = DialogResult.Cancel;

            base.OnLoad(e); 
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if(this.DialogResult == DialogResult.Yes)
            {
                float tmp;

                if (!float.TryParse(mtbNumero.Text, out tmp) || string.IsNullOrEmpty(mtbMillesime.Text))
                {
                    MessageBox.Show("Numéro de version ou millesime manquant, impossible de créer la version.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                    mtbNumero.Clear();
                    mtbMillesime.Clear();
                }
                else
                {
                    VersionAAjouter = new Version()
                    {
                        NumeroVersion = float.Parse(mtbNumero.Text),
                        Millésime = short.Parse(mtbMillesime.Text),
                        DateOuverture = dtpDateOuverture.Value,
                        DateSortiePrévue = dtpDateSortiePrevue.Value,
                        ListReleases = new List<Release>()
                    };
                    VersionAAjouter.ListReleases.Add(new Release() { NumeroRelease = 1, DateSetup = dtpDateOuverture.Value });
                }
            }
            base.OnClosing(e);
        }

    }
}
