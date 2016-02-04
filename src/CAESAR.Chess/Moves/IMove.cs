using CAESAR.Chess.Core;
using CAESAR.Chess.Moves.Notations;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Players;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Moves
{
    /// <summary>
    ///     Represents a move that is made on the chessboard. Moves can be made and unmade on positions, and can be written as a
    ///     string in various notations
    /// </summary>
    public interface IMove
    {
        /// <summary>
        /// The <seealso cref="Core.Side"/> to which the move belongs.
        /// </summary>
        Side Side { get; }
        /// <summary>
        /// The <seealso cref="IPosition"/> to which the move belongs.
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
        ///     Returns a string representation of the move in the specified <seealso cref="INotation" />.
        /// </summary>
        /// <param name="notation">The <seealso cref="INotation" /> to be used to represent the move.</param>
        /// <returns>A <seealso cref="string" /> representation of the move in the specified <seealso cref="INotation" />.</returns>
        string ToString(INotation notation);
    }
}