using System;
using System.Threading;

namespace FibonacciEvenSum
{
    /*
    Challenge: Using a Fibonacci sequence, show the output from each loop as well as a 
    running total value of all even numbers.
    NOTE: This version adds new functionality to the basic Fibonacci recursion method
    to keep track of and output the even number value. It also refactors several parts 
    of the original code to make it slightly more efficient or to add new
    functionality.
    */
    class Program
    {
        static int n1 = 0;
        static int n2 = 1;
        static int n3 = n1 + n2;
        static int evenValue = 0;
        static int count;

        static void Main(string[] args)
        {
            Console.WriteLine("Fibonacci Sequence");
            Console.Write("Enter a whole number to which I should count: ");
            string userValue = Console.ReadLine();

            if (int.TryParse(userValue, out count))
            {
                Fibonacci(count);
            }
            else
            {
                Console.WriteLine("That is not a valid numeric value.");
            }

            //Fibonacci(int.Parse(Console.ReadLine()));
        }//end Main()

        static void Fibonacci(int stop)
        {
            //if (stop == 0)
            //{
            //    Console.WriteLine("I cannot count to zero.");
            //}
            //else if (stop >= n3)
            if (stop >= n3)
            {
                Console.WriteLine(n3);

                if (n3 % 2 == 0 && evenValue < n3)
                {
                    evenValue += n3;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Even total: {evenValue}");
                    Console.ResetColor();
                }

                n1 = n2;
                n2 = n3;
                n3 = n1 + n2;

                Thread.Sleep(333);
                if (n3 > stop)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Fibonacci sequence complete!");
                    Console.ResetColor();
                }
                Fibonacci(stop);
                //Console.WriteLine($"Even total: {evenValue}");
                //The above shows how the value is only output when the stack is released
            }
            else
            {
                return;
            }
        }//end Fibonacci()
    }
}
