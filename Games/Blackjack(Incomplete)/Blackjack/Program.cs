using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceLibrary;

namespace Blackjack
{
    class Program
    {
        #region Decks & Cards
        //TODO Place multiple deck sets here for difficulty selection
        static List<Card> deck = new List<Card>();
        #endregion

        static void Main(string[] args)
        {
            Shuffle();
            List<Card> startList = new List<Card>();
            Player player = new Player(startList);
            Dealer dealer = new Dealer(startList);
            decimal moneyTotal = 100;
            decimal betAmt = 0;
            bool reload = true; //reload game
            int numHands = 0;
            Console.Title = "Blackjack!";

            Console.WriteLine(MethodsRepo.Intro());

            System.Threading.Thread.Sleep(3000);

            MethodsRepo.Menu();

            //Game starts here:
            do
            {
                numHands++;
                Console.Title = Title(0, moneyTotal);

                //Shuffle deck if fewer than 26 cards before starting this hand
                if (deck.Count < 26)
                {
                    Console.Write("Shuffling deck");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write(".");
                        System.Threading.Thread.Sleep(1000);
                    }
                    Shuffle();
                    Console.Clear();
                }

                betAmt = MethodsRepo.Bet(moneyTotal); //bet
                moneyTotal -= betAmt;
                Console.Title = Title(betAmt, moneyTotal);

                Card playerCard1 = Draw();
                Card playerCard2 = Draw();
                if (playerCard1.Value == 1 || playerCard2.Value == 1)
                {
                    player.HasAce = true;
                }
                player.TotalCards += 2;

                player.Hand.Add(playerCard1);
                player.Hand.Add(playerCard2);
                player.HandValue += playerCard1.Value + playerCard2.Value;

                //TODO build functionality to have ace be either 1 or 11
                //TODO build functionality to split

                Card dealerCard1 = Draw();
                Card dealerCard2 = Draw();
                if (dealerCard1.Value == 1 || dealerCard2.Value == 1)
                {
                    dealer.HasAce = true;
                }
                dealer.TotalCards += 2;
                dealer.Hand.Add(dealerCard1);
                dealer.Hand.Add(dealerCard2);
                dealer.HandValue += dealerCard1.Value + dealerCard2.Value;
                Console.WriteLine("Dealer shows {0} of {1}",
                    dealerCard1.FaceValue,
                    dealerCard1.CardSuit);
                Console.WriteLine("You show {0} and {1}",
                    playerCard1,
                    playerCard2);
                //Console.WriteLine("Dealer shows " + dealer);
                //Console.WriteLine("You show " + player);

                Console.WriteLine("Dealer total : " + dealerCard1.Value);
                Console.WriteLine("Your total: " + player.HandValue);

                //player and dealer both had blackjack
                if (((playerCard1.Value == 1 && playerCard2.Value == 10) ||
                    (playerCard1.Value == 10 && playerCard2.Value == 1)) &&
                    ((dealerCard1.Value == 1 && dealerCard2.Value == 10) ||
                    (dealerCard1.Value == 10 && dealerCard2.Value == 1)))
                {
                    Console.WriteLine("You got Blackjack! Unfortunately, the dealer's second card was {0}. He also got Blackjack. Push.",
                        dealerCard2);
                    moneyTotal += betAmt;
                }
                //only player has blackjack
                else if (((playerCard1.Value == 1 && playerCard2.Value == 10) || (playerCard1.Value == 10 && playerCard2.Value == 1)))
                {
                    Console.WriteLine("You got Blackjack!");
                    decimal winAmt = (betAmt * 2) + betAmt / 2;
                    moneyTotal += winAmt;
                    Console.WriteLine("You win {0:c}!", winAmt);
                    Console.Title = Title(betAmt, moneyTotal);
                }
                //only dealer has blackjack
                else if (((dealerCard1.Value == 1 && dealerCard2.Value == 10) || (dealerCard1.Value == 10 && dealerCard2.Value == 1)))
                {
                    Console.WriteLine("Dealer's second card is {0}. Blackjack. You lose.", dealerCard2);
                    Console.Title = Title(0, moneyTotal);
                }
                else
                {
                    bool hitMe = true;

                    do
                    {

                        Console.Write("Would you like to (H)it or (S)tay? ");
                        ConsoleKey hitOrStay = Console.ReadKey(true).Key;

                        switch (hitOrStay)
                        {
                            case ConsoleKey.H:
                                Console.Clear();
                                Card newCard = Draw();
                                Console.WriteLine("You drew " + newCard);
                                player.HandValue += newCard.Value;
                                if (newCard.Value == 1)
                                {
                                    player.HasAce = true;
                                }
                                Console.WriteLine("Your new total: {0}.", player.HandValue);
                                if (player.HandValue > 21)
                                {
                                    Console.WriteLine("You bust!\nPress any key...");
                                    hitMe = false;
                                    Console.Title = Title(betAmt, moneyTotal);
                                    Console.ReadKey();
                                    Console.Clear();
                                }//end if player busts
                                break;
                            case ConsoleKey.S:
                                hitMe = false;
                                Console.Clear();
                                Console.WriteLine("Your total: " + player.HandValue);
                                Console.WriteLine("Dealer's second card is {0}\nDealer's new total is {1}.",
                                    dealerCard2,
                                    dealer.HandValue);

                                while (dealer.HandValue < 17)
                                {
                                    Console.WriteLine("Dealer is drawing a card...");
                                    System.Threading.Thread.Sleep(1500);
                                    Card anotherCard = Draw();
                                    dealer.Hand.Add(anotherCard);
                                    dealer.HandValue += anotherCard.Value;
                                    if (anotherCard.Value == 1)
                                    {
                                        dealer.HasAce = true;
                                    }
                                    Console.WriteLine("Dealer drew the {0}\nDealer's new total is {1}",
                                        anotherCard,
                                        dealer.HandValue);
                                    System.Threading.Thread.Sleep(500);
                                }
                                if (dealer.HandValue > 21)
                                {
                                    Console.WriteLine("Dealer busts!\nYou win {0:c}!",
                                        betAmt);
                                    moneyTotal += (betAmt * 2);
                                    Console.Title = Title(betAmt, moneyTotal);
                                }
                                else if (player.HandValue > dealer.HandValue)
                                {
                                    Console.WriteLine("You win!");
                                    moneyTotal += (betAmt * 2);
                                    Console.Title = Title(0, moneyTotal);
                                }
                                else if (player.HandValue == dealer.HandValue)
                                {
                                    Console.WriteLine("Push.");
                                    moneyTotal += betAmt;
                                    Console.Title = Title(0, moneyTotal);
                                }
                                else
                                {
                                    Console.WriteLine("Dealer wins.");
                                    Console.Title = Title(0, moneyTotal);
                                }

                                //Console.ReadKey();
                                //Console.Clear();
                                break;
                            default:
                                Console.WriteLine("That wasn't an option.\nPress any key...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }//end switch to hit or stay
                    } while (hitMe);
                }//end else for neither gamer hit blackjack

                if (moneyTotal < 5)
                {
                    Console.WriteLine("You do not have enough money to continue playing. Hit up the ATM.");
                    reload = false;
                }
                else
                {
                    reload = MethodsRepo.PlayAgain(); //play again?
                    player.Hand.Clear();
                    player.HandValue = 0;
                    dealer.Hand.Clear();
                    dealer.HandValue = 0;
                }
            } while (reload);

            Console.WriteLine("You played {0} hands.", numHands);

        }//end Main()

        static Card Draw()
        {
            Card card = deck[new Random().Next(deck.Count)];
            deck.Remove(card);
            System.Threading.Thread.Sleep(25);
            return card;
        }

        static void Shuffle()
        {
            deck.Clear();
            deck = new List<Card>()
            {
            new Card(1, Suit.Clubs, "Ace"),
            new Card(2, Suit.Clubs, "Two"),
            new Card(3, Suit.Clubs, "Three"),
            new Card(4, Suit.Clubs, "Four"),
            new Card(5, Suit.Clubs, "Five"),
            new Card(6, Suit.Clubs, "Six"),
            new Card(7, Suit.Clubs, "Seven"),
            new Card(8, Suit.Clubs, "Eight"),
            new Card(9, Suit.Clubs, "Nine"),
            new Card(10, Suit.Clubs, "Ten"), //10
            new Card(10, Suit.Clubs, "Jack"), //Jack
            new Card(10, Suit.Clubs, "Queen"), //Queen
            new Card(10, Suit.Clubs, "King"), //King
            new Card(1, Suit.Diamonds, "Ace"),
            new Card(2, Suit.Diamonds, "Two"),
            new Card(3, Suit.Diamonds, "Three"),
            new Card(4, Suit.Diamonds, "Four"),
            new Card(5, Suit.Diamonds, "Five"),
            new Card(6, Suit.Diamonds, "Six"),
            new Card(7, Suit.Diamonds, "Seven"),
            new Card(8, Suit.Diamonds, "Eight"),
            new Card(9, Suit.Diamonds, "Nine"),
            new Card(10, Suit.Diamonds, "Ten"),  //10
            new Card(10, Suit.Diamonds, "Jack"),  //Jack
            new Card(10, Suit.Diamonds, "Queen"), //Queen
            new Card(10, Suit.Diamonds, "King"), //King
            new Card(1, Suit.Hearts, "Ace"),
            new Card(2, Suit.Hearts, "Two"),
            new Card(3, Suit.Hearts, "Three"),
            new Card(4, Suit.Hearts, "Four"),
            new Card(5, Suit.Hearts, "Five"),
            new Card(6, Suit.Hearts, "Six"),
            new Card(7, Suit.Hearts, "Seven"),
            new Card(8, Suit.Hearts, "Eight"),
            new Card(9, Suit.Hearts, "Nine"),
            new Card(10, Suit.Hearts, "Ten"),   //10
            new Card(10, Suit.Hearts, "Jack"),  //Jack
            new Card(10, Suit.Hearts, "Queen"), //Queen
            new Card(10, Suit.Hearts, "King"),  //King
            new Card(1, Suit.Spades, "Ace"),
            new Card(2, Suit.Spades, "Two"),
            new Card(3, Suit.Spades, "Three"),
            new Card(4, Suit.Spades, "Four"),
            new Card(5, Suit.Spades, "Five"),
            new Card(6, Suit.Spades, "Six"),
            new Card(7, Suit.Spades, "Seven"),
            new Card(8, Suit.Spades, "Eight"),
            new Card(9, Suit.Spades, "Nine"),
            new Card(10, Suit.Spades, "Ten"),   //10
            new Card(10, Suit.Spades, "Jack"),  //Jack
            new Card(10, Suit.Spades, "Queen"), //Queen
            new Card(10, Suit.Spades, "King"),  //King
            };

        }//end Shuffle()

        static string Title(decimal betAmt, decimal moneyTotal)
        {
            return string.Format($"Bet: {betAmt.ToString("c")}    Money total: {moneyTotal.ToString("c")}");
        }//end Title()

    }//end class
}//end namespace
