using System.Collections.Generic;

namespace JobOverview
{
    public class Métier
    {
        public string CodeMétier { get; set; }
        public string Service { get; set; }
        public List<Activité> ListActivités { get; set; }
    }
}