using System;
using System.Collections.Generic;

namespace JobOverview
{
    public class Logiciel
    {
        public string CodeLogiciel { get; set; }
        public string NomLogiciel { get; set; }
        public List<Module> ListModules { get; set; }
        public List<Version> ListVersions { get; set; }
    }

    public class Module
    {
        public string CodeModule { get; set; }
        public string LibelléModule { get; set; }
    }

    public class Version
    {
        public float NumeroVersion { get; set; }
        public short Millésime { get; set; }
        public DateTime DateOuverture { get; set; }
        public DateTime DateSortiePrévue { get; set; }
        public DateTime? DateSortieRéelle { get; set; }
        public List<Release> ListReleases { get; set; }

    }

    public class Release
    {
        public short NumeroRelease { get; set; }
        public DateTime DateSetup { get; set; }
    }
}