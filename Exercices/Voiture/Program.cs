using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voiture
{
    class Program
    {
        static void Main(string[] args)
        {
            Voiture VoitureYannick = new Voiture();
            Voiture VoitureVirginie = new Voiture();

            Console.WriteLine("La marque de la voiture est : {0}", Voiture._marque);

            VoitureYannick.ChangerMarque("Ferrari");

            Console.WriteLine("La marque de la voiture de Yannick est : {0}", VoitureYannick.AfficherMarque());

            Console.WriteLine("La marque de la voiture de Virginie est : {0}", VoitureVirginie.AfficherMarque());

            Console.ReadKey();
        }

        public class Voiture
        {
            public static string _marque;

            public Voiture()
            {
                _marque = "Renault";
            }

            public void ChangerMarque(string marque)
            {
                _marque = marque;
            }

            public string AfficherMarque()
            {
                return _marque;
            }
        }
    }
}
