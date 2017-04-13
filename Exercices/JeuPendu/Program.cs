using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            if (mot.Contains(' '))
                Console.WriteLine("Le mot ne doit pas contenir d'espace.");
            else
            {
                Console.Clear();
                jeu = new Pendu(mot);
                Console.WriteLine("Mot en cours : {0}", jeu.MotAAfficher);
                while (!jeu.Fini)
                {
                    Console.WriteLine("Proposer une lettre.");
                    string res = Console.ReadLine();
                    char lettre = string.IsNullOrEmpty(res) ? ' ' : res[0];
                    jeu.ProposerLettre(lettre);
                    Console.Clear();
                    Console.WriteLine("Mot en cours : {0}", jeu.MotAAfficher);
                    Console.WriteLine(jeu.RetournerPendu());
                }
                Console.WriteLine("Tu as {0}!", jeu.Gagné ? "gagné" : "perdu");
            }

            Console.ReadKey();
        }

        class Pendu
        {

            #region Champs privés
            private string _motADeviner; 
            #endregion

            #region Propriétés
            public string MotAAfficher { get; private set; }
            public bool Fini { get; private set; }
            public bool Gagné { get; private set; }
            public int CompteurErreur { get; private set; }
            #endregion

            #region Constructeurs
            public Pendu(string mot)
            {
                _motADeviner = mot.ToLower();
                MotAAfficher = InitialiserMAA(_motADeviner);
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
                    res += char.IsLetter(mot[i]) ? '_' : mot[i];
                return res;
            }

            #endregion

            #region
            public void ProposerLettre(char l)
            {
                if (_motADeviner.Contains(l))
                {
                    int index = 0;
                    while ((index = _motADeviner.IndexOf(l, index)) != -1)
                    {
                        char[] tmp = MotAAfficher.ToCharArray();
                        tmp[index] = l;
                        MotAAfficher = new string(tmp);
                        if (index++ >= _motADeviner.Length)
                            index = -1;
                    }

                }
                else
                    CompteurErreur++;

                // Si il me reste des lettres à trouver ou j'ai trop d'erreurs
                if (!MotAAfficher.Contains('_') || CompteurErreur == 11)
                {
                    Fini = true;
                    if (CompteurErreur < 11)
                        Gagné = true;
                }
            }

            public string RetournerPendu()
            {
                string res = string.Empty;
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
___";
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
|   o
|  /|\
|  / \
|____";
                        break;
                    //TODO : faire l'affichage du pendu
                    default:
                        res = @"

 
    
   
    
";
                        break;
                }
                return res;
            }

            #endregion

        }
    }
}