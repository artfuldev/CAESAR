using System;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves.Exceptions;
using CAESAR.Chess.Moves.Notations;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Players;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Moves
{
    public abstract class Move : IMove
    {
        public string MoveString { get; protected set; }
        public IPosition Position { get; }
        private IPosition NextPosition { get; set; }
        protected Move(IPosition position, Side side, string move)
        {
            Position = (IPosition)position.Clone();
            Side = side;
            if (string.IsNullOrWhiteSpace(move))
                throw new ArgumentNullException(nameof(move), "Move String cannot be null or empty");
            MoveString = move;
        }

        public override string ToString() => MoveString;
        public Side Side { get; }

        public IPosition Make(IPlayer player)
        {
            if(player.Side != Side)
                throw new CannotMakeMoveException(MoveOperationFailureReason.PlayerNotOnCorrectSide);
            return NextPosition ?? (NextPosition = MakeImplementation(Position));
        }

        protected abstract IPosition MakeImplementation(IPosition position);

        public IPosition Undo(IPlayer player)
        {
            if (player.Side != Side)
                throw new CannotUndoMoveException(MoveOperationFailureReason.PlayerNotOnCorrectSide);
            return Position;
        }
        public string ToString(INotation notation) => notation?.ToString(this);
    }
}