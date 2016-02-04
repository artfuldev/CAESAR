using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CAESAR.Chess;
using CAESAR.Chess.Games;
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
            var board = game.Position.Board;
            var maxMovesCount = 200;
            board.Print();
            Console.ReadLine();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var movesPlayed1 = 0;
            for (movesPlayed1 = 0; movesPlayed1 < maxMovesCount; movesPlayed1++)
            {
                try
                {
                    game.Play();
                    var currentSideInCheck = game.CurrentSideInCheck;
                    board = game.Position.Board;
                    board.Print();
                    Console.WriteLine(string.Join(" ",
                        game.Moves.Select(x => x.ToString())) + (currentSideInCheck ? "+" : "") + " " + game.Status +
                                      " " + game.StatusReason);
                }
                catch
                {
                    break;
                }
            }
            stopwatch.Stop();
            var time1 = stopwatch.Elapsed;
            Console.WriteLine(movesPlayed1 + " moves played and printed in " + time1.Milliseconds + "ms");
            Console.WriteLine("Moves played and printed per second: " + (movesPlayed1 / time1.Milliseconds) * 1000);
            Console.WriteLine("All moves played");
            Console.ReadLine();
        }
    }
}