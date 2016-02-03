using System;

namespace CAESAR.Chess.Moves.Exceptions
{
    public class CannotUndoMoveException : InvalidOperationException
    {
        public CannotUndoMoveException(MoveOperationFailureReason reason = MoveOperationFailureReason.Unknown)
            : base("Cannot undo move")
        {
            Reason = reason;
        }

        public MoveOperationFailureReason Reason { get; }
    }
}