using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Helpers;

namespace CAESAR.Chess.Moves.Generation
{
    public class BishopMovesGenerator : DirectedMovesGenerator
    {
        private static readonly IEnumerable<Direction> AllowedDirections = new[]
        {
            Direction.UpRight,
            Direction.DownRight,
            Direction.DownLeft,
            Direction.UpLeft
        };

        protected override IEnumerable<Direction> Directions => AllowedDirections;
    }
}