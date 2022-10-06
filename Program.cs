using System;
using System.Collections.Generic;

namespace BlackJackCS
{
    //create a class for cards
    class Card
    {
        public static List<string> Suits = new List<string>()
    {
      "♠️", "♥️", "♦️", "♣️"
    };

        public static List<string> Ranks = new List<string>()
    {
      "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace"
    };

        public string Suit { get; set; }
        public string Rank { get; set; }
        public int Point()
        {
            Dictionary<string, int> valueOfEachCard = new Dictionary<string, int>()
          {
            {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6}, {"7", 7}, {"8", 8},
            {"9", 9}, {"10", 10}, {"Jack", 10}, {"Queen", 10}, {"King", 10}, {"Ace", 11}
          };

            return valueOfEachCard[this.Rank];
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to C#");
        }
    }
}
