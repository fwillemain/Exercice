using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMéthodeExtension
{
    static class TestExtensions
    {
        // Méthodes d'extensions très utile pour remplace un décorateur quand il n'est pas nécessaire d'accéder à des champs privés ou de modifier
        // des propriétés en get only 
        /// <summary>
        /// Retourne true si le nom de l'objet contient "default"
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        static public bool IsNameDefault(this Objet t)
        {
            return t.Nom.StartsWith("default");
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
                if (o.IsNameDefault())
                    return o;
            }

            return null;
        }
    }
}

