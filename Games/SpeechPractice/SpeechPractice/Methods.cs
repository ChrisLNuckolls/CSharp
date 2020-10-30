using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechPractice
{
    public class Methods
    {
        public static void HangMan()
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

            while (!exit)
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
                        exit = true;
                    }
                }//end if
                else
                {
                    Console.WriteLine(displays[errors]);
                    exit = true;
                    Console.Write("GAME OVER");
                }//end else
            }//end while

        }//end 

        public static string UserWord(string word, string lettersChosen)
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
                "heap"
            };
            return words[new Random().Next(words.Length)];
        }//end GetWord()
    }
}
