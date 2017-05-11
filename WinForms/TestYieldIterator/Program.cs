using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestYieldIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] toCompute = new int[] { 12, 21, 40, 3, 78 };
            //foreach (int computedValue in GetComputedValues(toCompute))
            //{
            //    if (computedValue > 150)
            //    {
            //        Console.WriteLine(computedValue);
            //        break;
            //    }
            //}

            //int i = 0;
            //Console.WriteLine(i.GetNext());

            //foreach (int c in LaunchCountdown(5))
            //{
            //    Console.WriteLine(c);
            //    if (c == 0) break;
            //}

            // Comment faire la requete en Linq pointé?
            // ToArray()/ToList() nécessaire pour passer de l'évaluation paresseuse à celle stricte, mieux si utilisée dans une cascade de requetes LINQ qui s'appellent entre elles

            var deck = (from couleur in Carte.GetCouleur()
                        from rang in Carte.GetRang()
                        select new Carte(couleur, rang)).ToList();

            Console.WriteLine("Deck avant l'entremelage :");
            foreach (var c in deck)
                Console.WriteLine(c);

            var shuffle = deck.Skip(26).EntremelerAvec(deck.Take(26));

            Console.WriteLine("\nDeck après l'entremelage :");
            foreach (var c in shuffle)
                Console.WriteLine(c);

            Console.ReadKey();
        }

        static public IEnumerable GetComputedValues(int[] toCompute)
        {
            foreach (int i in toCompute)
            {
                Thread.Sleep(1000);
                yield return i * i;
            }
        }

        [Obsolete("Je suis un test d'attribut obsolete")]
        static public IEnumerable LaunchCountdown(int begin)
        {
            // Le yield return permet une gestion asynchrone de l'appel de la fonction, le compilateur ne rale donc pas sur le return dans une boucle while(true)
            // Attention, une condition doit permettre l'arrêt de l'appel à la méthode LaunchCountdown dans le code appelant
            while (true)
            {
                Thread.Sleep(1000);
                yield return begin--;
            }
        }

    }

    static public class Test
    {
        // Méthode d'extension sur le type int
        public static int GetNext(this int i)
        {
            return ++i;
        }
    }

    public enum Couleurs { Pique, Coeur, Trèfle, Carreau };
    public enum Rangs { As, Deux, Trois, Quatre, Cinq, Six, Sept, Huit, Neuf, Dix, Valet, Dame, Roi };

    public class Carte
    {
        public Couleurs Couleur { get; }
        public Rangs Rang { get; }

        public Carte(Couleurs c, Rangs r)
        {
            Couleur = c;
            Rang = r;
        }

        public override string ToString()
        {
            return $"{Rang} de {Couleur}";
        }

        static public IEnumerable<Couleurs> GetCouleur()
        {
            yield return Couleurs.Carreau;
            yield return Couleurs.Coeur;
            yield return Couleurs.Pique;
            yield return Couleurs.Trèfle;
        }

        static public IEnumerable<Rangs> GetRang()
        {
            yield return Rangs.As;
            yield return Rangs.Deux;
            yield return Rangs.Trois;
            yield return Rangs.Quatre;
            yield return Rangs.Cinq;
            yield return Rangs.Six;
            yield return Rangs.Sept;
            yield return Rangs.Huit;
            yield return Rangs.Neuf;
            yield return Rangs.Dix;
            yield return Rangs.Valet;
            yield return Rangs.Dame;
            yield return Rangs.Roi;
        }
    }

    static public class IEnumerableCarteHandler
    {
        static public IEnumerable<Carte> EntremelerAvec(this IEnumerable<Carte> deck1, IEnumerable<Carte> deck2)
        {
            var enumDeck1 = deck1.GetEnumerator();
            var enumDeck2 = deck2.GetEnumerator();

            // Tant qu'un des deux decks n'a pas été parcourru entièrement, renvoyer alternativement une carte de chaque deck
            while (enumDeck1.MoveNext() && enumDeck2.MoveNext())
            {
                yield return enumDeck1.Current;
                yield return enumDeck2.Current;
            }

            // Renvoi le reste du deck1 si il n'a pas été parcouru complètement
            while (enumDeck1.MoveNext())
                yield return enumDeck1.Current;

            // Pareil pour le deck2 
            while (enumDeck2.MoveNext())
                yield return enumDeck2.Current;
        }
    }






}
