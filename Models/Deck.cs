using System;
using System.Collections.Generic;

namespace ElevensProject.Models
{
    public class Deck
    {
        private List<Card> cards;
        private Random rand = new Random();

        public Deck(string[] ranks, string[] suits, int[] values)
        {
            cards = new List<Card>();
            for (int i = 0; i < ranks.Length; i++)
            {
                foreach (string suit in suits)
                {
                    cards.Add(new Card(ranks[i], suit, values[i]));
                }
            }
            Shuffle();
        }

        public void Shuffle()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                int j = rand.Next(cards.Count);
                (cards[i], cards[j]) = (cards[j], cards[i]);
            }
        }
        public bool IsEmpty()
        {
            return cards.Count == 0;
        }

        public Card? Deal()
        {
            if (cards.Count == 0)
            {
                return null;
            }
            Card top = cards[^1];
            cards.RemoveAt(cards.Count - 1);
            return top;
        }

        public int Size => cards.Count;
    }
}
