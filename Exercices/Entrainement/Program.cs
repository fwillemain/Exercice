using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrainement
{
    class Program
    {
        static void Main(string[] args)
        {
            

            //Test pour Github
            try
            {
                TestException test = new TestException();
                test.RetourException();
               // Afficher("Coucou");
                //Demo();
            }
            //catch (FormatException)
            //{
            //    Console.WriteLine("Y a un problème de format!!");
            //}
            catch (Exception e)
            {
                // StreamWriter log = File.OpenWrite(cheminDuLog);

                Console.WriteLine("Exception : {0}\n{1}", e.StackTrace, e.Message);
            }
            finally
            {
            }


            Console.ReadKey();
        }

        static void Demo()
        {
            string texte;
            string phrase;
            int nbPhrases, nbMots; // plusieurs déclarations

            //const double PI = 3.1415926;
            const string DEB_LISTE = " - ";

            phrase = "Le C# est un langage moderne et puissant!";
            texte = phrase;
            texte = texte + " Il est utilisé pour toutes sortes d'applications\n";
            texte = texte + DEB_LISTE + "Application console\n";
            texte += DEB_LISTE + "Application fenêtrée Winform et WPF\n";

            Console.WriteLine(texte);

            char lettre;
            lettre = phrase[3];

            Console.WriteLine("La lettre : " + lettre + "\n");

            int[] tabPos = new int[3] { 3, 4, 40 };

            Console.WriteLine("La longueur du tableau est : " + tabPos.Length + "\n");

            Console.WriteLine("Boucle for");
            for (int i = 0; i < tabPos.Length; i++)
            {
                Console.WriteLine("tabPos[" + i + "] = " + tabPos[i]);
            }

            Console.WriteLine("\nBoucle while");
            int j = 0;
            while (j < tabPos.Length)
            {
                Console.WriteLine("tabPos[" + j + "] = " + tabPos[j]);
                j++;
            }

            Console.Clear();
            Console.WriteLine(texte);

            nbPhrases = 0;
            for (int i = 0; i < texte.Length; i++)
            {
                if (texte[i] == '\n')
                {
                    nbPhrases++;
                }
            }

            Console.WriteLine("Il y a " + nbPhrases + " phrases dans le texte.");
            Console.Clear();


            nbMots = 0;
            for (int i = 0; i < phrase.Length; i++)
            {
                if (phrase[i] == ' ' || phrase[i] == '\n' || phrase[i] == '\'')
                {
                    nbMots++;
                }
            }

            nbMots++;
            Console.WriteLine("Il y a " + nbMots + " mots dans la phrase.");

            string valeur = Console.ReadLine();
            int x = int.Parse(valeur);
        }


        static public void Afficher(string toto)
        {
            try
            {
                throw new EntryPointNotFoundException("Salut, je bug et je suis content!");
            }
            catch(FormatException)
            {

            }
            finally
            {
                Console.WriteLine("Finally dans Afficher()");
            }
        }

        public class TestException
        {
            public void RetourException()
            {
                throw new Exception();
            }
        }

    }
}




