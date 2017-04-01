using System;
using System.Collections;
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
        private Etiquette _etiquetteDest;
        private Etiquette _etiquetteFragile;
        #endregion

        #region Propriétés
        public Couleurs Couleur { get; set; }
        public Matières Matière { get; private set; }
        public bool Fragile { get; set; }
        public double Volume
        {
            get { return _largeur * _longueur * _hauteur; }
        }
        public static int CompteurInstance { get; private set; }
        public List<Article> Articles { get; }
        #endregion

        #region Constructeurs
        static Boite()
        {
            CompteurInstance = 0;
        }

        public Boite()
        {
            CompteurInstance++;
            Articles = new List<Article>();
        }

        public Boite(double hauteur, double largeur, double longueur) : this()
        {
            _hauteur = hauteur;
            _largeur = largeur;
            _longueur = longueur;
        }
        public Boite(double hauteur, double largeur, double longueur, Matières matière) : this(hauteur, largeur, longueur)
        {
            Matière = matière;
        }
        #endregion

        #region Méthodes publiques
        public void Etiqueter(string destinataire)
        {
            _etiquetteDest = new Etiquette { Couleur = Couleurs.Blanc, Format = Formats.L, Texte = destinataire };
        }

        public void Etiqueter(string destinataire, bool fragile)
        {
            if (fragile)
            {
                _etiquetteFragile = new Etiquette { Couleur = Couleurs.Rouge, Format = Formats.S, Texte = "FRAGILE" };
            }

            Etiqueter(destinataire);
            Fragile = fragile;
       
        }

        public void Etiqueter(Etiquette etqDest, Etiquette etqFrag)
        {
            _etiquetteDest = etqDest;
            _etiquetteFragile = etqFrag;
        }

        public bool Compare(Boite b)
        {
            return (_largeur == b._largeur && _hauteur == b._hauteur && _longueur == b._longueur && Matière == b.Matière);
        }

        #endregion

    }
}
