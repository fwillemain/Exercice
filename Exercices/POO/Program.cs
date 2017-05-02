using System;
using System.Collections.Generic;
using System.Text;

namespace POO
{
    class Program
    {
        static void Main(string[] args)
        {
            //TesterCompteBancaire();
            MoyenPaiment carte = new Carte (101)
            {
                NomTitulaire = "Gabin",
                PrénomTitulaire = "Jean",
                CodeSecret = 9999,
                DateExpiration = new DateTime(2017, 09, 30)
            };

            MoyenPaiment chq = new Chéquier(102)
            {
                NomTitulaire = "Delon",
                PrénomTitulaire = "Alain",
                NumPremierChèque = 102001
            };


            var cb = new CompteBancaire(11221321);
            var c = new CompteBancaireAltertable(cb);
            c.AlerterClient();
            cb.Etendre();

            //Console.WriteLine(carte.ToString());
            //Console.WriteLine(chq.ToString());
            //Console.WriteLine();
            //DateTime dateRenou = new DateTime(2016, 02, 25);
            //carte.Renouveler(dateRenou);
            //chq.Renouveler(new DateTime(2016, 05, 21));
            //Console.WriteLine(carte.ToString());
            //Console.WriteLine(chq.ToString());

            //Console.WriteLine();

            //MoyenPaiment[] tabMP = new MoyenPaiment[4];
            //tabMP[0] = new Carte(456);
            //tabMP[1] = new Chéquier(456);
            //tabMP[2] = new Carte(789);
            //tabMP[3] = new Chéquier(789);

            //for (int i = 0; i < tabMP.Length; i++)
            //{
            //    Console.WriteLine(tabMP[i].ToString());
            //    Console.WriteLine(tabMP[i].Payer());
            //}

            //TesterDistributeur();
            Console.ReadKey();
        }

        static void TesterCompteBancaire()
        {
            CompteBancaire[] tabComptes = new CompteBancaire[2];
            DateTime dt = new DateTime(2016, 2, 25);
            tabComptes[0] = new CompteBancaire(654654165, dt, 500);
            tabComptes[1] = new CompteBancaire(9898745646);

            tabComptes[1].DécouvertAutorisé = -700;
            tabComptes[1].Créditer(1000);
            Console.WriteLine("Solde courant : {0}", tabComptes[1].SoldeCourant);

            tabComptes[1].Débiter(600);
            Console.WriteLine("Solde courant : {0}", tabComptes[1].SoldeCourant);

            tabComptes[1].Débiter(1000);
            Console.WriteLine("Solde courant : {0}", tabComptes[1].SoldeCourant);

            // Le débit suivant produit une exception car le solde du compte
            // est en-dessous du découvert autorisé
            try
            {
                tabComptes[1].Débiter(100);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Opération impossible car pas assez d'argent sur le compte");
            }

            // Création d'une carte
            //Carte carte = new Carte
            //{
            //    NumCarte = 7539514569871234,
            //    CodeSecret = 1234,
            //    CodeVérif = 951,
            //    DateExpiration = DateTime.Today.AddYears(2)
            //};

            //// Association de cette carte au compte (agrégation)
            //tabComptes[1].AjouterCarte(carte);
        }

        static void TesterDistributeur()
        {
            DistributeurBoisson distrib = new DistributeurBoisson();
            distrib.Paiement = 0.30m; // la valeur étant de type décimal, on met un m
            try
            {
                distrib.BoissonSélectionnée = Boissons.CaféCrème;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            distrib.Paiement = 1.0m;
            distrib.QuantitéSucre = 3;
            string service = distrib.ServirBoisson();
            Console.WriteLine(service);

            string rendu = distrib.RendreMonnaie();
            Console.WriteLine(rendu);
        }
    }
}
