using System;
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
            Véhicule voit = new Voiture("VoitureFlo", Energies.Essence);
            Véhicule moto = new Moto("MotoFlo", Energies.Gazole);

            //Console.WriteLine(voit.Description);
            //Console.WriteLine(moto.Description);

            int res = voit.CompareTo(moto);
            if (res < 0)
                Console.WriteLine("Le véhicule {0} est plus économique que le véhicule {1}.", voit.Nom, moto.Nom);
            else if (res == 0)
                Console.WriteLine("Les 2 véhicules ont le même PRK.");
            else
                Console.WriteLine("Le véhicule {0} est plus économique que le véhicule {1}.", moto.Nom, voit.Nom);

            Véhicule[] tabV = new Véhicule[4] { voit, moto, new Voiture(), new Moto() };

            //for (int i = 0; i < tabV.Length; i++)
            //    if (tabV[i] is Voiture)
            //        Console.WriteLine(((Voiture)tabV[i]).RefaireParallélisme());
            
            foreach(Véhicule v in tabV)
                if (v is Voiture)
                    Console.WriteLine(((Voiture)v).RefaireParallélisme());

            //Impossible car Véhicule est une classe abstraite
            //Véhicule test = new Véhicule();  

            Console.ReadKey();
        }
    }
}
