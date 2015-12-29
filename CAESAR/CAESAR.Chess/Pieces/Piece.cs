using System;
using System.Collections.Generic;
using System.Linq;

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
        public ISquare Square { get; }

        public IEnumerable<IMove> GetMoves()
        {
            if (Square == null)
                throw new NotSupportedException("A piece that is not in a square cannot have any moves");
            return GetMovesImplementation();
        }

        protected abstract IEnumerable<IMove> GetMovesImplementation(); 
        public string Name { get; }
        public char Notation { get; }
    }
}