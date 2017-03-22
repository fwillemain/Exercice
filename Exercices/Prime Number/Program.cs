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
            resultat = NombrePremier(nombreNPVoulu);

            Console.WriteLine("Les " + nombreNPVoulu + " premiers nombres premiers sont : " + resultat);
            Console.ReadKey();

        }

        static string NombrePremier(int nombreNPVoulu)
        {
            string resultat = "";               // Liste des nombres premiers
            int n;  
            int chiffreTesté = 2;               // Chiffre que je suis en train de testé    
            int compteur = 0;                   // Nombre de nombres premiers actuellement trouvés
            bool estUnNombrePremier;     

            while (compteur < nombreNPVoulu) 
            {
                n = 2;
                estUnNombrePremier = true;
                while (n < (chiffreTesté / 2) && estUnNombrePremier == true)
                {
                    if(chiffreTesté % n == 0)
                    {
                        estUnNombrePremier = false;
                    }
                    n++;
                }

                if (estUnNombrePremier)
                {
                    resultat += chiffreTesté;
                    resultat += " ";
                    compteur++;
                }

                chiffreTesté++;
            }

            return resultat;
        }
    }
}
