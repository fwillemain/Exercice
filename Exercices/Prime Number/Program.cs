using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int nombreNPVoulu;
            string saisie, resultat;

            Console.WriteLine("Combien veux-tu de nombres premiers !?");
            saisie = Console.ReadLine();

            nombreNPVoulu = int.Parse(saisie);
            resultat = CalculNombresPremiers(nombreNPVoulu);

            Console.WriteLine("Les " + nombreNPVoulu + " premiers nombres premiers sont : " + resultat);
            Console.ReadKey();

        }

        static string CalculNombresPremiers(int nombreNPVoulu)
        {
            string resultat = "";               // Liste des nombres premiers
            int chiffreDiviseur;                // Chiffre par lequel le chiffre à tester sera divisé
            int chiffreATester = 2;             // Chiffre que je suis en train de testé    
            int compteur = 0;                   // Nombre de nombres premiers actuellement trouvés
            bool estUnNombrePremier;     

            while (compteur < nombreNPVoulu) 
            {
                chiffreDiviseur = 2;
                estUnNombrePremier = true;
                while (chiffreDiviseur <= (chiffreATester / 2) && estUnNombrePremier == true)
                {
                    if(chiffreATester % chiffreDiviseur == 0)
                        estUnNombrePremier = false;
                    else
                        chiffreDiviseur++;
                }

                if (estUnNombrePremier)
                {
                    resultat += chiffreATester;
                    resultat += " ";
                    compteur++;
                }

                chiffreATester++;
            }

            return resultat;
        }
    }
}
