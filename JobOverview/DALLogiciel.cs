﻿using System;
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
            catch (Exception e)
            {
                tran.Rollback();
                throw;
            }

        }

        public static void AjoutTachesProdSansTravailBDD(List<TacheProd> listTachesProd)
        {
            string req = @"Insert jo.Tache(IdTache, Libelle, Annexe, CodeActivite, Login, Description)                                                                                                 
                            select IdTache, Libelle, Annexe, CodeActivite, Login, Description from  @table;

                             Insert jo.TacheProd (IdTache, DureePrevue, DureeRestanteEstimee, CodeModule, CodeLogicieModule, NumeroVersion, CodeLogicielVersion)
                            select IdTache, DureePrevue, DureeRestanteEstimee, CodeModule, CodeLogicieModule, NumeroVersion, CodeLogicielVersion from @table;";

            var param = new SqlParameter("@table", SqlDbType.Structured);

            DataTable tableProd = GetDataTableForTachesProdSansTravail(listTachesProd);
            param.TypeName = "TypeTableTachesProdSansTravail";

            param.Value = tableProd;


            using (var cnx = new SqlConnection(_chaineConnexion))
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



        public static void AjoutTachesProdBDD(List<TacheProd> listTachesProd)
        {
            //Insertion en masse des taches de production dans la BDD
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


            using (var cnx = new SqlConnection(_chaineConnexion))
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

        public static void ModifierTachesAnxBDD(List<Tache> lstTachesAModifier, string login)
        {
            using (var cnx = new SqlConnection(_chaineConnexion))
            {
                cnx.Open();
                var tran = cnx.BeginTransaction();

                // TODO : debugger le merge
                string query = @"MERGE jo.Tache AS Cible
	                                USING (SELECT IdTache, Libelle, Annexe, CodeActivite, Login FROM @table) AS Source
	                                ON (Cible.CodeActivite = Source.CodeActivite and Cible.Login = Source.Login)
                                 WHEN MATCHED THEN
	                                delete
                                 WHEN NOT MATCHED BY TARGET THEN
	                                INSERT (IdTache, Libelle, Annexe, CodeActivite, Login)
	                                VALUES (Source.IdTache, Source.Libelle, Source.Annexe, Source.CodeActivite, Source.Login);";

                var param = new SqlParameter("@table", SqlDbType.Structured);
                param.TypeName = "TypeTableTachesAnx";
                param.Value = GetDataTableForTachesAnx(lstTachesAModifier, login);

                var command = new SqlCommand(query, cnx, tran);
                command.Parameters.Add(param);

                try
                {
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

        public static List<Activité> GetActivitésAnnexes()
        {
            //Requêtage à la BDD pour récupérer les informations sur les activités
            List<Activité> listActivitésAnx = new List<Activité>();

            var conx = new SqlConnection(_chaineConnexion);

            string query = @"select CodeActivite, Libelle from jo.Activite where Annexe = 1";

            var com = new SqlCommand(query, conx);
            conx.Open();

            using (SqlDataReader reader = com.ExecuteReader())
            {
                GetActivitésFromDataReader(reader, listActivitésAnx);
            }

            return listActivitésAnx;
        }

        public static List<Personne> GetPersonnes()
        {
            //Requêtage à la BDD pour récupérer les informations sur les personnes
            List<Personne> listPersonnes = new List<Personne>();

            var conx = new SqlConnection(_chaineConnexion);

            string query = @"select distinct p.Login, p.Nom, p.Prenom, p.Manager, p.TauxProductivite, 
                        						m.CodeMetier, m.Libelle LibelleMetier, 
                                                s.Nom NomService, 
                                                t.Libelle LibelleTache, t.CodeActivite CodeActiviteTache,
                                                a.CodeActivite, a.Libelle LibelleActivité
                            from jo.Personne p
                            inner join jo.Metier m on p.CodeMetier = m.CodeMetier
                            inner join jo.Service s on m.CodeService = s.CodeService
                            inner join jo.Tache t on p.Login = t.Login
                            inner join jo.ActiviteMetier am on m.CodeMetier = am.MetierCodeMetier
                            inner join jo.Activite a on am.ActiviteCodeActivite = a.CodeActivite
                            where a.Annexe = 0
                            order by p.Login, t.CodeActivite";

            var com = new SqlCommand(query, conx);
            conx.Open();

            using (SqlDataReader reader = com.ExecuteReader())
            {
                GetPersonnesFromDataReader(reader, listPersonnes);
            }

            return listPersonnes;
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

        private static void GetActivitésFromDataReader(SqlDataReader reader, List<Activité> listActivitésAnx)
        {
            while (reader.Read())
            {
                Activité act = new Activité();

                act.CodeActivité = reader["CodeActivite"].ToString();
                act.Libellé = reader["Libelle"].ToString();

                listActivitésAnx.Add(act);
            }
        }

        private static void GetPersonnesFromDataReader(SqlDataReader reader, List<Personne> listPersonnes)
        {
            while (reader.Read())
            {
                if (!listPersonnes.Any() || listPersonnes.Last().Login != reader["Login"].ToString())
                {
                    Personne pers = new Personne() { ListTaches = new List<Tache>() };

                    pers.Login = reader["Login"].ToString();
                    pers.Nom = reader["Nom"].ToString();
                    pers.Prénom = reader["Prenom"].ToString();
                    pers.Métier = new Métier()
                    {
                        CodeMétier = reader["CodeMetier"].ToString(),
                        Service = reader["NomService"].ToString(),
                        ListActivités = new List<Activité>()
                    };

                    if (reader["Manager"] != DBNull.Value)
                        pers.LoginManager = reader["Manager"].ToString();

                    pers.TauxProductivité = (float)reader["TauxProductivite"];

                    listPersonnes.Add(pers);
                }

                if (!listPersonnes.Last().ListTaches.Any() ||
                    listPersonnes.Last().ListTaches.Last().CodeActivité != reader["CodeActiviteTache"].ToString())
                {
                    listPersonnes.Last().ListTaches.Add(new Tache()
                    {
                        CodeActivité = reader["CodeActiviteTache"].ToString(),
                        Libellé = reader["LibelleTache"].ToString()
                    });
                }

                // Si la liste d'activité de mon métier est vide ou si elle ne contient pas l'activité en test
                if (!listPersonnes.Last().Métier.ListActivités.Any() ||
                    !listPersonnes.Last().Métier.ListActivités.Where(a => a.CodeActivité == reader["CodeActivite"].ToString()).Any())
                {
                    listPersonnes.Last().Métier.ListActivités.Add(new Activité()
                    {
                        CodeActivité = reader["CodeActivite"].ToString(),
                        Libellé = reader["LibelleActivité"].ToString()
                    });
                }
                //TODO : gérer les taches annexes complètement si nécessaire

            }
        }

        private static DataTable GetDataTableForTachesProdSansTravail(List<TacheProd> listTachesProd)
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
            var colDescription = new DataColumn("Description", typeof(string));
            table.Columns.Add(colDescription);

            #endregion

            foreach (var p in listTachesProd)
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
                ligne["Description"] = p.Description;
                #endregion

                // Ajout de la ligne dans la table
                table.Rows.Add(ligne);

            }
            return table;
        }

        private static DataTable GetDataTableForTachesProd(List<TacheProd> listTachesProd)
        {

            // Création d'une table mémoire
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

            #region Création d'une ligne de table
            foreach (var p in listTachesProd)
            {
                foreach (var t in p.listTravaux)
                {
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

        private static DataTable GetDataTableForTachesAnx(List<Tache> lstTachesAModifier, string login)
        {
            DataTable table = new DataTable();
            #region Initialisations colonnes
            var colIdTache = new DataColumn("IdTache", typeof(Guid));
            colIdTache.AllowDBNull = false;
            table.Columns.Add(colIdTache);

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
            #endregion

            foreach (var t in lstTachesAModifier)
            {
                DataRow ligne = table.NewRow();

                #region Attribution valeurs ligne
                ligne["IdTache"] = Guid.NewGuid();
                ligne["Libelle"] = t.Libellé;
                ligne["Annexe"] = true;
                ligne["CodeActivite"] = t.CodeActivité;
                ligne["Login"] = login;
                #endregion

                table.Rows.Add(ligne);
            }

            return table;
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
