using System;

namespace CAESAR.Chess.Moves.Exceptions
{
    /// <summary>
    ///     The exception that is thrown when an <seealso cref="IMove" /> cannot be made.
    /// </summary>
    public class CannotMakeMoveException : InvalidOperationException
    {
        /// <summary>
        ///     Initializes a new instance of the <seealso cref="CannotMakeMoveException" /> with the specified
        ///     <seealso cref="MoveOperationFailureReason" />.
        /// </summary>
        /// <param name="reason">The specified <seealso cref="MoveOperationFailureReason" />.</param>
        public CannotMakeMoveException(MoveOperationFailureReason reason = MoveOperationFailureReason.Unknown)
            : base("Cannot make move")
        {
            Reason = reason;
        }

        /// <summary>
        ///     The <seealso cref="MoveOperationFailureReason" /> that the playing of the <seealso cref="IMove" /> failed.
        /// </summary>
        public MoveOperationFailureReason Reason { get; }
    }
}