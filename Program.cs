using ElevensProject.Models;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        int[] values = { 1,2,3,4,5,6,7,8,9,10,0,0,0 };

        Deck deck = new Deck(ranks, suits, values);
        ElevensBoard board = new ElevensBoard(deck);
        board.DealBoard(9);

        Console.WriteLine("Initial Board:");
        board.DisplayBoard();

        Console.WriteLine($"\nAnother play possible? {board.AnotherPlayIsPossible()}");
    }
}
