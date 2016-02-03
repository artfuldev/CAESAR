using System;
using CAESAR.Chess.Games.Statuses;

namespace CAESAR.Chess.Games.Exceptions
{
    public class CannotPlayGameException : InvalidOperationException
    {
        public CannotPlayGameException(Status status, StatusReason reason):base("Cannot play game")
        {
            Status = status;
            Reason = reason;
        }

        public Status Status { get; }
        public StatusReason Reason { get; }
    }
}