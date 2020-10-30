using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    //TODO Modify to use ConsoleKey instead of strings
    class Program
    {
        static void Main(string[] args)
        {
            string[] displays = {
                @"
                              _________
                              |       |
                              |        
                              |       
                              |       
                              |
                         -----------",
                @"
                              _________
                              |       |
                              |       o 
                              |       
                              |       
                              |
                         -----------",
                @"
                              _________
                              |       |
                              |       o 
                              |       |
                              |       
                              |
                         -----------",
                @"
                              _________
                              |       |
                              |      \o 
                              |       |
                              |       
                              |
                         -----------",

                @"
                              _________
                              |       |
                              |      \o/ 
                              |       |
                              |       
                              |
                         -----------",
                @"
                              _________
                              |       |
                              |      \o/ ---""Oh, noes!""
                              |       |
                              |      / 
                              |
                         -----------",
                @"
                              _________
                              |       |
                              |       o  ---""...""
                              |      /|\
                              |      / \
                              |
                         -----------"
            };

            int errors = 0;
            string word = GetWord();
            string chosenLetters = "";
            string letter = "";
            bool exit = false;

            Console.Title = "C# Hangman";

            do
            {
                string userGuessedWord = UserWord(word, chosenLetters);
                if (errors < 6)
                {
                    if (userGuessedWord.Contains('_'))
                    {
                        Console.WriteLine(displays[errors]);
                        Console.WriteLine($"Your word: {UserWord(word, chosenLetters)}\n");
                        Console.WriteLine(chosenLetters.Length == 0 ? "No letters guessed yet\n" : $"Guessed letters:\n{chosenLetters}");
                        userGuessedWord = UserWord(word, chosenLetters);
                        Console.Write("\nGuess a letter: ");
                        letter = Console.ReadLine().ToLower();
                        if (letter == "cheat")
                        {
                            Console.WriteLine($"The word is {word}. ");
                            System.Threading.Thread.Sleep(1250);
                        }
                        else if (letter.Length == 1)
                        {
                            if (chosenLetters.Contains(letter))
                            {
                                Console.WriteLine($"You already guessed {letter}!");
                                System.Threading.Thread.Sleep(1250);
                            }
                            else
                            {
                                chosenLetters += letter;
                                if (!word.Contains(letter))
                                {
                                    errors++;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter exactly one letter!");
                            System.Threading.Thread.Sleep(1250);
                        }
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine($"You win!\nThe word was {word}.\nTotal guesses: {chosenLetters.Length}");

                        bool cont = false;

                        //TODO Fix play again menu
                        do
                        {
                            Console.WriteLine("Would you like to play again? Y/N: ");
                            ConsoleKey playAgain = Console.ReadKey(true).Key;

                            switch (playAgain)
                            {
                                case ConsoleKey.Y:
                                    cont = true;
                                    break;

                                case ConsoleKey.N:
                                    cont = true;
                                    exit = true;
                                    Console.WriteLine("Have a great day!");
                                    break;

                                default:
                                    Console.Clear();
                                    Console.WriteLine("That wasn't an option.");
                                    break;
                            }//end switch

                        } while (!cont);
                        exit = true;
                    }
                }//end if
                else
                {
                    Console.WriteLine(displays[errors]);
                    exit = true;
                    Console.WriteLine("GAME OVER");
                }//end else
            } while (!exit);//end do while
        }//end Main()

        private static string UserWord(string word, string lettersChosen)
        {
            string blankWord = "";

            for (int i = 0; i < word.Length; i++)
            {
                if (lettersChosen.Contains(word[i]))
                {
                    blankWord += word[i];
                }
                else
                {
                    blankWord += '_';
                }
            }//end for
            return blankWord;
        }//end UserWord()

        private static string GetWord()
        {
            string[] words = {
                "method",
                "class",
                "keyword",
                "variable",
                "loop",
                "flow",
                "iteration",
                "throw",
                "catch",
                "switch",
                "while",
                "index",
                "namespace",
                "access",
                "modifier",
                "event",
                "member",
                "object",
                "static",
                "instance",
                "reference",
                "struct",
                "value",
                "constructor",
                "access",
                "reference",
                "string",
                "char",
                "stack",
                "heap",
                "boolean"
            };
            return words[new Random().Next(words.Length)];
        }//end GetWord()
    }//end class
}//end namespace
