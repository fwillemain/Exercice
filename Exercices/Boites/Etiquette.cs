using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    public enum Formats { XS, S, M, L, XL }
    public class Etiquette
    {

        #region Propriétés
        public string Texte { get; set; }
        public Couleurs Couleur { get; set; }
        public Formats Format { get; set; }
        #endregion

        #region Constructeurs

        //public Etiquette(Couleurs couleur, Formats format, string texte)
        //{
        //    Couleur = couleur;
        //    Format = format;
        //    Texte = texte;
        //}

        #endregion

    }
}
