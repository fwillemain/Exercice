using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMéthodeExtension
{
    static class ObjetHelper
    {
        // Méthodes d'extensions très utiles pour remplace un décorateur quand il n'est pas nécessaire d'accéder à des champs privés, de modifier
        // des propriétés en get only ou de rajouter de nouvelles propriétés à la classe
        // Il est possible de les déplacer directement dans la classe concernée sans modifier le code appelant.


        /// <summary>
        /// Retourne true si les propriétés de l'objet ont toutes leurs valeurs par défaut
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        static public bool IsDefault(this Objet t)
        {
            return t.Nom.StartsWith("default") && t.X == 0 && t.Y == 0;
        }

        // Comme plus haut mais possible sur des Collections génériques d'objet implémentant l'interface nécessaire à 
        // notre extension (si il en existe une)
        /// <summary>
        /// Renvoi le premier élément de la collection col dont la position est spécifiée en paramètre
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="col"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        static public T GetFirstElementInPosition<T>(this IEnumerable<T> col, float X, float Y) where T : IPosition
        {
            foreach (var t in col)
            {
                if (t.X == X && t.Y == Y)
                    return t;
            }

            // Renvoi null si T est un objet, 0 sinon
            return default(T);
        }

        // Comme plus haut mais directement sur uen collection d'objets de type "Objet"
        /// <summary>
        /// Renvoi le premier Objet par défaut rencontré dans la collection
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        static public Objet GetFirstDefaultObject(this IEnumerable<Objet> col)
        {
            foreach(var o in col)
            {
                if (o.IsDefault())
                    return o;
            }

            return null;
        }
    }
}

