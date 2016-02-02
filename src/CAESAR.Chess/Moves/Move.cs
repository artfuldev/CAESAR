using System;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves.Notations;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Moves
{
    public abstract class Move : IMove
    {
        public string MoveString { get; }
        private IBoard Previous { get; set; }
        protected Move(Side side, string move)
        {
            Side = side;
            if (string.IsNullOrWhiteSpace(move))
                throw new ArgumentNullException(nameof(move), "Move String cannot be null or empty");
            MoveString = move;
        }

        public override string ToString() => MoveString;
        public Side Side { get; }

        public IBoard Make(IBoard board)
        {
            Previous = board;
            return MakeImplementation();
        }

        protected abstract IBoard MakeImplementation();

        public IBoard Undo()
        {
            return Previous;
        }
        public string ToString(INotation notation) => notation?.ToString(this);
    }
}