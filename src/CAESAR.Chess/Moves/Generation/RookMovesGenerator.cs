using System.Collections.Generic;
using CAESAR.Chess.Helpers;

namespace CAESAR.Chess.Moves.Generation
{
    public class RookMovesGenerator : DirectedMovesGenerator
    {
        private static readonly IEnumerable<Direction> AllowedDirections = new[]
        {
            Direction.Up,
            Direction.Right,
            Direction.Down,
            Direction.Left
        };

        protected override IEnumerable<Direction> Directions => AllowedDirections;
    }
}