using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Helpers;

namespace CAESAR.Chess.Moves.Generation
{
    public class QueenMovesGenenerator : DirectedMovesGenerator
    {
        private static readonly IEnumerable<Direction> AllowedDirections = new[]
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

        protected override IEnumerable<Direction> Directions => AllowedDirections;
    }
}