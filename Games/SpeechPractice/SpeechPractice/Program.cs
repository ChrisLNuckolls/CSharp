using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Media;

namespace SpeechPractice
{
    class Program
    {
        static SpeechSynthesizer talk = new SpeechSynthesizer();
        static void Main(string[] args)
        {            

            Console.ForegroundColor = ConsoleColor.Green;

            bool introPhrase = true;
            string phrase = "Shall we play a game?";
            string answer = " Y/N";
            string moveOn = "\nPress any key...";
            string playAgain = "Shall we play another game?";
            string exitPhrase = "Fine. I didn't want to play, anyway.";
            string notUnderstood = "That wasn't an option...";
            string choice = "What would you like to play?";
            string menu = "(C)hess\n(F)rogger\n(H)angman\n(G)lobal Thermonuclear War";
            string war = "Initiating global thermonuclear war...";
            string chess = "Checkmate! You lose!";
            string frogger = "Splat! You died!";
            string boom = @"
                                  ..-^~~~^-..
                                .~           ~.
                               (;:           :;)
                                (:           :)
                                  ':._   _.:'
                                      | |
                                    (=====)
                                      | |
-O-                                   | |
  \                                   | |
  /\                               ((/   \))

";

            bool exit = false;

            do
            {
                if (!introPhrase)
                {
                    Output(playAgain, playAgain);
                    foreach (char letter in answer)
                    {
                        Console.Write(letter);
                        System.Threading.Thread.Sleep(85);
                    }
                }
                else
                {
                    Output(phrase, phrase);
                    foreach (char letter in answer)
                    {
                        Console.Write(letter);
                        System.Threading.Thread.Sleep(85);
                    }
                }
                Console.WriteLine();
                ConsoleKey userChoice = Console.ReadKey(true).Key;

                switch (userChoice)
                {
                    case ConsoleKey.Y:
                        Console.Clear();
                        Output(choice, menu);
                        Console.WriteLine();
                        ConsoleKey option = Console.ReadKey(true).Key;
                        switch (option)
                        {
                            case ConsoleKey.C:
                                Console.Clear();
                                Output(chess, chess);
                                Console.WriteLine(moveOn);
                                Console.ReadKey(true);
                                Console.Clear();
                                introPhrase = false;
                                break;
                            case ConsoleKey.F:
                                Console.Clear();
                                Output(frogger, frogger);
                                Console.WriteLine(moveOn);
                                Console.ReadKey(true);
                                Console.Clear();
                                introPhrase = false;
                                break;
                            case ConsoleKey.H:
                                Console.Clear();
                                Methods.HangMan();
                                Console.WriteLine();
                                introPhrase = false;
                                break;
                            case ConsoleKey.G:
                                Console.Clear();
                                Output(war, war);
                                Console.WriteLine();
                                for (int i = 3; i >= 0; i--)
                                {
                                    if (i != 0)
                                    {
                                        talk.SpeakAsync(i.ToString());
                                        Console.WriteLine($"{i}...");
                                        System.Threading.Thread.Sleep(1000);
                                    }
                                    System.Threading.Thread.Sleep(100);
                                }
                                Console.Clear();
                                Console.WriteLine(boom);
                                SoundPlayer sound = new SoundPlayer();
                                sound.SoundLocation = @"C:\Users\ChrisN\Desktop\GitHub\CSharp\Games\SpeechPractice\SpeechPractice\Sounds\Atomic_Bomb-Sound_Explorer-897730679.wav";
                                //TODO Make the file path dynamic
                                sound.PlaySync();
                                Console.WriteLine("GAME OVER");
                                exit = true;
                                introPhrase = false;
                                break;
                            default:
                                Console.WriteLine();
                                Output(notUnderstood, notUnderstood);
                                Console.WriteLine(moveOn);
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                        }

                        break;
                    case ConsoleKey.N:
                        exit = true;
                        Output(exitPhrase, exitPhrase);
                        break;

                    default:
                        Output(notUnderstood, notUnderstood);
                        Console.WriteLine(moveOn);
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                }
            } while (!exit);
            Console.WriteLine();
            Console.ResetColor();
        }//end Main()

        private static void Output(string voice, string text)
        {
            talk.SpeakAsync(voice);
            foreach (char letter in text)
            {
                Console.Write(letter);
                System.Threading.Thread.Sleep(85);
            }
        }//end Output()

    }//end class
}//end namespace
