using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyseurLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            AnalyseurLINQ aLinq = new AnalyseurLINQ();
            aLinq.ChargerDonnées();
            aLinq.AfficherStats();

            Console.ReadKey();
        }
    }
}
