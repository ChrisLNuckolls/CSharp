using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareShapeArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a value to calculate the number of squares: ");
            Console.WriteLine(ShapeArea(int.Parse(Console.ReadLine())));
        }

        static int ShapeArea(int n)
        {
            int a = 1;
            int b = 0;
            int c = 0;


            for (int i = 1; i <= n; i++)
            {
                c = a + b;
                b += 4;
                a = c;
            }

            return a;
        }
    }
}
