using System;
using CAESAR.Chess;

namespace CAESAR.ConsoleApp
{
    public static class BoardExtensions
    {
        public static void Print(this IBoard board)
        {
            Console.WriteLine(board?.ToString());
        }
    }
}