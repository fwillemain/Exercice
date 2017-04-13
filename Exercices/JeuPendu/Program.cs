using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JeuPendu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Jouez au pendu!\nSaisissez un mot : ");
            string mot = Console.ReadLine();
            Pendu jeu = null;

            // Tant que le mot est nul ou contient un espace
            while (string.IsNullOrWhiteSpace(mot) || mot.Contains(' '))
            {
                Console.Clear();
                
                // Affiche le message d'erreur en rouge
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Le mot ne doit pas contenir d'espace ni être vide.");
                Console.ResetColor();

                Console.WriteLine("Saisissez un mot : ");
                mot = Console.ReadLine();
            }

            Console.Clear();
            jeu = new Pendu(mot);
            Console.WriteLine("Mot en cours de déchiffrage : {0}", jeu.MotAAfficher);

            // Tant que le jeu n'est pas fini
            while (!jeu.Fini)
            {
                Console.WriteLine("Proposer une lettre.");
                string res = Console.ReadLine();

                // Si la lettre est vide ou null met par defaut un espace, sinon prendre le premier caractère
                char lettre = string.IsNullOrEmpty(res) ? ' ' : res[0];
                jeu.ProposerLettre(lettre);
                Console.Clear();

                // Choix de la couleur si gagné ou non quand le jeu est fini
                if (jeu.Fini)
                    Console.ForegroundColor = jeu.Gagné ? ConsoleColor.Green : ConsoleColor.Red;

                // Affichage de l'évolution du mot à déchiffrer
                Console.WriteLine("Mot en cours de déchiffrage : {0}, ({1}/11 erreur(s))", jeu.MotAAfficher, jeu.CompteurErreur);
                // Affichage du pendu
                Console.WriteLine(jeu.RetournerPendu());
            }

            // En pause pour 2s
            Thread.Sleep(2000);
            Console.Clear();

            // Affiche le mec vivant ou la tombe si tu as gagné ou non
            Console.WriteLine("{0}", jeu.Gagné ? jeu.RetournerHumain() : jeu.RetournerTombe());

            // Affichage du message en fonction de si tu as gagné ou non
            Console.WriteLine("{0}! Tu es {1}!", jeu.Gagné ? "Bravo" : "Dommage", jeu.Gagné ? "vivant" : "mort");
            Console.WriteLine("Le mot à deviner était : {0}.", jeu.MotADeviner);

            // En pause pour 5s
            Thread.Sleep(5000);
        }

        class Pendu
        {
            #region Propriétés
            public string MotAAfficher { get; private set; }
            public bool Fini { get; private set; }
            public bool Gagné { get; private set; }
            public int CompteurErreur { get; private set; }
            public string MotADeviner { get; }
            #endregion

            #region Constructeurs
            public Pendu(string mot)
            {
                MotADeviner = mot.ToLower();
                MotAAfficher = InitialiserMAA(MotADeviner);
                Fini = false;
                Gagné = false;
                CompteurErreur = 0;
            }
            #endregion

            #region Méthode privée
            private string InitialiserMAA(string mot)
            {
                string res = string.Empty;

                for (int i = 0; i < mot.Length; i++)
                    // Remplace les lettres par '_' et garde les caractères spéciaux tel quels
                    res += char.IsLetter(mot[i]) ? '_' : mot[i];
                return res;
            }
            #endregion

            #region Méthodes public
            public void ProposerLettre(char l)
            {
                // Si le mot à déchiffrer contient la lettre indiquée
                if (MotADeviner.Contains(l))
                {
                    int index = 0;
                    // Pour pouvoir modifier en live une lettre à un index d'un string (qui est read-only)
                    char[] tmp = MotAAfficher.ToCharArray();

                    // Tant que toutes les occurences de la lettre n'ont pas été sélectionnées dans le mot 
                    while ((index = MotADeviner.IndexOf(l, index)) != -1)
                    {
                        tmp[index] = l;

                        // Si on arrive au bout du mot, index = valeur pour sortir de la boucle while
                        if (index++ >= MotADeviner.Length)
                            index = -1;
                    }

                    // Maj MotAAfficher avec le string modifié
                    MotAAfficher = new string(tmp);
                }
                // Si la lettre n'est pas dans le mot
                else
                    CompteurErreur++;

                // Si il me reste des lettres à trouver ou j'ai trop d'erreurs
                if (!MotAAfficher.Contains('_') || CompteurErreur > 10)
                {
                    Fini = true;
                    if (CompteurErreur < 11)
                        Gagné = true;
                }
            }

            public string RetournerPendu()
            {
                string res = string.Empty;
                // Choisi l'affichage du pendu à renvoyer en fonction du compteur d'erreur
                switch (CompteurErreur)
                {
                    case 1:
                        res = @"

 
    
   
    
____";
                        break;
                    case 2:
                        res = @"

|
|   
|  
|   
|____";
                        break;
                    case 3:
                        res = @"
____
|
|   
|  
|   
|____";
                        break;
                    case 4:
                        res = @"
____
|/  
|   
|  
|   
|____";
                        break;
                    case 5:
                        res = @"
____
|/  |
|   
|  
|   
|____";
                        break;
                    case 6:
                        res = @"
____
|/  |
|   o
|  
|   
|____";
                        break;
                    case 7:
                        res = @"
____
|/  |
|   o
|   |
|   
|____";
                        break;
                    case 8:
                        res = @"
____
|/  |
|   o
|  /|
|   
|____";
                        break;
                    case 9:
                        res = @"
____
|/  |
|   o
|  /|\
|   
|____";
                        break;
                    case 10:
                        res = @"
____
|/  |
|   o
|  /|\
|  / 
|____";
                        break;
                    case 11:
                        res = @"
____
|/  |
|  ~o~
|  /|\
|  / \
|____";
                        break;
                    default:
                        res = @"

 
    
   
    
";
                        break;
                }
                return res;
            }

            public string RetournerTombe()
            {
                return @"
                        __
                     __|  |__
                    |__    __|
                       |  |
                _______|  |______";
            }

            public string RetournerHumain()
            {
                return @"
____
|/  |
|             \o/
|              |
|____         / \";
            }
            #endregion
        }
    }
}