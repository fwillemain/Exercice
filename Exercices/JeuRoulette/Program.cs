using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuRoulette
{
    class Program
    {
        static void Main(string[] args)
        {
            Jeu jeu = new Jeu();
            jeu.Jouer();
            Console.ReadKey();
        }
    }
}
