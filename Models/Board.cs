using System.Collections.Generic;

namespace ElevensProject.Models
{
    public abstract class Board
    {
        protected Deck deck;
        protected List<Card> cardsOnBoard = new();

        public Board(Deck deck)
        {
            this.deck = deck;
        }

        public abstract bool IsLegal(List<int> selectedCards);
        public abstract bool AnotherPlayIsPossible();

        public void DealBoard(int numCards)
        {
            cardsOnBoard.Clear();
            for (int i = 0; i < numCards; i++)
            {
                Card? dealt = deck.Deal();
                if (dealt != null)
                {
                    cardsOnBoard.Add(dealt);
                }
                else
                {
                    Console.WriteLine("Deck is empty — no more cards to deal.");
                    break;
                }
            }
        }

        public void DisplayBoard()
        {
            for (int i = 0; i < cardsOnBoard.Count; i++)
            {
                System.Console.WriteLine($"{i}: {cardsOnBoard[i]}");
            }
        }
    }
}
