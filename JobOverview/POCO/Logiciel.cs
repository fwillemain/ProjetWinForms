using System;
using System.Collections.Generic;

namespace JobOverview
{
    public class Logiciel
    {
        public string Code { get; set; }
        public string Nom { get; set; }
        public List<Module> ListModules { get; set; }
    }

    public class Module
    {
        public string Code { get; set; }
        public string Libellé { get; set; }
        public List<Module> ListSousModules { get; set; }
        public List<Version> ListVersions { get; set; }
    }

    public class Version
    {
        public float Numero { get; set; }
        public short Millésime { get; set; }
        public DateTime DateOuverture { get; set; }
        public DateTime DateSortiePrévue { get; set; }
        public DateTime? DateSortieRéelle { get; set; }
        public List<Release> ListReleases { get; set; }

    }

    public class Release
    {
        public short Numero { get; set; }
        public DateTime DateSetup { get; set; }
    }
}