using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using JobOverview.Properties;
using System.Configuration;

namespace JobOverview
{

    public static class DALLogiciel
    {
        #region Champs Privé
        static private string _chaineConnexion;
        #endregion

        #region Constructeur
        static DALLogiciel()
        {
            foreach (SettingsProperty prop in Properties.Settings.Default.Properties)
                if (prop.Name == "SelectedConnexionString")
                    _chaineConnexion = prop.DefaultValue.ToString();
        }
        #endregion

        #region Méthodes Publiques
        public static List<Logiciel> GetLogiciels()
        {
            //Requêtage à la BDD pour récupérer les informations sur les logiciels
            List<Logiciel> listLog = new List<Logiciel>();

            var conx = new SqlConnection(_chaineConnexion);

            string query = @"select l.CodeLogiciel, l.Nom, m.CodeModule, m.Libelle, m.CodeModuleParent,
                                        v.NumeroVersion, v.Millesime, v.DateOuverture, v.DateSortiePrevue, v.DateSortieReelle,
					                    r.NumeroRelease, r.DateSetup
                            from jo.Logiciel l
                            inner join jo.Module m on l.CodeLogiciel = m.CodeLogiciel
                            inner join jo.Version v on l.CodeLogiciel = v.CodeLogiciel
                            inner join jo.Release r on v.NumeroVersion = r.NumeroVersion
                            order by l.CodeLogiciel, m.CodeModule, v.NumeroVersion, r.NumeroRelease";

            var com = new SqlCommand(query, conx);
            conx.Open();

            using (SqlDataReader reader = com.ExecuteReader())
            {
                GetLogicielsFromDataReader(reader, listLog);
            }

            return listLog;
        }

        public static void AjouterVersionBDD(Version version, string codeLogiciel)
        {
            //Insertion en masse de versions dans la BDD
            SqlConnection connexion = new SqlConnection(_chaineConnexion);

            connexion.Open();
            var tran = connexion.BeginTransaction();

            string query = @"insert jo.Version(NumeroVersion, CodeLogiciel, Millesime, DateOuverture, DateSortiePrevue)
                             values(@NumeroVersion, @CodeLogiciel, @Millesime, @DateOuverture, @DateSortiePrevue);
                             
                            insert jo.Release(NumeroRelease, NumeroVersion, CodeLogiciel, DateSetup)
                            values(@NumeroRelease, @NumeroVersion, @CodeLogiciel, @DateSetup)";


            var command1 = new SqlCommand(query, connexion, tran);
            command1.Parameters.Add(new SqlParameter("@NumeroVersion", DbType.Double));
            command1.Parameters["@NumeroVersion"].Value = version.NumeroVersion;

            command1.Parameters.Add(new SqlParameter("@CodeLogiciel", DbType.String));
            command1.Parameters["@CodeLogiciel"].Value = codeLogiciel;

            command1.Parameters.Add(new SqlParameter("@Millesime", DbType.Int16));
            command1.Parameters["@Millesime"].Value = version.Millésime;

            command1.Parameters.Add(new SqlParameter("@DateOuverture", DbType.Date));
            command1.Parameters["@DateOuverture"].Value = version.DateOuverture;

            command1.Parameters.Add(new SqlParameter("@DateSortiePrevue", DbType.Date));
            command1.Parameters["@DateSortiePrevue"].Value = version.DateSortiePrévue;

            command1.Parameters.Add(new SqlParameter("@NumeroRelease", DbType.Int16));
            command1.Parameters["@NumeroRelease"].Value = version.ListReleases.First().NumeroRelease;

            command1.Parameters.Add(new SqlParameter("@DateSetup", DbType.Date));
            command1.Parameters["@DateSetup"].Value = version.ListReleases.First().DateSetup;

            try
            {
                command1.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception)
            {
                tran.Rollback();
                throw;
            }

        }

