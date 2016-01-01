using System;
using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Implementation;

namespace CAESAR.Chess.Pieces
{
    public abstract class Piece : IPiece
    {
        protected Piece(bool isWhite, string name, char notation, ISquare square = null)
        {
            IsWhite = isWhite;
            Name = name;
            Notation = notation;
            if (!IsWhite)
                Notation = Notation.ToString().ToLowerInvariant().ToCharArray().First();
            Square = square;
        }

        public bool IsWhite { get; }
        public bool IsBlack => !IsWhite;
        public ISquare Square { get; set; }

        public IEnumerable<IMove> GetMoves()
        {
            return
                EligibleSquares.Distinct()
                    .Where(square => square != null)
                    .Where(square => square.Piece == null || square.Piece.IsWhite != IsWhite)
                    .Select(square => new Move(this, square));
        }

        protected abstract IEnumerable<ISquare> EligibleSquares { get; }
        public string Name { get; }
        public char Notation { get; }
    }
}