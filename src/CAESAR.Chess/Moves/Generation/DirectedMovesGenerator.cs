using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Moves.Generation
{
    // Directed moves are those which extend in a particular direction but stop when a piece is met or at the end of the board.
    // Examples are queen, bishop, and rook.
    public abstract class DirectedMovesGenerator : MovesGenerator
    {
        protected abstract IEnumerable<Direction> Directions { get; }

        protected override IEnumerable<ISquare> MovementSquares
            => Directions.SelectMany(direction => GetAdjacentSquaresInDirectionTillNonEmptySquare(Square, direction));

        protected override IEnumerable<ISquare> CaptureSquares => MovementSquares;
        protected override IEnumerable<IMove> SpecialMoves => Enumerable.Empty<IMove>();

        private static IEnumerable<ISquare> GetAdjacentSquaresInDirectionTillNonEmptySquare(ISquare square,
            Direction direction)
        {
            return square.GetAdjacentSquaresInDirection(direction)
                .TakeWhileUntil(x => x != null && x.Piece == null, x => x.Piece != null);
        }
    }
}