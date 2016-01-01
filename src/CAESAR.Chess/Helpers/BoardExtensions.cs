using System;
using System.Linq;

namespace CAESAR.Chess.Helpers
{
    public static class BoardExtensions
    {
        public static void Print(this IBoard board)
        {
            foreach (var rank in board.Ranks.Reverse())
            {

                Console.WriteLine("________________________________");
                Console.WriteLine(rank.Squares.Aggregate("",
                    (current, square) => current + ("| " + (square.Piece?.Notation ?? ' ') + " ")) + "| "+ rank.Number);
            }
            Console.WriteLine("________________________________");
            Console.WriteLine("  a   b   c   d   e   f   g   h");
        }
    }
}