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
        #region Méthodes publiques
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

        public static void AjoutTachesProdFromXml(List<TacheProd> listTachesProd)
        {
            string req = @"Insert jo.Tache(IdTache, Libelle, Annexe, CodeActivite, Login)                                                                                                 
                            select IdTache, Libelle, Annexe, CodeActivite, Login from  @table;

                             Insert jo.TacheProd (IdTache, DureePrevue, DureeRestanteEstimee, CodeModule, CodeLogicieModule, NumeroVersion, CodeLogicielVersion)
                            select IdTache, DureePrevue, DureeRestanteEstimee, CodeModule, CodeLogicieModule, NumeroVersion, CodeLogicielVersion from @table;
 
                            Insert jo.Travail(IdTache, DateTravail, Heures, TauxProductivite)
                            select IdTache, DateTravail, Heures, TauxProductivite from @table";




            var param = new SqlParameter("@table", SqlDbType.Structured);

            DataTable tableProd = GetDataTableForTachesProd(listTachesProd);
            param.TypeName = "TypeTableTachesProd2";

            param.Value = tableProd;


            using (var cnx = new SqlConnection(Settings.Default.JobOverviewConnectionString))
            {
                cnx.Open();
                SqlTransaction tran = cnx.BeginTransaction();

                try
                {
                    var command = new SqlCommand(req, cnx, tran);
                    command.Parameters.Add(param);
                    command.ExecuteNonQuery();


                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        #endregion


        #region Méthodes privées
        private static DataTable GetDataTableForTachesProd(List<TacheProd> listTachesProd)
        {

            // Créaton d'une table mémoire
            DataTable table = new DataTable();

            #region Création des colonnes 

            var colIdTache = new DataColumn("IdTache", typeof(Guid));
            colIdTache.AllowDBNull = false;
            table.Columns.Add(colIdTache);
            var colDureePrevue = new DataColumn("DureePrevue", typeof(float));
            colDureePrevue.AllowDBNull = false;
            table.Columns.Add(colDureePrevue);
            var colDureeRestanteEstimee = new DataColumn("DureeRestanteEstimee", typeof(float));
            colDureeRestanteEstimee.AllowDBNull = false;
            table.Columns.Add(colDureeRestanteEstimee);
            var colCodeModule = new DataColumn("CodeModule", typeof(string));
            colCodeModule.AllowDBNull = false;
            table.Columns.Add(colCodeModule);
            var colCodeLogicieModule = new DataColumn("CodeLogicieModule", typeof(string));
            colCodeLogicieModule.AllowDBNull = false;
            table.Columns.Add(colCodeLogicieModule);
            var colNumeroVersion = new DataColumn("NumeroVersion", typeof(float));
            colNumeroVersion.AllowDBNull = false;
            table.Columns.Add(colNumeroVersion);
            var colCodeLogicielVersion = new DataColumn("CodeLogicielVersion", typeof(string));
            colCodeLogicielVersion.AllowDBNull = false;
            table.Columns.Add(colCodeLogicielVersion);


            var colLibelle = new DataColumn("Libelle", typeof(string));
            colLibelle.AllowDBNull = false;
            table.Columns.Add(colLibelle);
            var colAnnexe = new DataColumn("Annexe", typeof(bool));
            colAnnexe.AllowDBNull = false;
            table.Columns.Add(colAnnexe);
            var colCodeActivite = new DataColumn("CodeActivite", typeof(string));
            colCodeActivite.AllowDBNull = false;
            table.Columns.Add(colCodeActivite);
            var colLogin = new DataColumn("Login", typeof(string));
            colLogin.AllowDBNull = false;
            table.Columns.Add(colLogin);

            var colDateTravail = new DataColumn("DateTravail", typeof(DateTime));
            colDateTravail.AllowDBNull = false;
            table.Columns.Add(colDateTravail);
            var colHeures = new DataColumn("Heures", typeof(float));
            colHeures.AllowDBNull = false;
            table.Columns.Add(colHeures);
            var colTauxProductivite = new DataColumn("TauxProductivite", typeof(float));
            colTauxProductivite.AllowDBNull = false;
            table.Columns.Add(colTauxProductivite);


            #endregion

            foreach (var p in listTachesProd)
            {
                foreach (var t in p.Travaux)
                {
                    #region Création d'une ligne de table
                    DataRow ligne = table.NewRow();

                    ligne["IdTache"] = Guid.NewGuid();

                    ligne["DureePrevue"] = p.DureePrev;
                    ligne["DureeRestanteEstimee"] = p.DureeRest;
                    ligne["CodeModule"] = p.Module;
                    ligne["CodeLogicieModule"] = p.Logiciel;
                    ligne["NumeroVersion"] = p.Version;
                    ligne["CodeLogicielVersion"] = p.Logiciel;
                    ligne["Libelle"] = p.Libelle;
                    ligne["Annexe"] = false;
                    ligne["CodeActivite"] = p.Activite;
                    ligne["Login"] = p.Personne;

                    ligne["DateTravail"] = t.Date;
                    ligne["Heures"] = t.Heures;
                    ligne["TauxProductivite"] = t.Heures;

                    #endregion

                    // Ajout de la ligne dans la table
                    table.Rows.Add(ligne);
                }
            }
            return table;
        }
        #endregion
    }

}


