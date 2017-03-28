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
            var v = new Voiture();
           
            Console.ReadKey();
        }

        class Véhicule
        {
            public Véhicule()
            {
            }

            public Véhicule(string marque) : this()
            {
            }
        }

        class Voiture : Véhicule
        {
            public Voiture() : base()
            {
                // Initialisation importante
                Console.WriteLine("Coucou");      
            }

            public Voiture(string marque): base(marque)
            {
                
            }
        }

    }
}
