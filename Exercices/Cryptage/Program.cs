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

            for(int i = 0; i < clef.Length; i++)
            {
                ligne = clef[i].Split(' ');
                ClefCryptage.Add(Convert.ToChar(ligne[0]), Convert.ToChar(ligne[1]));
            } 
        }

        public static string CrypterTexte(string texte)
        {

            return "";
        }


        #endregion

    }


}
