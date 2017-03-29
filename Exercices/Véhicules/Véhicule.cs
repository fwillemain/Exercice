using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Véhicules
{
    public abstract class Véhicule : IComparable
    {
        #region Propriétés
        public string Nom { get; }
        public int NbRoues { get; protected set; }
        public Energies Energie { get; }
        public virtual string Description
        {
            get { return string.Format("Véhicule {0} roule sur {1} roues et à l'énergie {2}.", Nom, NbRoues, Energie); }
        }
        public abstract int PRK { get; }

        #endregion

        #region Constructeurs
        public Véhicule()
        {
            NbRoues = 4;
        }

        public Véhicule(string nom, int nbRoues, Energies energie)
        {
            Nom = nom;
            NbRoues = nbRoues;
            Energie = energie;
        }
        #endregion

        #region Méthodes Publiques
        public abstract void CalculerConso();

        public int CompareTo(object v)
        {
            if(v is Véhicule)          
                return PRK.CompareTo(((Véhicule)v).PRK);
            else
                throw new ArgumentException();
        }
        #endregion
    }

    public class Voiture : Véhicule
    {
        #region Propriétés
        public override string Description
        {
            get
            {
                return string.Format("Je suis une voiture. \r\n") + base.Description;
            }
        }

        public override int PRK { get { return 20; } }
        #endregion

        #region Constructeurs
        public Voiture() : base()
        {

        }

        public Voiture(string nom, Energies energie) : base(nom, 4, energie)
        {

        }
        #endregion

        #region Méthodes Publiques
        public override void CalculerConso()
        {
            throw new NotImplementedException();
        }

        public string RefaireParallélisme()
        {
            return "Parallélisme refait.";
        }
       
        #endregion
    }

    public class Moto : Véhicule
    {
        #region Propriétés
        public override string Description
        {
            get { return string.Format("Je suis une moto. \r\n") + base.Description; }
        }
        public override int PRK { get { return 10; } }
        #endregion

        #region Constructeurs
        public Moto() : base()
        {
            NbRoues = 2;
        }

        public Moto(string nom, Energies energie) : base(nom, 2, energie)
        {
        }
        #endregion

        #region Méthodes Publiques
        public override void CalculerConso()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
