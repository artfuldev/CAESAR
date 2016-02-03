using CAESAR.Chess.Core;
using CAESAR.Chess.Moves.Notations;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Players;

namespace CAESAR.Chess.Moves
{
    /// <summary>
    ///     Represents a move that is made on the chessboard. Moves can be made and unmade on a board, and can be written as a
    ///     string in various notations
    /// </summary>
    public interface IMove
    {
        /// <summary>
        /// The <seealso cref="Core.Side"/> to which the move belongs.
        /// </summary>
        Side Side { get; }
        /// <summary>
        /// The <seealso cref="IBoard"/> to which the move belongs.
        /// </summary>
        IBoard Board { get; }

        /// <summary>
        ///     Makes the <seealso cref="IMove" /> on the <seealso cref="IBoard" /> and returns a new instance of
        ///     <seealso cref="IBoard" />.
        /// </summary>
        /// <returns>An <seealso cref="IBoard" /> with this <seealso cref="IMove" /> already made on it.</returns>
        IBoard Make(IPlayer player);

        /// <summary>
        ///     Undoes the <seealso cref="IMove" /> on the <seealso cref="IBoard" /> and returns a new instance of
        ///     <seealso cref="IBoard" />.
        /// </summary>
        /// <returns>An <seealso cref="IBoard" /> with this <seealso cref="IMove" /> undone on it.</returns>
        IBoard Undo(IPlayer player);

        /// <summary>
        ///     Returns a string representation of the move in the specified <seealso cref="INotation" />.
        /// </summary>
        /// <param name="notation">The <seealso cref="INotation" /> to be used to represent the move.</param>
        /// <returns>A <seealso cref="string" /> representation of the move in the specified <seealso cref="INotation" />.</returns>
        string ToString(INotation notation);
    }
}