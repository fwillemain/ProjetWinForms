using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class Personne
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prénom { get; set; }
        public Métier Métier { get; set; }
        public List<Tache> listTaches { get; set; }
    }
}
