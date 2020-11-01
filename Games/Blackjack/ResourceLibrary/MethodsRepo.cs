using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceLibrary
{
    public class MethodsRepo
    {
        public static string rules = "In Blackjack you play against a dealer. Both of you draw cards in an attempt to get the highest value without going over 21. Whoever has the highest value wins. Both you and the dealer will start with 2 cards. One of the dealer's cards will be face down. You will have an option to take another card (called a \"hit\") or keep the current value you have (called a \"stand\"). Each new card adds to your total. If your total exceeds 21 (called a \"bust\") you automatically lose. When you stop drawing new cards the dealer will reveal their cards and draw until they either beat you or bust. If you get exactly 21 off the first draw you immediately win unless the dealer also has 21. If both you and the dealer end the game with teh same card values a draw is declared and your bet is returned to you.\nPress any key...";
        public static string difficulty = "easy";

        public static decimal Bet(decimal moneyTotal)
        {
            bool validAmt = false; //accepting bet value
            decimal betAmt = 0; //amount of current bet
            decimal minBet = 5;
            if (difficulty == "easy")
            {
                minBet = 5;
            }
            else if (difficulty == "standard")
            {
                minBet = 10;
            }
            else
            {
                minBet = 20;
            }

            do
            {

                Console.Write("Enter bet amount (min {0:c}, max {1:c}): $", minBet, moneyTotal > 500 ? "500" : moneyTotal.ToString());
                try
                {
                    betAmt = decimal.Parse(Console.ReadLine());
                    if (betAmt >= minBet && betAmt <= moneyTotal && betAmt <= 500)
                    {
                        Console.Clear();
                        validAmt = true;
                    }
                    else if (betAmt > 500 || betAmt > moneyTotal)
                    {
                        Console.WriteLine("Max bet amount is {0:c}.\nPress any key...", moneyTotal > 500 ? "500" : moneyTotal.ToString());
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                            Console.WriteLine("Minimum bet amount is {0:c}.\nPress any key...", minBet);
                            Console.ReadKey();
                            Console.Clear();
                    }
                }
                catch (FormatException)
                {

                    Console.WriteLine("Please enter only numeric values.\nPress any key...");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch
                {
                    Console.WriteLine("Something went wrong. Try again.\nPress any key...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (!validAmt);

            return betAmt;
        }//end Bet()

        public static bool PlayAgain()
        {
            ConsoleKey playAgain; //user input for play again
            bool repeat = true; //reload play again menu
            bool reload = true;

            do
            {
                //Console.Clear();
                Console.WriteLine();
                Console.Write("Play again? Y/N? :");
                playAgain = Console.ReadKey(true).Key;
                switch (playAgain)
                {
                    case ConsoleKey.Y:
                        repeat = false;
                        reload = true;
                        break;

                    case ConsoleKey.N:
                        repeat = false;
                        reload = false;
                        break;

                    default:
                        Console.WriteLine("That wasn't an option.\nPress any key...");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            } while (repeat);

            return reload;

        }//end PlayAgain()

        public static string Intro()
        {

            string credit = "by Chris Nuckolls";
            string byLine = string.Format("{0," + ((Console.WindowWidth / 2) + credit.Length / 2) + "}", credit);


            return @"
$$$$$$$\  $$\                     $$\                               $$\       
$$  __$$\ $$ |                    $$ |                              $$ |      
$$ |  $$ |$$ | $$$$$$\   $$$$$$$\ $$ |  $$\ $$\  $$$$$$\   $$$$$$$\ $$ |  $$\ 
$$$$$$$\ |$$ | \____$$\ $$  _____|$$ | $$  |\__| \____$$\ $$  _____|$$ | $$  |
$$  __$$\ $$ | $$$$$$$ |$$ /      $$$$$$  / $$\  $$$$$$$ |$$ /      $$$$$$  / 
$$ |  $$ |$$ |$$  __$$ |$$ |      $$  _$$<  $$ |$$  __$$ |$$ |      $$  _$$<  
$$$$$$$  |$$ |\$$$$$$$ |\$$$$$$$\ $$ | \$$\ $$ |\$$$$$$$ |\$$$$$$$\ $$ | \$$\ 
\_______/ \__| \_______| \_______|\__|  \__|$$ | \_______| \_______|\__|  \__|
                                      $$\   $$ |                              
                                      \$$$$$$  |                              
                                       \______/

" + byLine;

        }//end Intro()

        public static string Menu()
        {
            bool stayInMenu = true;

            do
            {
                Console.Title = "Menu";
                Console.Clear();
                Console.Write("1) Play game\n2) Rules\n3) Set difficulty\nChoose an option: ");
                ConsoleKey userOption = Console.ReadKey(true).Key;
                switch (userOption)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:                        
                        stayInMenu = false;
                        Console.Clear();
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        //TODO Write blackjack rules
                        Console.Clear();
                        Console.Title = "Rules of Blackjack.";
                        Console.WriteLine(rules);
                        Console.ReadKey();
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        //TODO Write a method to select difficulty by adding larger shoes
                        Console.Clear();
                        Console.Title = "Select difficulty";
                        Console.WriteLine("1) Easy (One deck shoe and low betting minimum)\n2) Standard (Two deck shoe and higher minimum bet)\n3) Hard (Three deck shoe and high minimum bet)");
                        ConsoleKey difficultyOption = Console.ReadKey(true).Key;
                        switch (difficultyOption)
                        {
                            case ConsoleKey.NumPad1:
                            case ConsoleKey.D1:
                                difficulty = "easy";
                                break;
                            case ConsoleKey.NumPad2:
                            case ConsoleKey.D2:
                                difficulty = "standard";
                                break;
                            case ConsoleKey.NumPad3:
                            case ConsoleKey.D3:
                                difficulty = "hard";
                                break;
                            default:
                                Console.WriteLine("That was not a valid option.");
                                difficulty = "easy";
                                break;
                        }
                        Console.WriteLine($"Difficulty set to {difficulty}.");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("That was not a valid option. Please try again.\nPress any key...");
                        Console.ReadKey();
                        break;
                }
                return difficulty;
            } while (stayInMenu);

        }//end Menu()

        public static void HitStand(Card card1, Card card2)
        {
            ConsoleKey hitOrStay;
            //if (card1.Value == card2.Value)
            //{
            //    Console.Write("Would you like to (H)it, (S)tay, or S(p)lit? ");
            //    hitOrStay = Console.ReadKey().Key;

            //    switch (hitOrStay)
            //    {
            //        case ConsoleKey.H:
            //            Console.WriteLine("Hit method goes here.");
            //            break;
            //        case ConsoleKey.S:
            //            Console.WriteLine("Stay method goes here.");
            //            break;
            //        case ConsoleKey.P:
            //            Console.WriteLine("Split method goes here.");
            //            break;
            //        default:
            //            Console.WriteLine("That wasn't an option.\nPress any key...");
            //            Console.ReadKey();
            //            break;
            //    }
            //}//end if card values match
            //else
            //{
                Console.Write("Would you like to (H)it or (S)tay? ");
                hitOrStay = Console.ReadKey().Key;

                switch (hitOrStay)
                {
                    case ConsoleKey.H:
                        Console.WriteLine("Hit method goes here.");
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine("Stay method goes here.");
                        break;
                    default:
                        Console.WriteLine("That wasn't an option.\nPress any key...");
                        Console.ReadKey();
                        break;
                }
            //}//end else card values do not match
            //return 
        }//end HitOrStand()

    }//end class
}//end namespace
