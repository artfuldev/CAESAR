using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Helpers;

namespace CAESAR.Chess.Moves.Generation
{
    public class KnightMovesGenerator : MovesGenerator
    {
        protected override IEnumerable<IMove> SpecialMoves => Enumerable.Empty<IMove>();
        protected override IEnumerable<ISquare> MovementSquares => GetKnightSquares(Square);
        protected override IEnumerable<ISquare> CaptureSquares => MovementSquares;
        private static IEnumerable<ISquare> GetKnightSquares(ISquare square)
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
    }
}