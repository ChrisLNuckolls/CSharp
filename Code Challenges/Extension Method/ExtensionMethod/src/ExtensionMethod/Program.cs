using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    public class Program
    {
        public void Main(string[] args)
        {
            List<string> userInputs = new List<string>();

            Console.Write("How many text items do you have to enter? ");
            int nbrTexts = int.Parse(Console.ReadLine());

            for (int i = 1; i <= nbrTexts; i++)
            {
                userInputs.Add(Console.ReadLine());
            }
            Console.WriteLine("ODD LETTERS:");
            foreach (string input in userInputs)
            {
                Console.WriteLine(input.OddLetters());
            }
            Console.WriteLine("EVEN LETTERS");
            foreach (string input in userInputs)
            {
                Console.WriteLine(input.EvenLetters());
            }
            Console.WriteLine("Test Complete");
        }
    }//end class

    public static class ExtensionMethods
    {
        public static string OddLetters(this String str)
        {

            string modifiedText = "";

            for (int count = 0; count < str.Length; count++)
            {
                if (count % 2 == 0)
                {
                    modifiedText += str[count];
                }
            }
            return modifiedText;
        }

        public static string EvenLetters(this String str)
        {
            string modifiedText = "";

            for (int count = 0; count < str.Length; count++)
            {
                if (count % 2 == 1)
                {
                    Console.Write(str[count]);
                }
            }
            return modifiedText;
        }
    }
}
