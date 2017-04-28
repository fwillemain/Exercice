using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public class Fournisseur
    {
        public int Id { get; set; }
        public string NomEntreprise { get; set; }
        public string NomContact { get; set; }
        public string TitreContact { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Région { get; set; }
        public string CodePostal { get; set; }
        public string Pays { get; set; }
    }
}
