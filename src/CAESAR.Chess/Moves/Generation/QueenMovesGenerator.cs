using System.Collections.Generic;
using CAESAR.Chess.Core;
using CAESAR.Chess.Helpers;

namespace CAESAR.Chess.Moves.Generation
{
    public class QueenMovesGenerator : DirectedMovesGenerator
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