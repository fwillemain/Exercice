using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    public enum Couleurs { Blanc, Bleu, Vert, Jaune, Orange, Rouge, Marron }
    public enum Matières { Carton, Plastique, Bois, Métal }

    public class Boite
    {    
        #region Champs privés
        private double _hauteur;
        private double _largeur;
        private double _longueur;
        #endregion

        #region Propriétés
        public Couleurs Couleur { get; set; }

        public Matières Matière { get; private set; }

        public double Volume
        {
            get { return _largeur * _longueur * _hauteur; }
        }
        #endregion

        #region Constructeurs
        public Boite()
        {
            _hauteur = 30;
            _largeur = 30;
            _longueur = 30;
            Matière = Matières.Carton;
        }

        #endregion

        #region Méthodes publiques
        public string Etiqueter(string destinataire)
        {
            throw new NotImplementedException();
            //TODO : ajouter des fonctionnalités
        }

        public string Etiqueter(string destinataire, bool fragile)
        {
            throw new NotImplementedException();
            //TODO : ajouter des fonctionnalités

        }

        #endregion





    }
}
