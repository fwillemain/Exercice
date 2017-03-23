using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string login = string.Empty;
            string mdp = string.Empty;

            bool loginValide = false;
            bool mdpValide = false;

            while (!loginValide)
            {
                try
                {
                    login = SaisirLogin();
                    VerifierLogin(login, ref loginValide);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (!mdpValide)
            {
                try
                {
                    mdp = SaisirMdp();
                    VerifierMdp(mdp, ref mdpValide);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            Console.WriteLine("Compte bien créé, votre login est {0} et votre mdp {1}.", login, mdp);
            Console.ReadKey();
        }

        static string SaisirLogin()
        {
            Console.Write("Saisir un login d'au moins 5 caractères : ");
            string login = Console.ReadLine();
            return login;
        }

        static string SaisirMdp()
        {
            Console.Write("Saisir un mdp entre 6 et 12 caractères (ne doit pas commencer ou finir par un espace) : ");
            string mdp = Console.ReadLine();
            return mdp;
        }

        static void VerifierLogin(string login, ref bool valide)
        {

            if (login.Length < 5)
                throw new FormatException("Erreur de saisie : le login doit contenir au moins 5 caractères.");
            
            valide = true;
        }

        static void VerifierMdp(string mdp, ref bool valide)
        {
            if (mdp.Length < 6)
                throw new FormatException("Erreur de saisie : le mdp doit contenir au moins 6 caractères.");

            if (mdp.Length > 12)
                throw new FormatException("Erreur de saisie : le mdp doit contenir au maximum 12 caractères.");

            if (mdp[0].Equals(' '))
                throw new FormatException("Erreur de saisie : le mdp ne peut pas commencer par un espace.");

            if (mdp[mdp.Length - 1].Equals(' '))
                throw new FormatException("Erreur de saisie : le mdp ne peut pas finir par un espace.");

            valide = true;
        }
    }
}
