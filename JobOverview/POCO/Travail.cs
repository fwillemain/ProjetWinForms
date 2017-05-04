using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JobOverview
{
   public class Travail
    {
        [XmlAttribute]
        public DateTime Date { get; set; }
        [XmlAttribute]
        public float Heures { get; set; }
        [XmlAttribute]
        public float TauxProduct { get; set; }
    }
}
