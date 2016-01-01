using System.Collections.Generic;
using System.Linq;

namespace CAESAR.Chess.Helpers
{
    public static class SquareExtensions
    {
        public static ISquare GetAdjacentSquareInDirection(this ISquare square, Direction direction)
        {
            return square.GetAdjacentSquaresInDirection(direction).FirstOrDefault();
        }

        public static IEnumerable<ISquare> GetAdjacentSquaresInDirectionTillNonEmptySquare(this ISquare square,
            Direction direction)
        {
            return GetAdjacentSquaresInDirection(square, direction).TakeWhileUntil(x => x != null, x => x.Piece != null);
        }

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

        public static IEnumerable<ISquare> GetKnightSquares(this ISquare square)
        {
            if (ReferenceEquals(null, square))
                yield break;

            var knightSquare = square.GetAdjacentSquareInDirection(Direction.UpRight).GetAdjacentSquareInDirection(Direction.Up);
            if (knightSquare != null)
                yield return knightSquare;

            knightSquare = square.GetAdjacentSquareInDirection(Direction.UpRight).GetAdjacentSquareInDirection(Direction.Right);
            if (knightSquare != null)
                yield return knightSquare;

            knightSquare = square.GetAdjacentSquareInDirection(Direction.DownRight).GetAdjacentSquareInDirection(Direction.Right);
            if (knightSquare != null)
                yield return knightSquare;

            knightSquare = square.GetAdjacentSquareInDirection(Direction.DownRight).GetAdjacentSquareInDirection(Direction.Down);
            if (knightSquare != null)
                yield return knightSquare;

            knightSquare = square.GetAdjacentSquareInDirection(Direction.DownLeft).GetAdjacentSquareInDirection(Direction.Down);
            if (knightSquare != null)
                yield return knightSquare;

            knightSquare = square.GetAdjacentSquareInDirection(Direction.DownLeft).GetAdjacentSquareInDirection(Direction.Left);
            if (knightSquare != null)
                yield return knightSquare;

            knightSquare = square.GetAdjacentSquareInDirection(Direction.UpLeft).GetAdjacentSquareInDirection(Direction.Left);
            if (knightSquare != null)
                yield return knightSquare;

            knightSquare = square.GetAdjacentSquareInDirection(Direction.UpLeft).GetAdjacentSquareInDirection(Direction.Up);
            if (knightSquare != null)
                yield return knightSquare;
        }

        public static IEnumerable<ISquare> GetPawnMovementSquares(this ISquare square, bool isWhite)
        {
            if (ReferenceEquals(null, square))
                yield break;
            var direction = isWhite ? Direction.Up : Direction.Down;
            var movementSquare = square.GetAdjacentSquareInDirection(direction);
            yield return movementSquare;
            var isStartingRank = isWhite ? square.Rank.Number == 2 : square.Rank.Number == 7;
            if (isStartingRank)
                yield return movementSquare.GetAdjacentSquareInDirection(direction);

        }

        public static IEnumerable<ISquare> GetPawnCaptureSquares(this ISquare square, bool isWhite)
        {
            if (ReferenceEquals(null, square))
                yield break;
            var directions = isWhite
                ? new[] {Direction.UpRight, Direction.UpLeft}
                : new[] {Direction.DownRight, Direction.DownLeft};
            foreach (var direction in directions)
                yield return square.GetAdjacentSquareInDirection(direction);
        }
    }
}