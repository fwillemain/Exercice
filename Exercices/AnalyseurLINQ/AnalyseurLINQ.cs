using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace AnalyseurLINQ
{
    public class AnalyseurLINQ
    {
        private List<DonnéesMois> _data;
        public List<DonnéesMois> Data
        {
            get { return _data; }
        }
        public AnalyseurLINQ()
        {
            _data = new List<DonnéesMois>();
        }
        public void ChargerDonnées()
        {
            string chemin = @"..\..\DonnéesMétéoParis.txt";

            int cpt = 0;
            using (StreamReader str = new StreamReader(chemin))
            {
                string ligne;

                while ((ligne = str.ReadLine()) != null)
                {
                    cpt++;
                    if (cpt == 1) continue; // On n'analyse pas la première ligne car elle contient les en-têtes

                    var tab = ligne.Split('\t');
                    try
                    {
                        var donnéesMois = new DonnéesMois
                        {
                            Mois = DateTime.Parse(tab[0]),
                            TMin = double.Parse(tab[1]),
                            TMax = double.Parse(tab[2]),
                            Précipitations = double.Parse(tab[3]),
                            Ensoleillement = double.Parse(tab[4])
                        };

                        // Ajout des données du mois à la liste
                        Data.Add(donnéesMois);
                    }
                    catch (FormatException)
                    {
                        // On ignore simplement la ligne
                        Console.WriteLine("Erreur de format à la ligne suivante :\r\n{0}", ligne);
                    }
                }
            }
        }
        public void AfficherStats()
        {
            // mois de la température min la plus basse
            DonnéesMois dataMoisRecordTMin = Data.Where(n => n.TMin == Data.Min(c => c.TMin)).First();
            Console.WriteLine("Il a fait le plus froid ({0}°C) le {1:d}.", dataMoisRecordTMin.TMin, dataMoisRecordTMin.Mois);
            Console.WriteLine();

            // Sommes des précipitations de l'année 2016
            double sommePre2016 = Data.Where(n => n.Mois.Year == 2016).Sum(c => c.Précipitations);
            Console.WriteLine("La somme des précipitations de 2016 est : {0} mm.", Math.Round(sommePre2016, 2));
            Console.WriteLine();

            // Durée d'ensoleillement moyenne du mois de Juillet sur toutes les années
            double duréeEnsoJuillet = Data.Where(n => n.Mois.Month == 7).Average(c => c.Ensoleillement);
            Console.WriteLine("La durée d'ensoleillement moyen du mois de Juillet sur toutes les années est : {0} min.", duréeEnsoJuillet);
            Console.WriteLine();

            // Précipitations moyennes par année
            var années = Data.Select(n => n.Mois.Year).Distinct();
            double res;
            foreach (var a in années)
            {
                res = Data.Where(n => n.Mois.Year == a).Average(c => c.Précipitations);
                Console.WriteLine("La moyenne des précipitations de l'année {0} est : {1} mm.", a, Math.Round(res, 2));
            }
        }
    }

    /// <summary>
    /// Classe contenant les données d'un mois de relevé météo
    /// </summary>
    public class DonnéesMois
    {
        public DateTime Mois { get; set; }
        public double TMin { get; set; }
        public double TMax { get; set; }
        public double Précipitations { get; set; }
        public double Ensoleillement { get; set; }
    }
}
