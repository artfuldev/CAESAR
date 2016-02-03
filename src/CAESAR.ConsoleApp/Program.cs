using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var maxMovesCount = 200;
            board.Print();
            Console.ReadLine();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (var i = 0; i < maxMovesCount; i++)
            {
                game.PlayNextMove();
                board = game.Board;
                board.Print();
                Console.WriteLine(string.Join(" ", game.Moves.Select(x => x.ToString())));
            }
            stopwatch.Stop();
            var time1 = stopwatch.Elapsed;
            movesList = new List<IMove>();
            game = new Game(null, whitePlayer, blackPlayer, movesList);
            stopwatch.Restart();
            for (var i = 0; i < maxMovesCount; i++)
            {
                game.PlayNextMove();
            }
            stopwatch.Stop();
            var time2 = stopwatch.Elapsed;
            Console.WriteLine(maxMovesCount + " moves played and printed in " + time1.Milliseconds + "ms");
            Console.WriteLine("Moves played and printed per second: " + maxMovesCount/time1.Seconds);
            Console.WriteLine(maxMovesCount + " moves played in " + time2.Milliseconds + "ms");
            Console.WriteLine("Moves played per second: " + (maxMovesCount/time2.Milliseconds)*1000);
            Console.WriteLine("All moves played");
            Console.ReadLine();
        }
    }
}