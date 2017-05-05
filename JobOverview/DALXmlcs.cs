using JobOverview.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        #region Champs Privé
        static private string _chaineConnexion;
        #endregion

        #region Constructeur
        static DALXmlcs()
        {
            foreach (SettingsProperty prop in Properties.Settings.Default.Properties)
                if (prop.Name == "SelectedConnexionString")
                    _chaineConnexion = prop.DefaultValue.ToString();
        }
        #endregion

        #region Méthodes Publiques
        public static void ExporterXml(List<TacheProd> listprod)
        {
            //désérialisation du fichierXMLTachesProd par le serializer
            XmlSerializer serialiser = new XmlSerializer(typeof(List<TacheProd>), new XmlRootAttribute("TachesProduction"));
            using (var s = new StreamWriter(@"..\..\TachesProdBDD.xml"))
            {
                serialiser.Serialize(s, listprod);
            }
        }

        public static List<TacheProd> Importerfichier()
        {
            //sérialisation du fichierXMLTachesProd par le serializer

            List<TacheProd> listprod = null;

            XmlSerializer deserialiser = new XmlSerializer(typeof(List<TacheProd>), new XmlRootAttribute("TachesProduction"));

            using (var stream = new StreamReader(@"..\..\TachesProd.xml"))
            {
                listprod = ((List<TacheProd>)deserialiser.Deserialize(stream));
            }

            return listprod;
        }

        public static List<TacheProd> GetTachesProd()
        {
            //Requêtage sur la BDD des champs relatifs aux tâches de production

            List<TacheProd> listTachesProd = new List<TacheProd>();

            var conx = new SqlConnection(_chaineConnexion);

            string query = @"select Numero, Libelle, CodeActivite, Login, Description, DureePrevue, DureeRestanteEstimee, CodeModule, CodeLogicieModule, NumeroVersion, DateTravail, Heures, TauxProductivite
                            from jo.Tache t
                            inner join jo.TacheProd tp on tp.IdTache= t.IdTache
                            inner join jo.Travail tr on tp.IdTache= tr.IdTache
                            where Annexe =0
                            order by 1";


            var com = new SqlCommand(query, conx);
            conx.Open();

            using (SqlDataReader reader = com.ExecuteReader())
            {

                GetTachesProdFromDataReader(reader, listTachesProd);
            }

            return listTachesProd;
        }
        #endregion

        #region Méthodes Privées
        private static void GetTachesProdFromDataReader(SqlDataReader reader, List<TacheProd> listTachesProd)
        {


            while (reader.Read())
            {
                TacheProd TP = new TacheProd();
                // Travail t = new Travail();

                TP.Numéro = (int)reader["Numero"];
                TP.Libelle = reader["Libelle"].ToString();
                TP.Activite = reader["CodeActivite"].ToString();
                TP.Personne = reader["Login"].ToString();
                if (reader["Description"] != DBNull.Value)
                    TP.Description = reader["DateOuverture"].ToString();
                TP.DureePrev = (float)reader["DureePrevue"];
                TP.DureeRest = (float)reader["DureeRestanteEstimee"];
                TP.Module = reader["CodeLogicieModule"].ToString();
                TP.Logiciel = reader["CodeLogicieModule"].ToString();
                TP.Version = (float)reader["NumeroVersion"];
               

                //TOTO: Pensez à remplir la liste  TP.listTravaux

                //   t.Date = (DateTime)reader["DateTravail"];
                //  t.Heures= (float)reader["Heures"];
                //t.TauxProduct= (float)reader["TauxProductivite"];


                listTachesProd.Add(TP);
            }
        }
        #endregion

    }

}


