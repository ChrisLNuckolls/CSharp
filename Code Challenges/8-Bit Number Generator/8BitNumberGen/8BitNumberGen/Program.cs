using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Challenge: build a random number generator that creates an 8-bit value (0-255)
the same way that values are stored in memory: by creating 8 character cells
that can store a value of 0 or 1. Each cell represents a doubling of the 
previous value, starting with one, and if a value of 1 is stored in the cell
its value will be included when then total values of all character cells
are totaled. Otherwise, it will not be included.

Examples: 
1) if all cells had a value of 1 the total would be 255.
2) if all cells has a value of 0 the total would be 0.
3) if the cells for values 1, 2, and 8 had a value of 1 the total would be 11.
*/

namespace _8BitNumberGen
{
    class Program
    {
        static void Main(string[] args)
        {
            bool reload = true;
            Random rand = new Random();
            List<int> numbers = new List<int>();//I tried to make this a byte array, but the Average method was not available to it.
            int quantity = 0;

            while (reload)
            {
                byte randomNbr = 0;
                byte basis = 1;
                int tempNbr;

                for (int i = 1; i <= 8; i++)
                {
                    tempNbr = rand.Next(2);

                    if (tempNbr == 1)
                    {
                        randomNbr += basis;
                    }//end if

                    basis *= 2;
                }//end for
                numbers.Add(randomNbr);
                Console.WriteLine(randomNbr);

                switch (randomNbr)
                {
                    case 255:
                        Console.WriteLine("Max value!");
                        break;
                    case 230:
                        Console.WriteLine("It's tooth hurty. Time to go to the dentist!");
                        break;
                    case 81:
                        Console.WriteLine("9 squared!");
                        break;
                    case 42:
                        Console.WriteLine("The answer to life, the universe and everything.");
                        break;
                    case 13:
                        Console.WriteLine("Dang! That's unlucky...");
                        break;
                    case 0:
                        Console.WriteLine("No way! Min value!");
                        break;
                }//end switch

                bool doAgain = true;

                while (doAgain)
                {
                    Console.WriteLine("Again? Y/N");
                    ConsoleKey response = Console.ReadKey().Key;
                    //string userResponse = Console.ReadLine().ToUpper();

                    switch (response)
                    {
                        case ConsoleKey.Y:
                            doAgain = false;
                            break;

                        case ConsoleKey.N:
                            doAgain = false;
                            reload = false;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("I don't understand...");
                            break;
                    }
                }//end while doAgain
                Console.Clear();
            }//end while reload
            Console.WriteLine("Your numbers were:");

            //numbers.Sort(); //Option to sort the numbers low to high

            //TODO build out functionality to count the number of times each value appeared
            
            foreach (int number in numbers)
            {
                quantity++;

                Console.WriteLine($"({quantity}) {number}");
            }

            Console.WriteLine($"Your lowest number was {numbers.Min()}. Your highest number was {numbers.Max()}.\nThat's a range of {numbers.Max() - numbers.Min()}.\nThe average is {numbers.Average():n4}");

        }//end Main()
    }//end class
}//end namespace
