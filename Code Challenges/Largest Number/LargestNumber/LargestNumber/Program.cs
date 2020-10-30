using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestNumber
{
    /*
    Given an integer n, return the largest number that contains exactly n digits.

    Example

    For n = 2, the output should be
    largestNumber(n) = 99.
    */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a number: ");
            Console.WriteLine(LargestNumber(int.Parse(Console.ReadLine())));
        }

        static int LargestNumber(int n)
        {
            string newValue = "";
            for (int i = 0; i < n; i++)
            {
                newValue += "9";
            }
            return int.Parse(newValue);
        }
    }
}