        public static void SupprimerVersionBDD(string codeLogiciel, float numeroVersion)
        {
            //Suppression en masse de versions dans la BDD
            SqlConnection connexion = new SqlConnection(_chaineConnexion);

            connexion.Open();
            var tran = connexion.BeginTransaction();

            string query = @"delete from jo.Release
                              from jo.Release
                              where NumeroVersion = @NumeroVersion and CodeLogiciel = @CodeLogiciel;
                              
                              delete from jo.Version
                              from jo.Version
                              where NumeroVersion = @NumeroVersion and CodeLogiciel = @CodeLogiciel";

            var param1 = new SqlParameter("@NumeroVersion", DbType.Double);
            param1.Value = numeroVersion;

            var param2 = new SqlParameter("@CodeLogiciel", DbType.String);
            param2.Value = codeLogiciel;

            var command1 = new SqlCommand(query, connexion, tran);
            command1.Parameters.Add(param1);
            command1.Parameters.Add(param2);

            try
            {
                command1.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception)
            {
                tran.Rollback();
                throw;
            }

        }

     

                       
        public static List<Version> GetVersion()
        {
            //Requêtage à la BDD pour récupérer les informations sur les Versions
            List<Version> listvers = new List<Version>();

            var conx = new SqlConnection(_chaineConnexion);

            string query = @"Select NumeroVersion, Millesime, DateOuverture, DateSortiePrevue, DateSortieReelle from jo.Version";

            var com = new SqlCommand(query, conx);
            conx.Open();

            using (SqlDataReader reader = com.ExecuteReader())
            {

                GetVersionFromDataReader(reader, listvers);
            }

            return listvers;
        }

        #endregion

        #region Méthodes Privées
        private static void GetLogicielsFromDataReader(SqlDataReader reader, List<Logiciel> listLog)
        {
            while (reader.Read())
            {
                if (!listLog.Any() || !listLog.Where(l => l.CodeLogiciel == reader["CodeLogiciel"].ToString()).Any())
                {
                    // Création d'un logiciel
                    Logiciel log = new Logiciel()
                    {
                        ListModules = new List<Module>(),
                        ListVersions = new List<Version>()
                    };

                    log.CodeLogiciel = reader["CodeLogiciel"].ToString();
                    log.NomLogiciel = reader["Nom"].ToString();

                    listLog.Add(log);
                }

                if (!listLog.Last().ListModules.Where(m => m.CodeModule == reader["CodeModule"].ToString()).Any())
                {
                    // Création d'un module
                    Module mod = new Module();

                    mod.CodeModule = reader["CodeModule"].ToString();
                    mod.LibelléModule = reader["Libelle"].ToString();

                    listLog.Last().ListModules.Add(mod);
                }

                if (!listLog.Last().ListVersions.Where(m => m.NumeroVersion == (float)reader["NumeroVersion"]).Any())
                {
                    // Création d'une version
                    Version vers = new Version() { ListReleases = new List<Release>() };
                    vers.NumeroVersion = (float)reader["NumeroVersion"];
                    vers.Millésime = (short)reader["Millesime"];
                    vers.DateOuverture = (DateTime)reader["DateOuverture"];
                    vers.DateSortiePrévue = (DateTime)reader["DateSortiePrevue"];

                    if (reader["DateSortieReelle"] != DBNull.Value)
                        vers.DateSortieRéelle = (DateTime)reader["DateSortieReelle"];

                    listLog.Last().ListVersions.Add(vers);
                }

                Release rel = new Release();
                rel.NumeroRelease = (short)reader["NumeroRelease"];
                rel.DateSetup = (DateTime)reader["DateSetup"];

                listLog.Last().ListVersions.Last().ListReleases.Add(rel);
            }
        }



        private static void GetVersionFromDataReader(SqlDataReader reader, List<Version> listVersion)
        {
            while (reader.Read())
            {
                Version vers = new Version();

                vers.NumeroVersion = (float)reader["NumeroVersion"];
                vers.Millésime = (short)reader["Millesime"];
                vers.DateOuverture = (DateTime)reader["DateOuverture"];
                vers.DateSortiePrévue = (DateTime)reader["DateSortiePrevue"];
                if (reader["DateSortieReelle"] != DBNull.Value)
                    vers.DateSortieRéelle = (DateTime)reader["DateSortieReelle"];



                listVersion.Add(vers);
            }
        }

        #endregion







    }
}
