using System;
using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Implementation;

namespace CAESAR.Chess.Pieces
{
    public abstract class Piece : IPiece
    {
        protected Piece(bool isWhite, string name, char notation)
        {
            IsWhite = isWhite;
            Name = name;
            Notation = notation;
            if (!IsWhite)
                Notation = Notation.ToString().ToLowerInvariant().ToCharArray().First();
        }

        public bool IsWhite { get; }
        public bool IsBlack => !IsWhite;
        public ISquare Square { get; set; }

        public IEnumerable<IMove> GetMoves()
        {
            return Moves.Concat(Captures).Concat(SpecialMoves);
        }

        private IEnumerable<IMove> Moves => MovementSquares.Distinct()
            .Where(square => square != null && square.Piece == null)
            .Select(square => new Move(this, square));
        private IEnumerable<IMove> Captures => CaptureSquares.Distinct()
            .Where(square => square?.Piece != null && square.Piece.IsWhite != IsWhite)
            .Select(square => new Move(this, square, MoveType.Capture));
        // TODO: Implement
        private IEnumerable<IMove> SpecialMoves => Enumerable.Empty<IMove>(); 
        protected abstract IEnumerable<ISquare> MovementSquares { get; }
        protected abstract IEnumerable<ISquare> CaptureSquares { get; }
        public string Name { get; }
        public char Notation { get; }
    }
}