using System;

namespace CAESAR.Chess.Moves.Exceptions
{
    public class CannotMakeMoveException : InvalidOperationException
    {
        public CannotMakeMoveException(MoveOperationFailureReason reason = MoveOperationFailureReason.Unknown)
            : base("Cannot make move")
        {
            Reason = reason;
        }

        public MoveOperationFailureReason Reason { get; }
    }
}