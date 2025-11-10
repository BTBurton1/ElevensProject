using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ElevensProject.Models
{
    public class ElevensBoard : Board
    {
        public ElevensBoard(Deck deck) : base(deck) { }

        public override bool IsLegal(List<int> selectedCards)
        {
            // Two-card combo that sums to 11
            if (selectedCards.Count == 2)
            {
                int sum = 0;
                foreach (int i in selectedCards)
                {
                    sum += cardsOnBoard[i].PointValue;
                }
                return sum == 11;
            }

            // Three-card combo: Jack + Queen + King
            else if (selectedCards.Count == 3)
            {
                bool hasJack = false;
                bool hasQueen = false;
                bool hasKing = false;

                foreach (int i in selectedCards)
                {
                    string rank = cardsOnBoard[i].Rank;
                    if (rank == "Jack")
                    {
                        hasJack = true;
                    }
                    else if (rank == "Queen")
                    {
                        hasQueen = true;
                    }
                    else if (rank == "King")
                    {
                        hasKing = true;
                    }
                }

                return hasJack && hasQueen && hasKing;
            }

            return false;
        }

        public bool HasFaceCardTriple()
        {
            bool hasJack = false;
            bool hasQueen = false;
            bool hasKing = false;

            foreach (Card card in cardsOnBoard)
            {
                if (card.Rank == "Jack") { hasJack = true; }
                if (card.Rank == "Queen") { hasQueen = true; }
                if (card.Rank == "King") { hasKing = true; }
            }

            return hasJack && hasQueen && hasKing;
        }

        public bool DeckIsEmpty()
        {
            return deck.IsEmpty();
        }

        public void RemoveSelectedCards(List<int> selectedCards)
        {
            selectedCards.Sort();
            selectedCards.Reverse();

            foreach (int index in selectedCards)
            {
                if (index >= 0 && index < cardsOnBoard.Count)
                {
                    cardsOnBoard.RemoveAt(index);
                }
            }

            RefillBoard(9);
        }

        // For testing only: forces a JQK combo onto the board
        public void ForceFaceCardTriple()
        {
            cardsOnBoard.Clear();
            cardsOnBoard.Add(new Card("Jack", "Hearts", 0));
            cardsOnBoard.Add(new Card("Queen", "Spades", 0));
            cardsOnBoard.Add(new Card("King", "Diamonds", 0));

            // Fill remaining slots with real cards from deck
            while (cardsOnBoard.Count < 9 && !deck.IsEmpty())
            {
                Card? c = deck.Deal();
                if (c != null)
                {
                    cardsOnBoard.Add(c);
                }
            }
        }
        // Checks if another legal move is possible on board
        public override bool AnotherPlayIsPossible()
        {
            for (int i = 0; i < cardsOnBoard.Count; i++)
            {
                for (int j = i + 1; j < cardsOnBoard.Count; j++)
                {
                    int value1 = cardsOnBoard[i].PointValue;
                    int value2 = cardsOnBoard[j].PointValue;

                    if (value1 + value2 == 11)
                    {
                        return true;
                    }
                }
            }

            // Checks if a J-Q-K triple exists anywhere
            return HasFaceCardTriple();
        }

    }
}
