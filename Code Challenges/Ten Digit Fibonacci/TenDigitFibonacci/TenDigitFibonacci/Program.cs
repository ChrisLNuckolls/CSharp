using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenDigitFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            //The Fibonacci sequence is defined by the recurrence relation:

            //Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.
            //Hence the first 12 terms will be:

            //F1 = 1
            //F2 = 1
            //F3 = 2
            //F4 = 3
            //F5 = 5
            //F6 = 8
            //F7 = 13
            //F8 = 21
            //F9 = 34
            //F10 = 55
            //F11 = 89
            //F12 = 144
            //The 12th term, F12, is the first term to contain 
            //three digits.

            //What is the index of the first term in the 
            //Fibonacci sequence to contain 10 digits?
            long val1 = 0;
            long val2 = 0;
            long val3 = 1;
            int index = 1;

            while (val3.ToString().Length < 10)
            {
                Console.WriteLine(val3);

                val1 = val2;
                val2 = val3;
                val3 = val1 + val2;
                index++;
            }

            Console.WriteLine("The first ten digit number is "
                + val3 + " at index " + index);
        }
    }
}
