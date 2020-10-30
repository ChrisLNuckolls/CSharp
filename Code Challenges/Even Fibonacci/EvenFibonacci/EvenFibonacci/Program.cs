using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            //Each new term in the Fibonacci sequence is generated 
            //by adding the previous two terms. By starting with 
            //1 and 2, the first 10 terms will be:

            //1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
            //By considering the terms in the Fibonacci sequence 
            //whose values do not exceed four million, find the 
            //sum of the even-valued terms.

            int val1 = 1;
            int val2 = 1;
            int val3 = 1;
            int totalOfEvens = 0;

            while (val3 < 4000000)
            {
                Console.WriteLine(val3);
                if (val3 % 2 == 0)
                {
                    totalOfEvens += val3;
                    //Console.WriteLine("New total: " + totalOfEvens);
                    //^ Shows the even values being added in execution
                }
                val1 = val2;
                val2 = val3;
                val3 = val1 + val2;
            }

            Console.WriteLine("The even number total is " + totalOfEvens);
        }
    }
}
