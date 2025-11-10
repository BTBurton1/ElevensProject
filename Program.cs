using ElevensProject.Models;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        int[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 0, 0, 0 };

        Deck deck = new Deck(ranks, suits, values);
        ElevensBoard board = new ElevensBoard(deck);
        board.ResetBoard(9);
        // board.ForceFaceCardTriple(); (uncomment this if you wanna force triple face cards on the board)



        Console.WriteLine("Welcome to Elevens!");

        while (true)
        {
            Console.WriteLine("\nCurrent Board:");
            board.DisplayBoard();

            if (!board.AnotherPlayIsPossible())
            {
                if (board.DeckIsEmpty())
                    Console.WriteLine("\n You win! No cards left!");
                else
                    Console.WriteLine("\n No more moves left. You lose!");

                Console.WriteLine("\nThanks for playing!");
                break;
            }

            Console.WriteLine("\nEnter card positions to select (comma-separated):");
            Console.WriteLine("Example: 0,1 for pairs or 0,1,2 for JQK");
            Console.WriteLine("Type 'q' or 'quit' to exit the game!");
            Console.Write("Your move: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }
            if (input.Trim().ToLower() == "q" || input.Trim().ToLower() == "quit")
            {
                Console.WriteLine("\n Thanks for playing! :>");
                break;
            }


            List<int> selected = new List<int>();
            string[] parts = input!.Split(',', ' ', '-', ';');

            foreach (string p in parts)
            {
                if (int.TryParse(p.Trim(), out int index))
                    selected.Add(index);
            }

            if (board.IsLegal(selected))
            {
                board.RemoveSelectedCards(selected);
                Console.WriteLine("Move accepted!");
            }
            else
            {
                Console.WriteLine("Invalid selection. Try again!");
            }
        }
    }
}
