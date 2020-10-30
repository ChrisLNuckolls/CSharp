using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiniteLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;

            string[] exclaim = { "OMG!", "NO WAY!", "WOW!", "OH NOES!", "WHY?!", "WHAT?!" };

            ConsoleColor[] background =
                {   ConsoleColor.Black,
                    ConsoleColor.DarkBlue,
                    ConsoleColor.DarkGreen,
                    ConsoleColor.DarkCyan,
                    ConsoleColor.DarkRed,
                    ConsoleColor.DarkMagenta,
                    ConsoleColor.DarkYellow,
                    ConsoleColor.Gray,
                    ConsoleColor.DarkGray,
                    ConsoleColor.Blue,
                    ConsoleColor.Green,
                    ConsoleColor.Red,
                    ConsoleColor.Cyan,
                    ConsoleColor.Magenta,
                    ConsoleColor.Yellow,
                    ConsoleColor.White
                };

            ConsoleColor[] foreground =
                {   ConsoleColor.Black,
                    ConsoleColor.DarkBlue,
                    ConsoleColor.DarkGreen,
                    ConsoleColor.DarkCyan,
                    ConsoleColor.DarkRed,
                    ConsoleColor.DarkMagenta,
                    ConsoleColor.DarkYellow,
                    ConsoleColor.Gray,
                    ConsoleColor.DarkGray,
                    ConsoleColor.Blue,
                    ConsoleColor.Green,
                    ConsoleColor.Red,
                    ConsoleColor.Cyan,
                    ConsoleColor.Magenta,
                    ConsoleColor.Yellow,
                    ConsoleColor.White
                };

            Random rand = new Random();

            while (i < 1)
            {
                int exclaimRand = rand.Next(exclaim.Length);
                int beepRand = rand.Next(400, 2001);//pitch
                int beepRand2 = rand.Next(125, 151);//length
                int backRand = rand.Next(16);
                int foreRand = rand.Next(16);

                Console.WriteLine(exclaim[exclaimRand]);
                Console.Beep(beepRand, beepRand2);
                Console.BackgroundColor = background[backRand];
                Console.ForegroundColor = foreground[foreRand];
                Console.Clear();
            }//end while
        }
    }
}
