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

            Console.WriteLine("Entrez la phrase que vous souhaitez crypter.");
            string texte = Console.ReadLine();

            Cryptage.CrypterTexte(ref texte);
            Console.WriteLine(texte);

            Console.WriteLine("Voulez-vous décrypter la phrase? (o/N)");
            string res = Console.ReadLine().ToLower();

            if (res.Equals("o"))
            {
                Cryptage.DecrypterTexte(ref texte);
                Console.WriteLine(texte);
            }

            Console.ReadKey();
        }
    }

    static class Cryptage
    {
        #region Propriétés
        public static Dictionary<char, char> ClefCryptage { get; set; }
        public static Dictionary<char, char> ClefDécryptage { get; set; }
        #endregion

        #region Constructeurs
        static Cryptage()
        {
            ClefCryptage = new Dictionary<char, char>();
            ClefDécryptage = new Dictionary<char, char>();
        }
        #endregion

        #region Méthodes privées
        private static void CrypterTexteAvecClef(ref string texte, Dictionary<char, char> clefCryptage)
        {
            char[] c = texte.ToCharArray();
            char ch;
            for (int i = 0; i < c.Length; i++)
            {
                if (clefCryptage.TryGetValue(c[i], out ch))
                    c[i] = Convert.ToChar(ch);
            }

            texte = new string(c);
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
                ClefDécryptage.Add(Convert.ToChar(ligne[1]), Convert.ToChar(ligne[0]));
            }
        }

        public static void CrypterTexte(ref string texte)
        {
            CrypterTexteAvecClef(ref texte, ClefCryptage);
        }

        public static void DecrypterTexte(ref string texte)
        {
            CrypterTexteAvecClef(ref texte, ClefDécryptage);
        }
        #endregion

    }


}
