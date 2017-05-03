using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ADO
{
    public class Commande
    {
        [XmlIgnore]
        public string Id { get; set; }
        [XmlAttribute]
        public int IdCommande { get; set; }
        [XmlAttribute]
        public string IdClient { get; set; }
        [XmlElement]
        public DateTime? Date { get; set; }
        [XmlIgnore]
        public DateTime DateEnvoi { get; set; }
        [XmlIgnore]
        public int NbArticles { get; set; }
        [XmlIgnore]
        public decimal MontantTot { get; set; }
        [XmlIgnore]
        public decimal FraisEnvoi { get; set; }
        public List<LigneCommande> LstLignesCommandes { get; set; }
    }

    public class LigneCommande
    {
        [XmlAttribute]
        public int IdProduit { get; set; }
        [XmlAttribute]
        public decimal PrixUnitaire { get; set; }
        [XmlAttribute]
        public int Quantité { get; set; }
        [XmlAttribute]
        public float Réduction { get; set; }
    }
}
