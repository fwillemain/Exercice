using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    class Program
    {
        static void Main(string[] args)
        {
            Boite boite = new Boite();
            boite.Etiqueter("Florian", true);

            Boite boite2 = new Boites.Boite(30, 40, 50, Matières.Plastique);

            bool resultat = boite.Compare(boite2);
            
            
            Etiquette etqV = new Etiquette
            {
                Couleur = Couleurs.Blanc,
                Format = Formats.L,
                Texte = "Virginie"
            };

            Etiquette etqFrag = new Etiquette
            {
                Couleur = Couleurs.Blanc,
                Format = Formats.L,
                Texte = "FRAGILE"
            };

            boite2.Etiqueter(etqV, etqFrag);

            boite.Etiqueter(etqV, etqFrag);

            //Boite boite2 = new Boite(20, 20, 20);
            //Boite boite3 = new Boite(20, 20, 20, Matières.Métal);

            //Console.WriteLine("J'ai {0} instances de boite.", Boite.CompteurInstance);

            //Etiquette etiquette = new Etiquette
            //{
            //    Couleur = Couleurs.Jaune,
            //    Format = Formats.S,
            //    Texte = "Coucou"
            //};


            //Console.WriteLine("Mon étiquette est {0}, au format {1} avec l'inscription \"{2}\"", etiquette.Couleur, etiquette.Format, etiquette.Texte);

            // Console.WriteLine("Les boites sont-elles identiques ? {0}", boite.Compare(boite2));

            Console.ReadKey();

        }


    }
}
