using System;
using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Players;

namespace CAESAR.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var whitePlayer = new Player("white");
            var blackPlayer = new Player("black");
            var movesList = new List<IMove>();
            var game = new Game(null, whitePlayer, blackPlayer, movesList);
            var board = game.Board;
            board.Print();
            Console.ReadLine();
            for (var i = 0; i < 10; i++)
            {
                game.PlayNextMove();
                board.Print();
                Console.WriteLine(string.Join(" ", game.Moves.Select(x => x.ToString())));
                Console.ReadLine();
            }
            Console.WriteLine("All moves played");
            Console.ReadLine();
        }
    }
}