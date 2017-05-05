using System;
using System.Collections.Generic;

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
        public List<Tache> ListTaches { get; set; }
    }
}