using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tri_tableau
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] tableau = { "C", "D", "A", "B", "F", "A"};

            Console.WriteLine("Affichage tableau trié");
            AfficherTableau(TrierTableau(tableau));

            Console.WriteLine("Affichage tableau d'origine");
            AfficherTableau(tableau);

            Console.ReadKey();

        }

        static void AfficherTableau(string[] tableauAAfficher)
        {
            for (int i = 0; i < tableauAAfficher.Length; i++)
                Console.Write(tableauAAfficher[i] + " ");
            Console.Write('\n');
        }

        
        static string[] TrierTableau(string[] tableauATrier)
        {
            string[] resultat = new string[tableauATrier.Length];

            for (int i = 0; i < tableauATrier.Length; i++)
                resultat[i] = tableauATrier[i];
            
            for (int i = 0; i < resultat.Length; i++)
            {
                int j = i;
                while(j > 0 && (resultat[j - 1].CompareTo(resultat[j]) == 1))
                {
                    string temp = resultat[j - 1];
                    resultat[j - 1] = resultat[j];
                    resultat[j] = temp;
                    j--;
                }
            }

            return resultat;
        }

    }
}
