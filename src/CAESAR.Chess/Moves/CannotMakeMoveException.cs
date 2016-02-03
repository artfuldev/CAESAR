using System;

namespace CAESAR.Chess.Moves
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
    public class CannotUndoMoveException : InvalidOperationException
    {
        public CannotUndoMoveException(MoveOperationFailureReason reason = MoveOperationFailureReason.Unknown)
            : base("Cannot undo move")
        {
            Reason = reason;
        }

        public MoveOperationFailureReason Reason { get; }
    }

    public enum MoveOperationFailureReason
    {
        Unknown,
        SourceSquareIsEmpty,
        PlayerNotOnCorrectSide
    }
}