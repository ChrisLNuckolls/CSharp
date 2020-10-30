using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; //added for Sleep()

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = 1;

            Console.Title = "FizzBuzz!";
            Console.Write("Let's play FizzBuzz!\nInput a number to which you would like to count: ");
            //FizzBuzz(int.Parse(Console.ReadLine()));
            FizzBuzzRecursive(startNumber, int.Parse(Console.ReadLine()));
            
        }//end Main()

        //using looping:
        static void FizzBuzz(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                string output = "";

                if (i % 3 == 0)
                {
                    output += "Fizz";
                }
                if (i % 5 == 0)
                {
                    output += "Buzz";
                }
                if (output == "")
                {
                    output += i.ToString();
                }
                Thread.Sleep(100);
                Console.WriteLine(output);
            }
        }//end looping method

        //recursively:
        //NOTE: taking the argument of pass allows us to later create functionality
        //to set a starting point other than 1.
        static void FizzBuzzRecursive(int start, int stop)
        {
            if (start <= stop)
            {
                string output = "";

                if (start % 3 == 0)
                {
                    output += "Fizz";
                }
                if (start % 5 == 0)
                {
                    output += "Buzz";
                }
                if (output == "")
                {
                    output += start.ToString();
                }
                Thread.Sleep(250);
                Console.WriteLine(output);
                start++;
                FizzBuzzRecursive(start, stop);
            }
            return;
        }//end recursive method
    }
}
