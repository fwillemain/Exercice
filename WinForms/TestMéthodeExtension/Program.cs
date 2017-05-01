using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMéthodeExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Objet> list = new List<Objet>();

            Objet obj = new Objet("coucou");
            list.Add(obj);

            for (int i = 0; i < 10; i++)
                list.Add(new Objet(i, i * i));

            float x = 3;
            float y = 9;

            var res = list.GetFirstElementInPosition(x, y);
            if (res == null)
                Console.WriteLine("Pas d'objet à la position ({0},{1}).", x, y);
            else
                Console.WriteLine(res);

            foreach (var o in list)
                Console.WriteLine("Le nom \"{0}\" de l'objet n°{1} {2} été choisi par défaut.", o.Nom, o.Numéro, o.IsNameDefault() ? "a" : "n'a pas");

            Console.WriteLine(list.GetFirstDefaultObject());

            Console.ReadKey();

            List<int> test = new List<int>();
             // Ne compile pas car test ne contient pas d'élément qui implémente l'interface IPosition (ici int)
            //test.GetFirstElementInPosition(x, y);

            // Ne compile pas car test n'est pas une collection d'Objet
            //test.test.GetFirstDefaultObject();
        }
    }
}
