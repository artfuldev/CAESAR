using System;
using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Moves.Generation;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Pieces
{
    public abstract class Piece : IPiece
    {
        private readonly IMovesGenerator _movesGenerator;
        private ISquare _square;

        protected Piece(Side side, string name, char notation, IMovesGenerator movesGenerator)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "A piece cannot be constructed without a name");
            if (ReferenceEquals(null, movesGenerator))
                throw new ArgumentNullException(nameof(movesGenerator),
                    "A piece cannot be constructed without a move generator");
            Side = side;
            Name = name;
            notation = notation.ToString().ToLowerInvariant().ToCharArray().First();
            _movesGenerator = movesGenerator;
            switch (Side)
            {
                case Side.White:
                    Notation = notation.ToString().ToUpperInvariant().ToCharArray().First();
                    break;
                case Side.Black:
                    Notation = notation;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(side), "side must be black or white.");
            }
        }

        public Side Side { get; }

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
        public string Name { get; }
        public char Notation { get; }
    }
}