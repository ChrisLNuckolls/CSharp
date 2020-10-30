using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FibonacciSequence
{
    class Program
    {
        //Global variables
        static int n1 = 0;
        static int n2 = 1;
        static int n3 = n1 + n2;

        static void Main(string[] args)
        {
            Console.WriteLine("Fibonacci Sequence");
            Console.Write("Enter a whole number to which I should count: ");
            Fibonacci(int.Parse(Console.ReadLine()));

        }//end Main()

        static void Fibonacci(int stop)
        {
            if (stop >= n3)
            {
                Console.WriteLine(n3);

                n1 = n2;
                n2 = n3;
                n3 = n1 + n2;

                Fibonacci(stop);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Fibonacci sequence complete!");
                Console.ResetColor();
                return;
            }
        }//end Fibonacci()
    }
}
