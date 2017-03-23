using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compteur_Voyelles_Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            int nbrVoyelles, nbrConsonnes;

            Console.Write("Entrez un mot : ");
            string mot = Console.ReadLine();

            CompteurVoyellesConsonnes(mot, out nbrVoyelles, out nbrConsonnes);
            Console.WriteLine("\"{0}\" comprend {1} consonnes et {2} voyelles.", mot, nbrConsonnes, nbrVoyelles);

            Console.ReadKey();

        }

        static void CompteurVoyellesConsonnes(string mot, out int nbrVoyelles, out int nbrConsonnes)
        {
            nbrVoyelles = 0;

            mot = mot.ToLower();
            
            for(int i  = 0; i < mot.Length; i++)
            {
                if (EstVoyelle(mot[i]))
                    nbrVoyelles++;
            }

            nbrConsonnes = mot.Length - nbrVoyelles;
        }

        static bool EstVoyelle(char c)
        {
            return (c.Equals('a') || c.Equals('e') || c.Equals('i') || c.Equals('o') || c.Equals('u') || c.Equals('y')); 
        }

    }
}
