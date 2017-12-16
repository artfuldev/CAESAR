using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CAESAR.Chess;
using CAESAR.Chess.Games;
using CAESAR.Chess.Games.Exceptions;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Moves.Notations;
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
            var notation = new ShortAlgebraicNotation();
            var game = new Game(null, whitePlayer, blackPlayer, movesList);
            var maxMovesCount = 200;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int moveCount;
            var moves = new StringBuilder();
            for (moveCount = 0; moveCount < maxMovesCount; moveCount++)
            {
                try
                {
                    game.Play();
                    var currentSideInCheck = game.CurrentSideInCheck;
                    var lastMove = movesList.Last().ToString(notation) + (currentSideInCheck ? "+" : "");
                    if (moveCount%2 == 0)
                        moves.AppendFormat("{0:D}. {1} ", ((moveCount/2) + 1), lastMove);
                    else
                        moves.AppendLine(lastMove);
                    if (moveCount != maxMovesCount - 1) continue;
                    var board = game.Position.Board;
                    board.Print();
                    Console.WriteLine(moves.ToString());
                    Console.WriteLine(game.Status + " " + game.StatusReason);
                }
                catch(CannotPlayGameException)
                {
                    var board = game.Position.Board;
                    board.Print();
                    Console.WriteLine(moves.ToString());
                    Console.WriteLine(game.Status + " " + game.StatusReason);
                    break;
                }
            }
            stopwatch.Stop();
            var time1 = stopwatch.Elapsed;
            Console.WriteLine(moveCount + " moves played and printed in " + time1.Milliseconds + "ms");
            Console.WriteLine("Moves played and printed per second: " + (moveCount / time1.Milliseconds) * 1000);
            Console.WriteLine("All moves played");
            Console.ReadKey();
        }
    }
}