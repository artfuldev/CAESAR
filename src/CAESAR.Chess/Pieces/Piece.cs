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

        protected Piece(Side side, PieceType pieceType, IMovesGenerator movesGenerator)
        {
            if (ReferenceEquals(null, movesGenerator))
                throw new ArgumentNullException(nameof(movesGenerator),
                    "A piece cannot be constructed without a move generator");
            _movesGenerator = movesGenerator;
            PieceType = pieceType;
            Name = PieceType.ToString();
            Notation = PieceType.GetNotation();
            Side = side;
            if (Side == Side.Black)
                Notation = Notation.ToString().ToLowerInvariant().ToCharArray()[0];
        }

        public Side Side { get; }

        public ISquare Square
        {
            get { return _movesGenerator.Square; }
            set { _movesGenerator.Square = value; }
        }

        public IEnumerable<IMove> Moves => _movesGenerator.Moves;
        public string Name { get; }
        public char Notation { get; }
        public PieceType PieceType { get; }
        public abstract object Clone();
    }
}