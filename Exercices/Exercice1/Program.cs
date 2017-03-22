using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1
{
    class Program
    {
        static void Main(string[] args)
        {

            int p, q, resultat;
            string saisie;

            Console.WriteLine("Calcul du PGCD");
            Console.WriteLine("Entrez le premier nombre entier");
            saisie = Console.ReadLine();
            p = int.Parse(saisie);

            Console.WriteLine("Entrez le deuxième nombre entier");
            saisie = Console.ReadLine();
            q = int.Parse(saisie);

            resultat = CalculPGCD(p, q);
            Console.WriteLine("Le PGCD de " + p + " et " + q + " est : " + resultat);
            Console.ReadKey();

        }

        static int CalculPGCD(int p, int q)
        {
            while(p != q)
            {
                if(p > q)
                    p -= q;
                else
                    q -= p;
            }

            return p;
        }
    }
}
