using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class Tache
    {
        public string Libellé { get; set; }
        public string CodeActivité { get; set; }
        // TODO : voir comment faire hériter TachesProduction de Tache sans faire buger le XMLSerializer
    }
}
