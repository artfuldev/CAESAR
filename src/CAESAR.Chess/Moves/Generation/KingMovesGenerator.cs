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
            => Square != null ? Directions.Select(Square.GetAdjacentSquareInDirection) : Enumerable.Empty<ISquare>();

        protected override IEnumerable<ISquare> CaptureSquares
            => MovementSquares;
    }
}