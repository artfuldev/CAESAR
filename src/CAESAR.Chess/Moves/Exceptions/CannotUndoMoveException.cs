using System;

namespace CAESAR.Chess.Moves.Exceptions
{
    /// <summary>
    ///     The exception that is thrown when an <seealso cref="IMove" /> cannot be undone.
    /// </summary>
    public class CannotUndoMoveException : InvalidOperationException
    {
        /// <summary>
        ///     Initializes a new instance of the <seealso cref="CannotUndoMoveException" /> with the specified
        ///     <seealso cref="MoveOperationFailureReason" />.
        /// </summary>
        /// <param name="reason">The specified <seealso cref="MoveOperationFailureReason" />.</param>
        public CannotUndoMoveException(MoveOperationFailureReason reason = MoveOperationFailureReason.Unknown)
            : base("Cannot undo move")
        {
            Reason = reason;
        }

        /// <summary>
        ///     The <seealso cref="MoveOperationFailureReason" /> that the undo of the <seealso cref="IMove" /> failed.
        /// </summary>
        public MoveOperationFailureReason Reason { get; }
    }
}