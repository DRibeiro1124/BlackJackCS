using System;
using System.Collections.Generic;

namespace BlackJackCS
{
    class Card
    {
        public static List<string> Suits = new List<string>()
      {
        "♠️", "♥️", "♦️", "♣️"
      };

        public static List<string> Ranks = new List<string>()
      {
        "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
      };

        public string Suit { get; set; }
        public string Rank { get; set; }

        public int Point()
        {
            Dictionary<string, int> cardValue = new Dictionary<string, int>()
        {
          {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6}, {"7", 7}, {"8", 8},
          {"9", 9}, {"10", 10}, {"Jack", 10}, {"Queen", 10}, {"King", 10}, {"Ace", 11},
        };
            return cardValue[this.Rank];
        }
    }

    class Deck
    {
        public List<Card> deckOfCards = new List<Card>();

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
            Deck newDeck = new Deck();

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    Card cardToAdd = new Card();
                    cardToAdd.Suit = suit;
                    cardToAdd.Rank = rank;
                    newDeck.deckOfCards.Add(cardToAdd);
                }
            }
            return newDeck;
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
