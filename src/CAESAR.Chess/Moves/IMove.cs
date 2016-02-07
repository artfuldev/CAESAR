using CAESAR.Chess.Core;
using CAESAR.Chess.Moves.Notations;
using CAESAR.Chess.Players;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Moves
{
    /// <summary>
    ///     Represents a move that is made on the chessboard. <seealso cref="IMove" />s can be made and unmade on
    ///     <seealso cref="IPosition" />s, and can be written as a <seealso cref="string" /> in various
    ///     <seealso cref="INotation" />s.
    /// </summary>
    public interface IMove
    {
        /// <summary>
        ///     The <seealso cref="Core.Side" /> to which the <seealso cref="IMove" /> belongs.
        /// </summary>
        Side Side { get; }

        /// <summary>
        ///     The <seealso cref="IPosition" /> to which the <seealso cref="IMove" /> belongs.
        /// </summary>
        IPosition Position { get; }

        /// <summary>
        ///     Makes the <seealso cref="IMove" /> on the <seealso cref="IPosition" /> and returns a new instance of
        ///     <seealso cref="IPosition" />.
        /// </summary>
        /// <returns>An <seealso cref="IPosition" /> with this <seealso cref="IMove" /> already made on it.</returns>
        IPosition Make(IPlayer player);

        /// <summary>
        ///     Undoes the <seealso cref="IMove" /> on the <seealso cref="IPosition" /> and returns a new instance of
        ///     <seealso cref="IPosition" />.
        /// </summary>
        /// <returns>An <seealso cref="IPosition" /> with this <seealso cref="IMove" /> undone on it.</returns>
        IPosition Undo(IPlayer player);

        /// <summary>
        ///     Returns a string representation of the <seealso cref="IMove" /> in the specified <seealso cref="INotation" />.
        /// </summary>
        /// <param name="notation">The <seealso cref="INotation" /> to be used to represent the <seealso cref="IMove" />.</param>
        /// <returns>
        ///     A <seealso cref="string" /> representation of the <seealso cref="IMove" /> in the specified
        ///     <seealso cref="notation" />.
        /// </returns>
        string ToString(INotation notation);
    }
}