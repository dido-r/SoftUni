using System;
using System.Linq;
using System.Collections.Generic;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<Card> cards = new List<Card>();

            for (int i = 0; i < input.Length; i += 2)
            {
                try
                {
                    Card card = new Card(input[i], input[i + 1]);
                    cards.Add(card);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(String.Join(" ", cards));
        }
    }

    class Card
    {
        private string face;
        private string suit;

        private string[] cardFace = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private Dictionary<string, string> cardSuit = new Dictionary<string, string>()
        {
            { "S","\u2660" },
            { "H","\u2665" },
            { "D","\u2666" },
            { "C","\u2663" },
        };

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }
        public string Face
        {
            get => face;
            private set
            {
                if (!cardFace.Any(x => x == value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                face = value;
            }
        }
        public string Suit
        {
            get => suit;
            private set
            {
                if (!cardSuit.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                suit = cardSuit[value];
            }
        }

        public override string ToString()
        {
            return $"[{Face}{Suit}]";
        }
    }
}
