using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsDivisibleByThree
{
    /*
    This program takes input from a user and determines if the total of the numbers is divisible by 3
    without using modulus.
    TODO - modify functionality to check for divisibility by any single-digit number.
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input a whole number to determine if it is divisible by three: ");
            Console.WriteLine(DivideByThree(Console.ReadLine()) ? "Divisible by three" : "Not divisible by three");
        }

        static bool DivideByThree(string input)
        {
            int total = 0;
            for (int i = 0; i < input.Length; i++)
            {
                total += int.Parse(input[i].ToString());
            }

            while (total.ToString().Length > 1)
            {
                int newTotal = 0;
                string totalString = total.ToString();
                for (int i = 0; i < totalString.Length; i++)
                {
                    newTotal += int.Parse(totalString[i].ToString());
                }
                total = newTotal;
            }//pares total down to a single digit

            if (total == 3 || total == 6 || total == 9)
            {
                return true;
            }

            return false;
        }
    }
}
