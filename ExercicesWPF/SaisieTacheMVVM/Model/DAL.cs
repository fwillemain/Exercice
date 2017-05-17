using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SaisieTacheMVVM.Entités;

namespace SaisieTacheMVVM.Model
{
    static public class DAL
    {
        static public List<Tache> RécupérerListeTache()
        {
            List<Tache> listeTache = null;

            XmlSerializer serial = new XmlSerializer(typeof(List<Tache>), new XmlRootAttribute("Taches"));
            
            using(StreamReader reader = new StreamReader(@"../../Taches.xml"))
            {
                listeTache = (List<Tache>) serial.Deserialize(reader);
            }

            return listeTache;
        }

        static public void EnregistrerListeTache(List<Tache> listeTache)
        {
            XmlSerializer serial = new XmlSerializer(typeof(List<Tache>), new XmlRootAttribute("Taches"));

            using(StreamWriter writer = new StreamWriter(@"../../Taches.xml"))
            {
                serial.Serialize(writer, listeTache);
            }
        }
    }
}
