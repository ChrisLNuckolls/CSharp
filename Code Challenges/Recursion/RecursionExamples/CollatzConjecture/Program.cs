using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollatzConjecture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input a whole number: ");
            Collatz(int.Parse(Console.ReadLine()));
        }//end Main()

        static void Collatz(int number)
        {
            Console.WriteLine(number);
            if (number > 1)
            {
                if (number % 2 == 1)
                {
                    Collatz(number * 3 + 1);
                }//end if number is odd
                else
                {
                    Collatz(number /= 2);
                }//end else number is even
            }//end if number > 1
            else
            {
                return;
            }//end else number == 1
        }//end Collatz()
    }
}
