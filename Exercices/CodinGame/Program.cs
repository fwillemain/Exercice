using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodinGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
            int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis

            Coord node, right, down;

            string[] imputs = new string[height];

            for (int i = 0; i < height; i++)
            {
                imputs[i] = Console.ReadLine(); // width characters, each either 0 or .
            }

            for (int i = 0; i < height; i++)
            {
                int j = 0;
                while (j < width)
                {
                    node = new Coord(-1, -1);
                    right = new Coord(-1, -1);
                    down = new Coord(-1, -1);

                    if (imputs[j][i] == '0')
                    {
                        node.X = j;
                        node.Y = i;

                        int h = i + 1;
                        while (h < height && imputs[h][j] != '0')
                            h++;

                        if (h < height)
                        {
                            down.X = j;
                            down.Y = h;
                        }

                        int w = j + 1;
                        while (w < width && imputs[i][w] != 0)
                            w++;

                        if (w < width)
                        {
                            right.X = w;
                            right.Y = i;
                        }

                        j = w;
                        // Three coordinates: a node, its right neighbor, its bottom neighbor
                        Console.WriteLine("{0} {1} {2} {3} {4} {5}", node.X, node.Y, right.X, right.Y, down.X, down.Y);
                    }
                    else
                        j++;
                }
            }
            Console.ReadKey();
        }

        public struct Coord
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Coord(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
