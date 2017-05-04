using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JobOverview
{
    public static class DALLogiciel
    {

        #region Méthodes Publiques
        public static List<Logiciel> GetLogiciels()
        {
            List<Logiciel> listLog = new List<Logiciel>();

            var conx = new SqlConnection(Properties.Settings.Default.JobOverviewConnectionString);

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

        public static void SupprimerVersion(string codeLogiciel, string codeModule, float numeroVersion)
        {
            SqlConnection connexion = new SqlConnection(Properties.Settings.Default.JobOverviewConnectionString);

            connexion.Open();
            var tran = connexion.BeginTransaction();

            string query = @"";

        }

        #endregion

        #region Méthodes Privées
        private static void GetLogicielsFromDataReader(SqlDataReader reader, List<Logiciel> listLog)
        {
            while (reader.Read())
            {
                if (listLog.Any() || !listLog.Where(l => l.CodeLogiciel == reader["CodeLogiciel"].ToString()).Any())
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

                if (!listLog.Last().ListVersions.Where(m => m.NumeroVersion == (float) reader["NumeroVersion"]).Any())
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
        #endregion
    }
}
