using CAESAR.Chess.Games;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Moves.Notations
{
    /// <summary>
    ///     Denotes a system to record either the <seealso cref="IMove" />s made in an <seealso cref="IGame" /> of chess, or
    ///     the <seealso cref="IPosition" /> of a chessboard.
    /// </summary>
    public interface INotation
    {
        /// <summary>
        ///     Gets the string representation of the <seealso cref="IMove" /> in this particular <seealso cref="INotation" />.
        /// </summary>
        /// <param name="move">The <seealso cref="IMove" /> for which the notation is required.</param>
        /// <returns>The string representation of the <seealso cref="IMove" /> in this particular <seealso cref="INotation" />.</returns>
        string ToString(IMove move);
    }
}