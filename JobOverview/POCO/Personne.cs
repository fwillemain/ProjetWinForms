using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class Personne
    {
        public string Login { get; set; }
        public string Nom { get; set; }
        public string Prénom { get; set; }
        public Métier Métier { get; set; }
        public string LoginManager { get; set; }
        public float TauxProductivité { get; set; }
        List<Tache> ListTaches { get; set; }
    }
}
