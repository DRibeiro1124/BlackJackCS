using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace BlackJackCS
{
    class Card
    {
        public string suit { get; set; }
        public string rank { get; set; }
        public int point { get; set; }
    }

    class Deck
    {
        public static List<Card> deckOfCards = new List<Card>();

        public Deck CreateDeck()
        {
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

                    Card singleCard = new Card { suit = suit, rank = rank, point = cardValue };
                    deck.Add(singleCard);
                }
            }


        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Blackjack");
        }
    }
}
