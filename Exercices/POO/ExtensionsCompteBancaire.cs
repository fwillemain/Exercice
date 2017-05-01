using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    static class ExtensionsCompteBancaire
    {
        static public void Etendre(this CompteBancaire cb)
        {
            Console.WriteLine("Extension");
        }

    }
}
