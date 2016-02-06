using System.Collections.Generic;
using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Moves.Generation
{
    /// <summary>
    ///     Generates <seealso cref="IMove" />s for a particular <seealso cref="ISquare" />, based on the move
    ///     generation rules of the <seealso cref="Bishop" />.
    /// </summary>
    public class BishopMovesGenerator : DirectedMovesGenerator
    {
        /// <summary>
        ///     The <seealso cref="Direction" />s that a <seealso cref="Bishop" /> is allowed to move in.
        /// </summary>
        private static readonly IEnumerable<Direction> AllowedDirections = new[]
        {
            Direction.UpRight,
            Direction.DownRight,
            Direction.DownLeft,
            Direction.UpLeft
        };

        /// <summary>
        ///     The <seealso cref="Direction" />s in which this <seealso cref="MovesGenerator" /> can generate directed
        ///     <seealso cref="IMove" />s.
        /// </summary>
        protected override IEnumerable<Direction> Directions => AllowedDirections;
    }
}