using System;
using System.Collections.Generic;
using System.Linq;

namespace cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player player = new Player("Vlad");

            player.Draw(deck);
            player.Draw(deck);
            player.Draw(deck);
            player.Discard(0);
            Console.WriteLine(player.Hand.Count);


        }
    }

    class Card
    {
        public string StringVal { get; set; }
        public int Val { get; set; }
        public string Suit { get; }

        public Card(string stringVal, int val, string suit)
        {
            StringVal = stringVal;
            Val = val;
            Suit = suit;
        }
    }

    class Deck
    {
        public List<Card> cards;

        private string[] vals = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        private string[] suits = { "Hearts", "Spades", "Diamonds", "Clubs" };
        private int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

        public Deck()
        {
            cards = new List<Card>();
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < vals.Length; j++)
                {
                    cards.Add(new Card(vals[j], j + 1, suits[i]));
                    Console.WriteLine(vals[j] + " " + suits[i]);
                }
            }
        }

        public Card Deal()
        {
            Card cardToRemove = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            Console.WriteLine(cardToRemove.StringVal + " of " + cardToRemove.Suit);
            return cardToRemove;
        }

        public void Reset()
        {
            cards.Clear();
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < vals.Length; j++)
                {
                    cards.Add(new Card(vals[j], j + 1, suits[i]));
                    Console.WriteLine(vals[j] + " " + suits[i]);
                }
            }
        }
        public List<Card> Shuffle()
        {
            Random rand = new Random();
            cards = cards.OrderBy(item => rand.Next()).ToList();
            return cards;
        }
    }

    class Player
    {
        public string Name { get; set; }
        public List<Card> Hand;

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }

        public Card Draw(Deck deck)
        {
            Card cardToDraw = deck.Deal();
            Hand.Add(cardToDraw);
            Console.WriteLine("You have drawn: " + cardToDraw.StringVal + " of " + cardToDraw.Suit);
            return cardToDraw;
        }
        public void Discard(int index)
        {
            if (index >= 0)
            {
                Hand.RemoveAt(index);

            }
            else
            {
                Console.WriteLine("Wrong index");
            }
        }
    }
}
