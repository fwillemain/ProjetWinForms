using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JobOverview
{
    public class DALLogiciel
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

        jjj

        #endregion

        #region Méthodes Privées
        private static void GetLogicielsFromDataReader(SqlDataReader reader, List<Logiciel> listLog)
        {
            string codeLogCourant = string.Empty;
            string codeModuleCourant = string.Empty;
            float numVersionCourante = -1;

            while (reader.Read())
            {
                if (codeLogCourant != reader["CodeLogiciel"].ToString())
                {
                    // Création d'un logiciel
                    Logiciel log = new Logiciel()
                    {
                        ListModules = new List<Module>()
                    };

                    log.Code = reader["CodeLogiciel"].ToString();
                    log.Nom = reader["Nom"].ToString();

                    codeLogCourant = log.Code;

                    listLog.Add(log);
                }

                if (codeModuleCourant != reader["CodeModule"].ToString())
                {
                    // Création d'un module
                    Module mod = new Module()
                    {
                        ListSousModules = new List<Module>(),
                        ListVersions = new List<Version>()
                    };
                    mod.Code = reader["CodeModule"].ToString();
                    mod.Libellé = reader["Libelle"].ToString();

                    // TODO : voir pour liste SousModule (Flo)

                    codeModuleCourant = mod.Code;
                    listLog.Last().ListModules.Add(mod);
                }

                if (numVersionCourante != (float)reader["NumeroVersion"])
                {
                    // Création d'une version
                    Version vers = new Version() { ListReleases = new List<Release>() };
                    vers.Numero = (float)reader["NumeroVersion"];
                    vers.Millésime = (short)reader["Millesime"];
                    vers.DateOuverture = (DateTime)reader["DateOuverture"];
                    vers.DateSortiePrévue = (DateTime)reader["DateSortiePrevue"];

                    if (reader["DateSortieReelle"] != DBNull.Value)
                        vers.DateSortieRéelle = (DateTime)reader["DateSortieReelle"];

                    numVersionCourante = vers.Numero;
                    listLog.Last().ListModules.Last().ListVersions.Add(vers);
                }

                Release rel = new Release();
                rel.Numero = (short)reader["NumeroRelease"];
                rel.DateSetup = (DateTime)reader["DateSetup"];

                listLog.Last().ListModules.Last().ListVersions.Last().ListReleases.Add(rel);
            }
        }
        #endregion
    }
}
