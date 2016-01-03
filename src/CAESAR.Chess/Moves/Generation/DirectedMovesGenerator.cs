using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Helpers;

namespace CAESAR.Chess.Moves.Generation
{
    // Directed moves are those which extend in a particular direction but stop when a piece is met or at the end of the board.
    // Examples are queen, bishop, and rook.
    public abstract class DirectedMovesGenerator : MovesGenerator
    {
        protected abstract IEnumerable<Direction> Directions { get; }
        protected override IEnumerable<ISquare> MovementSquares
            => Directions.SelectMany(direction => Square.GetAdjacentSquaresInDirectionTillNonEmptySquare(direction));
        protected override IEnumerable<ISquare> CaptureSquares => MovementSquares;
        protected override IEnumerable<IMove> SpecialMoves => Enumerable.Empty<IMove>();
    }
}