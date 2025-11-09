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
            if (selectedCards.Count != 2) return false;

            int sum = 0;
            foreach (int i in selectedCards)
                sum += cardsOnBoard[i].PointValue;

            return sum == 11;
        }

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
            if (HasFaceCardTriple())
            {
                return true;
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
                if (card.Rank == "Jack")
                {
                    hasJack = true;

                }
                if (card.Rank == "Queen")
                {
                    hasQueen = true;

                }
                if (card.Rank == "King")
                {
                    hasKing = true;
                }
            }
            return hasJack && hasQueen && hasKing;
        }
        public bool DeckIsEmpty()
        {
            return deck.IsEmpty();
        }
    }
}
