using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ackermann
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine($"Final value is: {Ackermann(4, 1)}");
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Total time: {elapsedMs}ms");
        }

        private static int Ackermann(int m, int n)
        {
            //Console.WriteLine($"Ackermann is called and m = {m} and n = {n}");
            int ans;
            if (m == 0)
            {
                //Console.WriteLine($"m == 0 was called. m = {m} and n = {n}");
                ans = n + 1;
            }
            else if (n == 0)
            {
                //Console.WriteLine($"n == 0 was called. m = {m} and n = {n}");
                ans = Ackermann(m - 1, 1);
            }
            else
            {
                //Console.WriteLine($"m and n !=0, m = {m} and n = {n}");
                ans = Ackermann(m - 1, Ackermann(m, n - 1));
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine($"Falling out of else statement...");
                //Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Ending value of this iteration is {ans}");
            Console.ResetColor();
            return ans;
        }
    }
}
