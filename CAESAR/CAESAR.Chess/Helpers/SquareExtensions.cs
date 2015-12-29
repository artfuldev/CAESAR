using System.Collections.Generic;
using System.Linq;

namespace CAESAR.Chess.Helpers
{
    public static class SquareExtensions
    {
        public static IEnumerable<ISquare> GetAdjacentSquaresInDirection(this ISquare square, Direction direction)
        {
            if (ReferenceEquals(null, square) || direction == Direction.None)
                yield break;
            
            var rankIndex = square.File.Squares.ToList().IndexOf(square);
            var fileIndex = square.Rank.Squares.ToList().IndexOf(square);

            switch (direction)
            {
                case Direction.Up:
                    while (rankIndex < 7)
                        yield return square.File.Squares.ElementAt(++rankIndex);
                    break;
                case Direction.Right:
                    while (fileIndex < 7)
                        yield return square.Rank.Squares.ElementAt(++fileIndex);
                    break;
                case Direction.Down:
                    while (rankIndex > 0)
                        yield return square.File.Squares.ElementAt(--rankIndex);
                    break;
                case Direction.Left:
                    while (fileIndex > 0)
                        yield return square.Rank.Squares.ElementAt(--fileIndex);
                    break;
                case Direction.UpRight:
                    while (rankIndex < 7 && fileIndex < 7)
                        yield return square.Board.Files.ElementAt(++fileIndex).Squares.ElementAt(++rankIndex);
                    break;
                case Direction.DownRight:
                    while(rankIndex > 0 && fileIndex < 7)
                        yield return square.Board.Files.ElementAt(++fileIndex).Squares.ElementAt(--rankIndex);
                    break;
                case Direction.DownLeft:
                    while (rankIndex > 0 && fileIndex > 0)
                        yield return square.Board.Files.ElementAt(--fileIndex).Squares.ElementAt(--rankIndex);
                    break;
                case Direction.UpLeft:
                    while (rankIndex < 7 && fileIndex > 0)
                        yield return square.Board.Files.ElementAt(--fileIndex).Squares.ElementAt(++rankIndex);
                    break;

            }
        }
    }
}