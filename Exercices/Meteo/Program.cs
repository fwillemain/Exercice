using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteo
{
    class Program
    {
        static void Main(string[] args)
        {
            string chemin = @"..\..\DonnéesMétéoParis.txt";

            try
            {
                string[] donnees = ChargerFichierMeteo(chemin);

                double tempMin, tempMax;
                DateTime dateTempMin, dateTempMax;
                RechercherRecordTemperature(donnees, out tempMin, out dateTempMin, out tempMax, out dateTempMax);

                Console.WriteLine("Il a fait le plus froid le {0} ({1}°C)", dateTempMin, tempMin);
                Console.WriteLine("Il a fait le plus chaud le {0} ({1}°C)", dateTempMax, tempMax);
            }
            catch (IOException e)
            {
                Console.WriteLine("Impossible d'accéder correctement au fichier {0}. {1}", chemin, e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Impossible d'afficher le résultat. {0}", e);
            }

            Console.ReadKey();
        }

        static string[] ChargerFichierMeteo(string chemin)
        {
            return File.ReadAllLines(chemin);
        }

        static void RechercherRecordTemperature(string[] donnees, out double tempMin, out DateTime dateTempMin,
                                                                out double tempMax, out DateTime dateTempMax)
        {
            string[] donneesJour;
            double tempMinJour;
            double tempMaxJour;
            DateTime dateJour;


            tempMin = double.MaxValue;
            tempMax = double.MinValue;
            dateTempMin = DateTime.Today;
            dateTempMax = DateTime.Today;

            for (int i = 1; i < donnees.Length; i++)
            {
                donneesJour = donnees[i].Split('\t');

                try
                {
                    dateJour = DateTime.Parse(donneesJour[0]);
                    tempMinJour = double.Parse(donneesJour[1]);
                    tempMaxJour = double.Parse(donneesJour[2]);

                    if (tempMinJour < tempMin)
                    {
                        tempMin = tempMinJour;
                        dateTempMin = dateJour;
                    }

                    if (tempMaxJour > tempMax)
                    {
                        tempMax = tempMaxJour;
                        dateTempMax = dateJour;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erreur formatage de données sur la ligne {0}.", i + 1);
                }
            }
        }
    }
}
