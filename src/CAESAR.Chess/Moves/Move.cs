using System;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves.Exceptions;
using CAESAR.Chess.Moves.Notations;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Players;

namespace CAESAR.Chess.Moves
{
    public abstract class Move : IMove
    {
        public string MoveString { get; protected set; }
        public IBoard Board { get; }
        private IBoard NextBoard { get; set; }
        protected Move(IBoard board, Side side, string move)
        {
            Board = (IBoard)board.Clone();
            Side = side;
            if (string.IsNullOrWhiteSpace(move))
                throw new ArgumentNullException(nameof(move), "Move String cannot be null or empty");
            MoveString = move;
        }

        public override string ToString() => MoveString;
        public Side Side { get; }

        public IBoard Make(IPlayer player)
        {
            if(player.Side != Side)
                throw new CannotMakeMoveException(MoveOperationFailureReason.PlayerNotOnCorrectSide);
            return NextBoard ?? (NextBoard = MakeImplementation(Board));
        }

        protected abstract IBoard MakeImplementation(IBoard board);

        public IBoard Undo(IPlayer player)
        {
            if (player.Side != Side)
                throw new CannotUndoMoveException(MoveOperationFailureReason.PlayerNotOnCorrectSide);
            return Board;
        }
        public string ToString(INotation notation) => notation?.ToString(this);
    }
}