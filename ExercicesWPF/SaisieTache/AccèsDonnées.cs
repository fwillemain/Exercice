using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SaisieTache
{
    static public class AccèsDonnées
    {
        static public ObservableCollection<Tache> ChargerDonnées()
        {
            ObservableCollection<Tache> listeTache = null;

            XmlSerializer serial = new XmlSerializer(typeof(ObservableCollection<Tache>), new XmlRootAttribute("Taches"));

            using(StreamReader reader = new StreamReader(@"../../Taches.xml"))
            {
                listeTache = (ObservableCollection<Tache>) serial.Deserialize(reader);
            }

            return listeTache;
        }

        // TODO : voir pourquoi le fichier XML n'est pas remplacé quand il existe déjà
        static public void EnregistrerTaches(ObservableCollection<Tache> listeTache)
        {
            XmlSerializer serial = new XmlSerializer(typeof(ObservableCollection<Tache>), new XmlRootAttribute("Taches"));

            using (StreamWriter writer = new StreamWriter(@"../../Taches.xml"))
            {
                serial.Serialize(writer, listeTache);
            }
        }
    }
}
