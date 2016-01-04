using System;
using System.Linq;
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
            var pawn = new Pawn(true);
            var pawn2 = new Pawn(false);
            var knight = new Knight(false);
            player.Place(board, pawn, "b2");
            player.Place(board, pawn2, "b7");
            player.Place(board, knight, "c3");
            board.Print();
            Console.ReadLine();
            Console.WriteLine("Moves:");
            var pawnMoves = pawn.Moves.ToList();
            foreach (var move in pawnMoves)
            {
                Console.WriteLine(move.ToString());
            }
            foreach (var move in pawnMoves)
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
            var pawn2Moves = pawn2.Moves.ToList();
            foreach (var move in pawn2Moves)
            {
                Console.WriteLine(move.ToString());
            }
            foreach (var move in pawn2Moves)
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
            var firstMove = pawn2Moves.FirstOrDefault();
            player.MakeMove(firstMove);
            pawn2Moves = pawn2.Moves.ToList();
            Console.WriteLine("Moves:");
            foreach (var move in pawn2Moves)
            {
                Console.WriteLine(move.ToString());
            }
            foreach (var move in pawn2Moves)
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
