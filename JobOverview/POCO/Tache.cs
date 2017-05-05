using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JobOverview
{
    public class Tache
    {
        public string Libellé { get; set; }
        public string CodeActivité { get; set; }
        [XmlIgnore]
        public string Description { get; set; }

    }
}
