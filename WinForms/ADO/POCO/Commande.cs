using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public class Commande
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateEnvoi { get; set; }
        public int NbArticles { get; set; }
        public decimal MontantTot { get; set; }
        public decimal FraisEnvoi { get; set; }
    }
}
