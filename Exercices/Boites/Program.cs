using POO;
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

            Boite b1 = new Boites.Boite(30, 40, 50, Matières.Plastique);
            bool resultat = boite.Compare(b1);

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

            BoiteAlertable b = new BoiteAlertable(new Boite());
            b.AlerterClient();

            //b1.Etiqueter(etqV, etqFrag);
            //boite.Etiqueter(etqV, etqFrag);

            //var a1 = new Article(1, "Article 1", 540);
            //var a2 = new Article(2, "Article 2", 200);
            //var a3 = new Article(3, "Article 3", 600);

            //Dictionary<string, Article> test = new Dictionary<string, Article>();
            //test.Add("coucou", a1);
            //test["coucou1"] = new Article(1, "1", 0);
            //test["coucou2"] = new Article(1, "2", 0);

            ////var indispensable car est de type KeyValuePair...
            //foreach (var a in test)
            //    a.Value.Poids = 123;

            


            //b1.Articles.Add(a1);
            //b1.Articles.Add(a2);
            //b1.Articles.Add(a3);

            //for (int i = 0; i < b1.Articles.Count; i++)
            //{
            //    // Appelle par défaut ToString(), comme on l'override ça affiche la bonne.
            //    // Console.WriteLine(b1.Articles[i]);
            //    b1.Articles[i].Libellé = "toto";
            //}

            //b1.Articles.Sort();

            //foreach (Article a in b1.Articles)
            //    Console.WriteLine(a);

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

            //Console.WriteLine("Les boites sont-elles identiques ? {0}", boite.Compare(boite2));

            Console.ReadKey();

        }


    }
}
