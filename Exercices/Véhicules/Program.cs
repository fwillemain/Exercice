using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Véhicules
{
    public enum Energies { Aucune, Essence, Gazole, GPL, Electrique }

    class Program
    {

        static void Main(string[] args)
        {
            var vMégane = new Voiture("Mégane", 19000);
            var mIntru = new Moto("Intrudeur", 13000);
            var vEnzo = new Voiture("Enzo", 380000);
            var mYama = new Moto("Yamaha XJR1300", 11000);

            //Avec Dictionary
            Dictionary<string, Véhicule> dico = new Dictionary<string, Véhicule>();
            dico.Add(vMégane.Nom, vMégane);
            dico.Add(mIntru.Nom, mIntru);
            dico.Add(vEnzo.Nom, vEnzo);
            dico.Add(mYama.Nom, mYama);

            Console.WriteLine("Affichage avec Dictionary :");
            foreach (var a in dico)
                Console.WriteLine("{0} : {1}", a.Value.Nom, a.Value.Prix);

            SortedList<string, Véhicule> sList = new SortedList<string, Véhicule>(dico);

            Console.WriteLine();
            Console.WriteLine("Affichage avec SortedList :");
            foreach (var a in sList)
                Console.WriteLine("{0} : {1}", a.Value.Nom, a.Value.Prix);

            string[] marque = { "Clio", "Mégane", "Golf", "Enzo", "Polo" };

            Console.WriteLine();
            {
                Véhicule v;
                foreach (var m in marque)
                    if (sList.TryGetValue(m, out v))
                        Console.WriteLine("{0} : {1}", v.Nom, v.Prix);
            }
            
            Console.ReadKey();
        }
    }
}
