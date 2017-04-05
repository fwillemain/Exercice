using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    public interface IAlertable
    {
    }

    public abstract class Alertable : IAlertable
    {
        IAlertable _alertable;

        public Alertable(IAlertable alertable)
        {
            _alertable = alertable;
        }

        public abstract void AlerterClient();
    }

    public class CompteBancaireAltertable : Alertable 
    {
        public CompteBancaireAltertable(IAlertable c) : base(c)
        {
        }

        public override void AlerterClient()
        {
            Console.WriteLine("Client alerté!!");
        }
    }

    public class BoiteAlertable : Alertable
    {
        public BoiteAlertable(IAlertable b) : base(b)
        {

        }
        public override void AlerterClient()
        {
            Console.WriteLine("Boite alertée!!");
        }
    }

}
