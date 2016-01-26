using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Moves.Generation
{
    public class PawnMovesGenerator : MovesGenerator
    {
        // TODO: Add Promotion, En Passant
        protected override IEnumerable<IMove> SpecialMoves => Enumerable.Empty<IMove>();

        // Safe to use "Piece" here, code only gets called when Piece != null in "IEnumerable<IMove> Moves" in base class
        protected override IEnumerable<ISquare> MovementSquares => GetPawnMovementSquares(Square, Piece.IsWhite);
        protected override IEnumerable<ISquare> CaptureSquares => GetPawnCaptureSquares(Square, Piece.IsWhite);
        private static IEnumerable<ISquare> GetPawnMovementSquares(ISquare square, bool isWhite)
        {
            var direction = isWhite ? Direction.Up : Direction.Down;
            var movementSquare = square.GetAdjacentSquareInDirection(direction);
            yield return movementSquare;
            var isStartingRank = isWhite ? square.Rank.Number == 2 : square.Rank.Number == 7;
            if (isStartingRank && movementSquare.Piece == null)
                yield return movementSquare.GetAdjacentSquareInDirection(direction);

        }
        private static IEnumerable<ISquare> GetPawnCaptureSquares(ISquare square, bool isWhite)
        {
            var directions = isWhite
                ? new[] { Direction.UpRight, Direction.UpLeft }
                : new[] { Direction.DownRight, Direction.DownLeft };
            return directions.Select(square.GetAdjacentSquareInDirection);
        }
    }
}