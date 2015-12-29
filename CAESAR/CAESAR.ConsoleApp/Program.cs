using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.Implementation;

namespace CAESAR.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var board = new Board();
            var outputString = board.Squares.Aggregate("", (current, x) => current + (x.Name + ", "));
            outputString = outputString.TrimEnd(',',' ');
            Console.WriteLine(outputString);
            Console.ReadLine();

            var square = board.Squares.First(x => x.Name == "g2");
            var upSquares = square.GetAdjacentSquaresInDirection(Direction.Up);
            var rightSquares = square.GetAdjacentSquaresInDirection(Direction.Right);
            var downSquares = square.GetAdjacentSquaresInDirection(Direction.Down);
            var leftSquares = square.GetAdjacentSquaresInDirection(Direction.Left);
            var upRightSquares = square.GetAdjacentSquaresInDirection(Direction.UpRight);
            var downRightSquares = square.GetAdjacentSquaresInDirection(Direction.DownRight);
            var downLeftSquares = square.GetAdjacentSquaresInDirection(Direction.DownLeft);
            var upLeftSquares = square.GetAdjacentSquaresInDirection(Direction.UpLeft);
            Console.ReadLine();
        }
    }
}
