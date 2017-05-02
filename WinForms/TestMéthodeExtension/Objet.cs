using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMéthodeExtension
{
    public class Objet : IPosition
    {
        #region Propriétés
        public string Nom { get; set; }
        public float X { get; }
        public float Y { get; }
        public int Numéro { get; set; }
        static public int Compteur { get; private set; }
        #endregion

        #region Constructeurs
        public Objet(string s = null)
        {
            Nom = s ?? "default" + Compteur;
            Numéro = Compteur;
            Compteur++;
        }
        public Objet(float x, float y, string s = null) : this(s)
        {
            X = x;
            Y = y;
        }
        #endregion

        #region Méthodes publiques
        public override string ToString()
        {
            return string.Format("L'objet n°{0} dont le nom est {1} est en position ({2},{3}).", Numéro, Nom, X, Y);
        } 
        #endregion
    }
}
