using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeChecker
{
    class Program
    {
        //TODO - Make the method more extensible by removing the Console.WriteLine() in the method
        static void Main(string[] args)
        {
            Console.Write("Enter a word to see if it is a palindrome: ");
            Console.WriteLine(CheckPalindrome(Console.ReadLine().ToLower()) ? "It is a palindrome!": "It is not a palindrome.");
        }

        //Using Reverse() (executes quicker)
        private static bool CheckPalindrome(string inputString)
        {
            char[] charArray = inputString.ToCharArray();
            Array.Reverse(charArray);
            string reverseString =  new string(charArray);
            Console.WriteLine($"The reverse of {inputString} is {reverseString}.");
            return inputString == reverseString;
        }

        //Without using Reverse()
        //private static bool checkPalindrome(string inputString)
        //{
        //    string reverseString = "";
        //    for (int a = inputString.Length - 1; a >= 0; a--)
        //    {
        //        reverseString += inputString[a];
        //    }
        //    Console.WriteLine("The reverse of {0} is {1}.", inputString, reverseString);
        //    if (inputString == reverseString)
        //    {
        //        return true;

        //    }
        //    return false;
        //}
    }
}
