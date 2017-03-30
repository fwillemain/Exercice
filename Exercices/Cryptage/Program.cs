using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptages
{
    class Program
    {
        static void Main(string[] args)
        {
            Cryptage.ChargerFichier("../../cle.txt");

            string tCrypté, texte = "Coucou, je ne suis pas crypté!";

            Console.WriteLine(texte);

            tCrypté = Cryptage.CrypterTexte(texte);
            Console.WriteLine(tCrypté);

            Console.WriteLine(Cryptage.DecrypterTexte(tCrypté));

            Console.ReadKey();
        }
    }

    static class Cryptage
    {
        #region Propriétés
        public static Dictionary<char, char> ClefCryptage { get; set; }
        #endregion

        #region Constructeurs
        static Cryptage()
        {
            ClefCryptage = new Dictionary<char, char>();
        }
        #endregion

        #region Méthodes publiques
        public static void ChargerFichier(string path)
        {
            string[] ligne, clef = File.ReadAllLines(path);

            for (int i = 0; i < clef.Length; i++)
            {
                ligne = clef[i].Split(' ');
                ClefCryptage.Add(Convert.ToChar(ligne[0]), Convert.ToChar(ligne[1]));
            }
        }

        public static string CrypterTexte(string texte)
        {
            char[] c = texte.ToCharArray();
            char ch;
            for (int i = 0; i < c.Length; i++)
            {
                if (ClefCryptage.TryGetValue(c[i], out ch))
                    c[i] = Convert.ToChar(ch);
            }

            return new string(c);
        }

        public static string DecrypterTexte(string texte)
        {
            char[] c = texte.ToCharArray();
            bool décrypt;   //Informe si caractère déjà décrypté

            for (int i = 0; i < c.Length; i++)
            {
                décrypt = false;
                foreach(var a in ClefCryptage)
                {
                    if (a.Value == c[i] && !décrypt)
                    {
                        c[i] = a.Key;
                        décrypt = true;
                    }
                }
            }

            return new string(c);
        }
        #endregion

    }


}
