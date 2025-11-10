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

        // Deals a completely new board at the start of the game
public void ResetBoard(int numCards)
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

// Refills the board after cards are removed (no clearing)
public void RefillBoard(int targetCount)
{
    while (cardsOnBoard.Count < targetCount && !deck.IsEmpty())
    {
        Card? dealt = deck.Deal();
        if (dealt != null)
        {
            cardsOnBoard.Add(dealt);
        }
    }
}


        public void DisplayBoard()
        {
           for (int i = 0; i < cardsOnBoard.Count; i++)
    {
        Card card = cardsOnBoard[i];
        Console.WriteLine($"[{i}] {card.Rank} of {card.Suit} (value {card.PointValue})");
    }
        }
    }
}
