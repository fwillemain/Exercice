using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int? IdFournisseur { get; set; }
        public int? IdCatégorie { get; set; }
        public string QuantitéParUnité { get; set; }
        public decimal? PrixUnitaire { get; set; }
        public int? QuantitéStock { get; set; }

        //  public int QuantitéAttenteRécéption { get; set; }
        //  public bool EnFinDeSérie { get; set; }
    }
}
