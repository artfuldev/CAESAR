using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Helpers;

namespace CAESAR.Chess.Moves.Generation
{
    public class KingMovesGenerator : MovesGenerator
    {
        private static readonly IEnumerable<Direction> Directions = new[]
        {
            Direction.Up,
            Direction.UpRight,
            Direction.Right,
            Direction.DownRight,
            Direction.Down,
            Direction.DownLeft,
            Direction.Left,
            Direction.UpLeft
        };

        // TODO: Add Castle
        protected override IEnumerable<IMove> SpecialMoves => Enumerable.Empty<IMove>();

        protected override IEnumerable<ISquare> MovementSquares
            => Directions.Select(Square.GetAdjacentSquareInDirection);

        protected override IEnumerable<ISquare> CaptureSquares
            => Directions.Select(Square.GetAdjacentSquareInDirection);
    }
}