using System;
using System.Xml.Serialization;

namespace SaisieTacheMVVM.Entités
{
    public  class Tache
    {
        [XmlAttribute]
        public int Id { get; set; }

        [XmlAttribute("Creation")]
        public DateTime DateCréation { get; set; }

        [XmlAttribute("Term")]
        public DateTime DateEchéance { get; set; }

        [XmlAttribute("Prio")]
        public int Priorité { get; set; }

        [XmlAttribute("Fait")]
        public bool Terminée { get; set; }

        [XmlText]
        public string Description { get; set; }
    }
}