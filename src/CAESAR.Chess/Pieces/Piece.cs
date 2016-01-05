using System;
using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Implementation;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Moves.Generation;

namespace CAESAR.Chess.Pieces
{
    public abstract class Piece : IPiece
    {
        protected Piece(bool isWhite, string name, char notation, IMovesGenerator movesGenerator)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "A piece cannot be constructed without a name");
            if (ReferenceEquals(null, movesGenerator))
                throw new ArgumentNullException(nameof(movesGenerator),
                    "A piece cannot be constructed without a move generator");
            IsWhite = isWhite;
            Name = name;
            Notation = notation;
            _movesGenerator = movesGenerator;
            if (!IsWhite)
                Notation = Notation.ToString().ToLowerInvariant().ToCharArray().First();
        }

        public bool IsWhite { get; }
        public bool IsBlack => !IsWhite;

        public ISquare Square
        {
            get { return _square; }
            set
            {
                _square = value;
                _movesGenerator.Square = value;
            }
        }

        public IEnumerable<IMove> Moves => _movesGenerator.Moves;
        private readonly IMovesGenerator _movesGenerator;
        private ISquare _square;
        public string Name { get; }
        public char Notation { get; }
    }
}