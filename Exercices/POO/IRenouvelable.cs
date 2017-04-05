using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    public interface IRenouvelable
    {
        void Renouveler(DateTime date);

        DateTime DateRenouvellement { get; }
    }
}
