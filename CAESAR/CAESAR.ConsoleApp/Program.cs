using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.Implementation;
using CAESAR.Chess.Pieces;

namespace CAESAR.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var board = new Board();
            board.Print();
            var player = new Player();
            var knight = new Knight(true);
            var knight2 = new Knight(true);
            player.Place(board, knight, "g1");
            player.Place(board, knight2, "b1");
            board.Print();
            Console.ReadLine();
            Console.WriteLine("Moves:");
            var knightMoves = knight.GetMoves();
            foreach (var move in knightMoves)
            {
                Console.WriteLine(move.ToString());
            }
            foreach (var move in knightMoves)
            {
                Console.WriteLine("Making move " + move);
                player.MakeMove(move);
                board.Print();
                Console.WriteLine("UnMaking move " + move);
                player.UnMakeMove(move);
                board.Print();
                Console.ReadLine();
            }
            Console.WriteLine("All moves played");
            Console.ReadLine();

            Console.WriteLine("Moves:");
            var knight2Moves = knight2.GetMoves();
            foreach (var move in knight2Moves)
            {
                Console.WriteLine(move.ToString());
            }
            foreach (var move in knight2Moves)
            {
                Console.WriteLine("Making move " + move);
                player.MakeMove(move);
                board.Print();
                Console.WriteLine("UnMaking move " + move);
                player.UnMakeMove(move);
                board.Print();
                Console.ReadLine();
            }
            Console.WriteLine("All moves played");
            Console.ReadLine();
            var firstMove = knight2Moves.FirstOrDefault();
            player.MakeMove(firstMove);
            knight2Moves = knight2.GetMoves();
            Console.WriteLine("Moves:");
            foreach (var move in knight2Moves)
            {
                Console.WriteLine(move.ToString());
            }
            foreach (var move in knight2Moves)
            {
                Console.WriteLine("Making move " + move);
                player.MakeMove(move);
                board.Print();
                Console.WriteLine("UnMaking move " + move);
                player.UnMakeMove(move);
                board.Print();
                Console.ReadLine();
            }
            Console.WriteLine("All moves played");
            Console.ReadLine();
        }
    }
}
