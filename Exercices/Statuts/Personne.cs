using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stat
{
    public class Personne
    {
        #region Propriétés
        public string Nom { get; }
        public string Prénom { get; }
        public Statuts Statut { get; set; }
        #endregion

        #region Constructeurs
        public Personne(string nom, string prénom)
        {
            Nom = nom;
            Prénom = prénom;
        }
        public Personne(string nom, string prénom, Statuts statut) : this(nom, prénom)
        {          
            Statut = statut;
        }
        #endregion

        #region Méthodes publiques
        public override string ToString()
        {
            return string.Format("{0}.{1}.{2}", Nom, Prénom, Statut);
        }

        #endregion

    }
}
