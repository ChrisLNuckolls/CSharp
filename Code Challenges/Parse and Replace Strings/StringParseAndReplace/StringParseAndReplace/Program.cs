using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringParseAndReplace
{
    #region Requirements
    /*
    In .Net, write a program that parses a sentence and replaces 
    each word with the following: first letter, number of distinct 
    characters between first and last character, and last letter.  
    For example, Smooth would become S3h.  Words are separated by spaces 
    or non-alphabetic characters and these separators should be maintained 
    in their original form and location in the answer.
    */
    #endregion

    //TODO Use LINQ to count spaces and look for distinct characters

    //Problem 1: Take user input and parse it into individual words
    //Problem 2: Parse through individual words:
    //a: Remove first and last letters
    //b: Parse middle characters
    //c: Count only the unique characters
    //d: Store a new word with first letter, unique character count and last letter
    //e: Return the modified text

    class Program
    {
        //local variables
        static List<string> inputWords = new List<string>(); //Stores input from the user
        static List<string> parsedWords = new List<string>(); //Output back to the user

        static void Main(string[] args)
        {

            Console.Write("Give me a sentence or some words: ");
            string userInput = Console.ReadLine().Trim();

            ParseUserInput(userInput); //Problem 1
            ParseOutput();//Problem 2

        }//end Main()

        static void ParseUserInput(string input)
        {
            int spaceCount = 0; //Number of spaces in user input

            foreach (char letter in input) //Counts the number of spaces in the 
            //user's text to ease parsing of individual words
            {
                if (letter == ' ')
                {
                    spaceCount++;
                }
            }

            //Parse a word, remove it from the user input, then start again
            //until there are no words left. Look at each word using the space
            //as a stopping point, then add the word to the inputWords collection.
            for (int i = 0; i <= spaceCount; i++) //Each word but the last
            {
                string word = "";

                if (input.Contains(" "))
                {
                    int spaceIndex = input.IndexOf(" ");

                    for (int x = 0; x < spaceIndex; x++)
                    {
                        word += input[x];
                    }

                    input = input.Remove(0, spaceIndex + 1);
                }

                else //The last word, which did not have a space
                {
                    foreach (char letter in input)
                    {
                        word += letter;
                    }
                }

                inputWords.Add(word);
            }
        }//end ParseUserInout()

        static void ParseOutput()
        {
            for (int i = 0; i < inputWords.Count; i++)
            {
                char firstLetter = inputWords[i][0]; //The first letter in the word
                char lastLetter = inputWords[i][inputWords[i].Length - 1]; //The last letter
                string newWord = ""; //The parsed word to output
                string wordMiddle = ""; //The unique letters in the word, minus
                                        //the first and last letters. Used to check for distinct characters.

                newWord += firstLetter;

                if (inputWords[i].Length > 1)
                {
                    int letterCount = inputWords[i].Length; //Used below to check for two-letter words

                    inputWords[i] = inputWords[i].Remove(inputWords[i].Length - 1, 1);
                    inputWords[i] = inputWords[i].Remove(0, 1);

                    foreach (char letter in inputWords[i])
                    {
                        if (!wordMiddle.Contains(letter))
                        {
                            wordMiddle += letter;
                        }
                    }

                    if (!(letterCount == 2))//Ensures that no numeric value is returned
                        //for 2-letter words
                    {
                        newWord += wordMiddle.Length.ToString();
                    }

                    newWord += lastLetter;

                }

                parsedWords.Add(newWord);

            }

            foreach (string word in parsedWords)
            {
                Console.Write($"{word} ");
            }

            Console.WriteLine();
        }//end ParseOutput()

    }
}
