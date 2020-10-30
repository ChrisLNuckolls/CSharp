using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
n children have got m pieces of candy. They want to eat as much candy as they can, 
but each child must eat exactly the same amount of candy as any other child. 
Individual pieces of candy cannot be split.
Determine how many pieces of candy will be eaten by all the children together. 
Also show how many pieces each child will receive.


Example

For n = 3 and m = 10, the output should be
candies(n, m) = 9.

Each child will eat 3 pieces. The total candies needed is 9.
*/

namespace CountCandies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many pieces of candy do you have? ");
            int candies = int.Parse(Console.ReadLine());
            Console.Write("How many children are present? ");
            int kiddos = int.Parse(Console.ReadLine());

            Console.WriteLine("You need {0} candies. Each child will have {1}."
                , Candies(candies, kiddos),
                candies / kiddos);
        }

        static int Candies(int candy, int children)
        {
            int candyTotal = (candy / children) * children;
            return candyTotal;
        }
    }
}
