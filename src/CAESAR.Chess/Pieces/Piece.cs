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
                if (_movesGenerator != null)
                    _movesGenerator.Square = value;
            }
        }

        public IEnumerable<IMove> Moves => _movesGenerator?.Moves ?? Enumerable.Empty<IMove>();
        private readonly IMovesGenerator _movesGenerator;
        private ISquare _square;
        public string Name { get; }
        public char Notation { get; }
    }
}