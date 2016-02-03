using System;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves.Notations;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Moves
{
    public abstract class Move : IMove
    {
        public string MoveString { get; }
        public IBoard Board { get; }
        private IBoard NextBoard { get; set; }
        protected Move(IBoard board, Side side, string move)
        {
            Board = board;
            Side = side;
            if (string.IsNullOrWhiteSpace(move))
                throw new ArgumentNullException(nameof(move), "Move String cannot be null or empty");
            MoveString = move;
        }

        public override string ToString() => MoveString;
        public Side Side { get; }

        public IBoard Make()
        {
            return NextBoard ?? (NextBoard = MakeImplementation((IBoard) Board.Clone()));
        }

        protected abstract IBoard MakeImplementation(IBoard board);

        public IBoard Undo()
        {
            return Board;
        }
        public string ToString(INotation notation) => notation?.ToString(this);
    }
}