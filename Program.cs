using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace BlackJackCS
{
    class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }
        public int Point { get; set; }
    }

    class Deck
    {
        public List<Card> deckOfCards = new List<Card>();

        public Deck CreateDeck()
        {
            List<string> suits = new List<string>() { "♠️", "♥️", "♦️", "♣️" };
            List<string> ranks = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            Deck newDeck = new Deck();

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    var cardValue = 0;

                    if (rank == "Jack")
                    {
                        cardValue = 10;
                    }
                    else if (rank == "Queen")
                    {
                        cardValue = 10;
                    }
                    else if (rank == "King")
                    {
                        cardValue = 10;
                    }
                    else if (rank == "Ace")
                    {
                        cardValue = 11;
                    }
                    else
                    {
                        cardValue = int.Parse(rank);
                    }

                    Card singleCard = new Card { Suit = suit, Rank = rank, Point = cardValue };
                    newDeck.deckOfCards.Add(singleCard);
                }
            }

            return newDeck;
        }


        public void Shuffle()
        {
            var random = new Random();
            for (int i = deckOfCards.Count - 1; i > 0; i--)
            {
                var n = random.Next(i + 1);
                var temp = deckOfCards[i];
                deckOfCards[i] = deckOfCards[n];
                deckOfCards[n] = temp;
            }
        }

        public Card Deal()
        {
            Card dealCards = this.deckOfCards[0];
            this.deckOfCards.RemoveAt(0);
            return dealCards;
        }
    }

    class Hand
    {
        List<Card> deckOfCards = new List<Card>();


        public int HandValue()
        {
            int sum = 0;
            foreach (Card card in this.deckOfCards)
            {
                sum += card.Point;
            }
            return sum;
        }

        public void AddCard(Card card)
        {
            this.deckOfCards.Add(card);
        }

        public void ShowHand()
        {
            foreach (Card card in this.deckOfCards)
            {
                Console.Write(card.Rank + " of " + card.Suit + "  ");
            }
            Console.WriteLine();
        }
    }

    class GameGreeting
    {
        public void Greeting()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Welcome to BlackJack!");
            Console.WriteLine(" ♠️ ♥️ ♦️ ♣️  ♠️ ♥️ ♦️ ♣️  ♠️ ♥️ ♦️ ♣️  ♠️ ♥️ ♦️ ♣️ ");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter any key to play");
            var pressToPlay = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {

            GameGreeting greet = new GameGreeting();
            greet.Greeting();

            Boolean gameStart = true;
            Boolean playAgain = false;
            while (gameStart)
            {
                Deck newDeck = new Deck();
                newDeck = newDeck.CreateDeck();
                newDeck.Shuffle();

                Hand playerHand = new Hand();
                Hand dealerHand = new Hand();
                playerHand.AddCard(newDeck.Deal());
                playerHand.AddCard(newDeck.Deal());
                dealerHand.AddCard(newDeck.Deal());
                dealerHand.AddCard(newDeck.Deal());

                Console.WriteLine($"You are holding: ");
                playerHand.ShowHand();

                if (playerHand.HandValue() > 21)
                {
                    Console.WriteLine($"Oh no you bust! ☹️ ☹️ ☹️");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"Would you like to play another game of Blackjack?");
                    Console.WriteLine();
                    Console.WriteLine();
                    var playerResponse = Console.ReadLine().ToLower();
                    if (playerResponse == "y")
                    {
                        continue;
                    }
                    else
                    {
                        return;
                    }
                }

                playAgain = false;
                Boolean gamePlay = true;
                while (gamePlay)
                {
                    Console.WriteLine($"Type \"Hit\" to hit or \"Stand\" to stand");
                    var hitOrStand = Console.ReadLine().ToLower();

                    if (hitOrStand == "hit")
                    {
                        playerHand.AddCard(newDeck.Deal());
                        Console.WriteLine($"Your hand now is: ");
                        playerHand.ShowHand();

                        if (playerHand.HandValue() > 21)
                        {
                            Console.WriteLine($"Oh no you bust! ☹️ ☹️ ☹️");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine($"Would you like to try again? Type Y to play again or N to quit playing");
                            Console.WriteLine();
                            Console.WriteLine();
                            var playerResponse = Console.ReadLine().ToLower();

                            if (playerResponse == "y")
                            {
                                playAgain = true;
                                break;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (playAgain)
                {
                    continue;
                }
                playAgain = false;

                Boolean dealerGamePlay = true;
                while (dealerGamePlay)
                {
                    Console.WriteLine($"The dealer's hand value is: ");
                    dealerHand.ShowHand();
                    if (dealerHand.HandValue() > 21)
                    {
                        Console.WriteLine($"Yes! Dealer busted and you win! 😎 😎 😎");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine($"Would you like to play another game of Blackjack? Type Y to play again or N to quit playing");
                        Console.WriteLine();
                        Console.WriteLine();
                        var playerResponse = Console.ReadLine().ToLower();

                        if (playerResponse == "y")
                        {
                            playAgain = true;
                            break;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (dealerHand.HandValue() >= 17)
                    {
                        break;
                    }
                    else
                    {
                        dealerHand.AddCard(newDeck.Deal());
                    }
                }

                if (playAgain)
                {
                    continue;
                }
                playAgain = false;

                if (playerHand.HandValue() > dealerHand.HandValue())
                {
                    Console.WriteLine($"Your hand is better than dealers, You Win! 😎 😎 😎");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"Would you like to play another game of Blackjack? Type Y to play again or N to quit playing");
                    Console.WriteLine();
                    Console.WriteLine();
                    var playerResponse = Console.ReadLine().ToLower();

                    if (playerResponse == "y")
                    {
                        continue;
                    }
                    else
                    {
                        return;
                    }
                }
                else if (playerHand.HandValue() < dealerHand.HandValue())
                {
                    Console.WriteLine($"Oh no! Your hand is lower than the dealers hand and you lose ☹️ ☹️ ☹️ ");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"Would you like to play another game of Blackjack? Type Y to play again or N to quit playing");
                    Console.WriteLine();
                    Console.WriteLine();
                    var playerResponse = Console.ReadLine().ToLower();

                    if (playerResponse == "y")
                    {
                        continue;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    Console.WriteLine($"Your hand has the same value as the dealer hand...You lose! ☹️ ☹️ ☹️");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"Would you like to play another game of Blackjack? Type Y to play again or N to quit playing");
                    Console.WriteLine();
                    Console.WriteLine();
                    var playerResponse = Console.ReadLine().ToLower();

                    if (playerResponse == "y")
                    {
                        continue;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }
}