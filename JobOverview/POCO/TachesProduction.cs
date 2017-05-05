using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JobOverview
{
    public class TacheProd
    {
        [XmlAttribute]
        public string Libelle { get; set; }
        [XmlAttribute]
        public string Activite { get; set; }
        [XmlAttribute]
        public string Personne { get; set; }
        [XmlIgnore]
        public string Description { get; set; }
        [XmlIgnore]
        public int Numéro { get; set; }
        [XmlAttribute]
        public float DureePrev { get; set; }
        [XmlAttribute]
        public float DureeRest { get; set; }
        [XmlAttribute]
        public string Logiciel { get; set; }
        [XmlAttribute]
        public string Module { get; set; }
        [XmlAttribute]
        public float Version { get; set; }
        public List<Travail> listTravaux { get; set; }
    }
}
