using JobOverview.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JobOverview
{
    public static class DALXmlcs
    {


        public static void ExporterXml(List<TacheProd> listprod)
        {
            XmlSerializer serialiser = new XmlSerializer(typeof(List<TacheProd>), new XmlRootAttribute("TachesProduction"));
            using (var s = new StreamWriter(@"..\..\TachesProd.xml"))
            {
                serialiser.Serialize(s, listprod);
            }
        }

        public static List<TacheProd> Importerfichier()
        {
            List<TacheProd> listprod = null;

            XmlSerializer deserialiser = new XmlSerializer(typeof(List<TacheProd>), new XmlRootAttribute("TachesProduction"));

            using (var stream = new StreamReader(@"..\..\TachesProd.xml"))
            {
                listprod = ((List<TacheProd>)deserialiser.Deserialize(stream));
            }

            return listprod;
        }
        

       
    }

}


