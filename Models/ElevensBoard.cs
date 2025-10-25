using System.Collections.Generic;
using System.Linq;

namespace ElevensProject.Models
{
    public class ElevensBoard : Board
    {
        public ElevensBoard(Deck deck) : base(deck) {}

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
                    if (cardsOnBoard[i].PointValue + cardsOnBoard[j].PointValue == 11)
                        return true;
                }
            }
            return false;
        }
    }
}
