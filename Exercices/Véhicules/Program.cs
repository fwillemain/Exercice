using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Véhicules
{
    public enum Energies { Aucune, Essence, Gazole, GPL, Electrique }

    class Program
    {
        static void Main(string[] args)
        {
            Véhicule voit = new Voiture("VoitureFlo", Energies.Essence);
            Véhicule moto = new Moto("MotoFlo", Energies.Gazole);
            Console.WriteLine(voit.Description);
            Console.WriteLine(moto.Description);

            Console.ReadKey();
        }
    }

    class Véhicule
    {
        #region Propriétés
        public string Nom { get; }
        public int NbRoues { get; protected set; }
        public Energies Energie { get; }
        public virtual string Description
        {
            get { return string.Format("Véhicule {0} roule sur {1} roues et à l'énergie {2}.", Nom, NbRoues, Energie); }
        }
        #endregion

        #region Constructeurs
        public Véhicule()
        {
            NbRoues = 4;
        }

        public Véhicule(string nom, int nbRoues, Energies energie) : this()
        {
            Nom = nom;
            NbRoues = nbRoues;
            Energie = energie;
        }
        #endregion
    }

    class Voiture : Véhicule
    {
        #region Propriétés
        public override string Description
        {
            get
            {
                return string.Format("Je suis une voiture. \r\n") + base.Description;
            }
        }
        #endregion

        #region Constructeurs
        public Voiture() : base()
        {

        }

        public Voiture(string nom, Energies energie) : base(nom, 4, energie)
        { 
        }
        #endregion
    }

    class Moto : Véhicule
    {
        #region Propriétés
        public override string Description
        {
            get
            {
                return string.Format("Je suis une moto. \r\n") + base.Description;
            }
        }
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
    }

}
