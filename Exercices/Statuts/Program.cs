using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stat
{
    [Flags]
    public enum Statuts
    {
        Aucun = 0,
        CDI = 1,
        CDD = 2,
        DP = 4,
        CHSCT = 8,
        SYND = 16
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Personne> liste = new List<Personne>() {
                new Personne("TURPIN", "Abel", Statuts.CDI),
                new Personne("BONNEAU", "Achille", Statuts.CDD | Statuts.DP),
                new Personne("BLONDEL", "Adelphe", Statuts.CDI | Statuts.DP | Statuts.CHSCT | Statuts.SYND),
                new Personne("BLACK", "Aimé", Statuts.CDI),
                new Personne("PERRIER", "Aimée", Statuts.CDI),
                new Personne("JORDAN", "Alain", Statuts.CDD | Statuts.CHSCT),
                new Personne("BAUDRY", "Alban", Statuts.CDD),
                new Personne("ORLEANS", "Albert", Statuts.CDI | Statuts.DP | Statuts.SYND),
                new Personne("VALOIS", "Alexandra", Statuts.CDI | Statuts.SYND),
                new Personne("WEST", "Alexandre", Statuts.CDI | Statuts.DP | Statuts.CHSCT) };

            List<Personne> listeCddChsct = new List<Personne>();
            List<Personne> listeCdiDp = new List<Personne>();

            Statuts masque1 = Statuts.CDD | Statuts.CHSCT;
            Statuts masque2 = Statuts.CDI | Statuts.DP;

            // Pour enlever le statut CDI à la première personne de ma liste
            liste[0].Statut &= ~Statuts.CDI;

            // Pour rajouter le statut CDI à la première personne de ma liste
            liste[0].Statut |= Statuts.CDI;

            foreach (var a in liste)
            {
                // Si qualif CDD & CHSCT
                if ((a.Statut & masque1) == masque1)
                    listeCddChsct.Add(a);

                // Si qualif CDI & DP
                if ((a.Statut & masque2) == masque2)
                    listeCdiDp.Add(a);

                // Si qualif CDI ou DP
                if ((a.Statut & masque2) == a.Statut)
                { }
            }

            Console.WriteLine("Personnes avec au moins CDD & CHSCT :");
            foreach (var a in listeCddChsct)
                Console.WriteLine(a);

            Console.WriteLine();
            Console.WriteLine("Personnes avec au moins CDI & DP :");
            foreach (var a in listeCdiDp)
            {
                Console.WriteLine(a);
                // Rajout d'une qualif CHSCT
                a.Statut |= Statuts.CHSCT;
                Console.WriteLine("Rajout CHSCT");
                Console.WriteLine(a);
            }

            Console.ReadKey();
        }
    }
}
