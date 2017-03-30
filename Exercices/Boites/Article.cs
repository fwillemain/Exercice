using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    public class Article : IComparable
    {

        #region Propriétés
        public int Id { get; }
        public string Libellé { get; set; }
        public double Poids { get; set; }
        #endregion

        #region Constructeurs
        public Article(int id, string libellé, double poids)
        {
            Id = id;
            Libellé = libellé;
            Poids = poids;
        }

        #endregion

        #region Propriétés publiques
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}g", Id, Libellé, Poids);
        }
        /// <summary>
        /// Tri en fonction du poids.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj is Article)
                return Poids.CompareTo(((Article)obj).Poids);
            else
                throw new ArgumentException();
        }

        #endregion

    }
}
