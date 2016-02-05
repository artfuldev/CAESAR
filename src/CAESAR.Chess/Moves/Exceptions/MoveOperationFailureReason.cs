using CAESAR.Chess.Core;
using CAESAR.Chess.Players;

namespace CAESAR.Chess.Moves.Exceptions
{
    /// <summary>
    ///     The reason for failure of the move operation.
    /// </summary>
    public enum MoveOperationFailureReason
    {
        /// <summary>
        ///     Unknown reason.
        /// </summary>
        Unknown,

        /// <summary>
        ///     The source square of the <seealso cref="IMove" /> is empty.
        /// </summary>
        SourceSquareIsEmpty,

        /// <summary>
        ///     The <seealso cref="IPlayer" /> used to play the <seealso cref="IMove" /> belongs to a different
        ///     <seealso cref="Side" />.
        /// </summary>
        PlayerNotOnCorrectSide
    }
}