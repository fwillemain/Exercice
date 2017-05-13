using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SaisieTacheSansCours
{
    static public class DAL
    {
        static public ObservableCollection<Tache> RécupérerListeTache()
        {
            ObservableCollection<Tache> listeTache = null;

            XmlSerializer serial = new XmlSerializer(typeof(ObservableCollection<Tache>), new XmlRootAttribute("Taches"));
            
            using(StreamReader reader = new StreamReader(@"../../Taches.xml"))
            {
                listeTache = (ObservableCollection<Tache>) serial.Deserialize(reader);
            }

            return listeTache;
        }

        static public void EnregistrerListeTache(ObservableCollection<Tache> listeTache)
        {
            XmlSerializer serial = new XmlSerializer(typeof(ObservableCollection<Tache>), new XmlRootAttribute("Taches"));

            using(StreamWriter writer = new StreamWriter(@"../../Taches.xml"))
            {
                serial.Serialize(writer, listeTache);
            }
        }
    }
}
