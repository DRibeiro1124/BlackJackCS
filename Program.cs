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
            Deck newDeck = new Deck();
            List<string> suits = new List<string>()
            {
              "♠️", "♥️", "♦️", "♣️"
            };

            List<string> ranks = new List<string>()
            {
              "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
            };

            var deck = new List<Card>();

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    var cardValue = 0;

                    if (rank == "J")
                    {
                        cardValue = 10;
                    }
                    else if (rank == "Q")
                    {
                        cardValue = 10;
                    }
                    else if (rank == "K")
                    {
                        cardValue = 10;
                    }
                    else if (rank == "A")
                    {
                        cardValue = 11;
                    }
                    else
                    {
                        cardValue = int.Parse(rank);
                    }

                    Card singleCard = new Card { Suit = suit, Rank = rank, Point = cardValue };
                    deck.Add(singleCard);
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
                Console.Write(card.Point + " of " + card.Suit + ", ");
            }
            Console.WriteLine();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Deck newDeck = new Deck();
            newDeck = newDeck.CreateDeck();
            Console.WriteLine("Welcome to Blackjack");
            Console.WriteLine($"This is my deck" + newDeck);
        }
    }
}