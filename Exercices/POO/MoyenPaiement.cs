using System;
using System.Diagnostics;

namespace POO
{
    public abstract class MoyenPaiment : IRenouvelable
    {
        public long NumCompte { get; protected set; }
        public string  NomTitulaire { get; set; }
        public string PrénomTitulaire { get; set; }

        public DateTime DateRenouvellement { get; private set; }

        public MoyenPaiment()
        {

        }

        // Coonstructeur surchargé
        public MoyenPaiment(long numCpt)
        {
            NumCompte = numCpt;
            Debug.WriteLine("Constructeur de MoyenPaiment");
        }

        // Méthode de la classe Object redéfinie dans MoyenPaiement
        public override string ToString()
        {
            return string.Format("Moyen de paiement associé au compte {0} de {1} {2}, renouvelé le {3:d}\n",
                NumCompte, PrénomTitulaire, NomTitulaire, DateRenouvellement);
        }

        public abstract string Payer();

        public virtual void Renouveler(DateTime date)
        {
            DateRenouvellement = date;
        }
    }


    public class Carte : MoyenPaiment
    {
        public long NumCarte { get; set; }
        
        public DateTime DateExpiration { get; set; }
        public int CodeVérif { get; set; }
        public int CodeSecret { get; set; }


        // Constructeur qui appelle celui de la classe ancêtre (MoyenPaiement)
        public Carte(long numCpt) : base(numCpt)
        {
            Debug.WriteLine("Constructeur de Carte");
        }

        // Méthode redéfinie
        public override void Renouveler(DateTime date)
        {
            base.Renouveler(date); // appel de la méthode de la classe ancêtre (MoyenPaiement)
            DateExpiration = DateExpiration.AddYears(2);
        }

        // Méthode redéfinie
        public override string ToString()
        {
            string s1 = base.ToString(); // appel de la méthode de la classe ancêtre (MoyenPaiement)

            string s2 = string.Format("Carte de N°{0}, de code secret {1} qui expire le {2:d}",
                NumCarte, CodeSecret, DateExpiration);

            return s1 + s2;
        }

        public override string Payer()
        {
            return string.Format("Le commerçant saisit le montant.\nJe compose mon code.\nLe commerçant me donne la facturette");
        }
    }

    public class Chéquier : MoyenPaiment
    {
        public int NombreChèques { get; set; }
        public long NumPremierChèque { get; set; }

        // Constructeur qui appelle celui de la classe ancêtre (MoyenPaiement)
        public Chéquier(long numCpt) : base(numCpt)
        {
            
        }

        // Méthode redéfinie
        public override void Renouveler(DateTime date)
        {
            base.Renouveler(date); // appel de la méthode de la classe ancêtre (MoyenPaiement)
            NumPremierChèque += NombreChèques;
        }

        // Méthode redéfinie
        public override string ToString()
        {
            // appel de la méthode de la classe ancêtre (MoyenPaiement)
            return base.ToString() + string.Format("Chéquier de {0} chèques, dont le premier a le N°{1}",
                NombreChèques, NumPremierChèque);
        }

        public override string Payer()
        {
            return string.Format("Je remplis et je signe le chèque. Je le donne au commerçant");
        }
    }
}
