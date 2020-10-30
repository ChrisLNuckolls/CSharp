using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoDigits
{
    class Program
    {
        #region Requirements
        /*
        You are given a two-digit integer n. Return the sum of its digits.

        Example:

        For n = 29, the output should be
        addTwoDigits(n) = 11.
        */
        #endregion


        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Write("Input a two-digit number to get a total of its digits: ");
                int input = int.Parse(Console.ReadLine());
                if (input.ToString().Length == 2)
                {
                    Console.WriteLine($"The total is {addTwoDigits(input)}");
                    exit = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please input a number that is exactly two digits.");
                }
            }
        }

        static int addTwoDigits(int n)
        {
            string digits = n.ToString();

            int total = int.Parse(digits[0].ToString()) + int.Parse(digits[1].ToString());

            return total;
        }
    }
}
