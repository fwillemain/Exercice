using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    class Program
    {
        static void Main(string[] args)
        {

            //TODO : utiliser la classe Boite

        }

        public class Boite
        {
            public enum Couleur { Blanc, Bleu, Vert, Jaune, Orange, Rouge, Marron }
            public enum Matière { Carton, Plastique, Bois, Métal }

            #region Champs privés
            private double _hauteur;
            private double _largeur;
            private double _longueur;
            private Couleur _couleurBoite;
            private Matière _matièreBoite;
            #endregion

            #region Propriétés
            public Couleur CouleurBoite
            {
                get { return _couleurBoite; }
                set { _couleurBoite = value; }
            }

            public Matière MatièreBoite
            {
                get { return _matièreBoite; }
            }

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
                _matièreBoite = Matière.Carton;
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
}
