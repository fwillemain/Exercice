using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer
{
    public delegate void DelegueAnalyser(FileInfo fi);

    class Program
    {
        static void Main(string[] args)
        {
            string path = string.Empty;
            while (!Directory.Exists(path))
            {
                Console.WriteLine("Saisissez le chemin d'un dossier.");
                path = Console.ReadLine();
            }

            Analyseur analyseur = new Analyseur();
            analyseur.AnalyserDossier(path);

            // Affichage
            Console.WriteLine("Il y a {0} fichiers dans le dossier {1} dont {2} fichiers \".cs\".", analyseur.CompteurFichiers, path, analyseur.CompteurFichiersCs);
            Console.WriteLine("Le nom de fichier le plus long est : {0}.", analyseur.NomFichierLePlusLong);

            Console.WriteLine("Le dossier contient les fichiers .csproj suivant :");
            foreach (var f in analyseur.ListeFichiersCsproj)
                Console.WriteLine(f);


            Console.ReadLine();
        }
    }

    public class Exploreur
    {
        static public void Analyser(string path, DelegueAnalyser delegue)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            var files = dir.GetFiles("*.*", SearchOption.AllDirectories);
            foreach(var f in files)
                delegue(f);
        }
    }

    public class Analyseur
    {
        public int CompteurFichiers { get; set; }
        public int CompteurFichiersCs { get; set; }
        public string NomFichierLePlusLong { get; set; }
        public List<string> ListeFichiersCsproj { get; set; }

        public Analyseur()
        {
            ListeFichiersCsproj = new List<string>();
        }

        private void CompterNbFichierDontCs(FileInfo fi)
        {
            CompteurFichiers++;
            if (fi.Extension == ".cs")
                CompteurFichiersCs++;
        }

        private void RécupérerFichierLePlusLong(FileInfo fi)
        {
            string fileName = Path.GetFileName(fi.Name);
            if (string.IsNullOrEmpty(NomFichierLePlusLong) || NomFichierLePlusLong.Length < fileName.Length)
                NomFichierLePlusLong = fileName;
        }

        private void RécupérerListeFichierCsproj(FileInfo fi)
        {
            if (fi.Extension == ".csproj")
                ListeFichiersCsproj.Add(Path.GetFileNameWithoutExtension(fi.Name));
        }

        public void AnalyserDossier(string path)
        {
            DelegueAnalyser delegue = null;
            delegue += CompterNbFichierDontCs;
            delegue += RécupérerFichierLePlusLong;
            delegue += RécupérerListeFichierCsproj;

            Exploreur.Analyser(path, delegue);
        }
    }
}
