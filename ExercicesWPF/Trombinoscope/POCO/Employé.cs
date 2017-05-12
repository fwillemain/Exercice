using System.Collections.Generic;

namespace Trombinoscope
{
    public class Employé
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prénom { get; set; }
        public List<Territoire> LstTerritoire { get; set; }
    }

    public class Territoire
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }
}