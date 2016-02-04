using System;
using CAESAR.Chess.Games.Statuses;

namespace CAESAR.Chess.Games.Exceptions
{
    /// <summary>
    ///     The exception that is thrown when an <seealso cref="IGame" /> cannot be played.
    /// </summary>
    public class CannotPlayGameException : InvalidOperationException
    {
        /// <summary>
        ///     Constructor for the <seealso cref="CannotPlayGameException" />.
        /// </summary>
        /// <param name="status">The status of the <seealso cref="IGame" /> that cannot be played.</param>
        /// <param name="reason">The reason that the <seealso cref="IGame" /> cannot be played.</param>
        public CannotPlayGameException(Status status, StatusReason reason) : base("Cannot play game")
        {
            Status = status;
            Reason = reason;
        }

        /// <summary>
        ///     The status of the <seealso cref="IGame" /> that cannot be played
        /// </summary>
        public Status Status { get; }

        /// <summary>
        ///     The reason that the <seealso cref="IGame" /> cannot be played.
        /// </summary>
        public StatusReason Reason { get; }
    }
}