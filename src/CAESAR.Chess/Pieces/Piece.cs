using System;
using System.Collections.Generic;
using CAESAR.Chess.Core;
using CAESAR.Chess.Games;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Moves.Generation;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Pieces
{
    /// <summary>
    ///     Represents a piece in the <seealso cref="IGame" />. It belongs to a <seealso cref="Core.Side" />, occupies an
    ///     <seealso cref="ISquare" />, and can have <seealso cref="IMove" />s available. Every <seealso cref="Piece" /> has a
    ///     name, notation and is of a certain <seealso cref="Pieces.PieceType" />.
    /// </summary>
    public abstract class Piece : IPiece
    {
        /// <summary>
        ///     The <seealso cref="IMovesGenerator" /> for this <seealso cref="Piece" />.
        /// </summary>
        private readonly IMovesGenerator _movesGenerator;

        /// <summary>
        ///     Instantiates a <seealso cref="Piece" /> with its <seealso cref="Core.Side" />, <seealso cref="Pieces.PieceType" />,
        ///     and <seealso cref="IMovesGenerator" />.
        /// </summary>
        /// <param name="side">The <seealso cref="Core.Side" /> to which this <seealso cref="Piece" /> belongs.</param>
        /// <param name="pieceType">The <seealso cref="Pieces.PieceType" /> of this <seealso cref="Piece" />.</param>
        /// <param name="movesGenerator">The <seealso cref="IMovesGenerator" /> for this <seealso cref="Piece" />.</param>
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

        /// <summary>
        ///     The <seealso cref="Core.Side" /> to which this <seealso cref="Piece" /> belongs.
        /// </summary>
        public Side Side { get; }

        /// <summary>
        ///     The <seealso cref="ISquare" /> occupied by this <seealso cref="Piece" />, if any. This merely encapsulates the
        ///     <seealso cref="ISquare" /> of its <seealso cref="IMovesGenerator" />.
        /// </summary>
        public ISquare Square
        {
            get { return _movesGenerator.Square; }
            set { _movesGenerator.Square = value; }
        }

        /// <summary>
        ///     The <seealso cref="IMove" />s that can be made by this <seealso cref="IPiece" />. This is calculated by the
        ///     <seealso cref="IMovesGenerator" />.
        /// </summary>
        public IEnumerable<IMove> Moves => _movesGenerator.Moves;

        /// <summary>
        ///     The name of this <seealso cref="Piece" />, used purely for identification.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     The notation of this <seealso cref="Piece" />. Helps to identify a <seealso cref="Piece" /> enough to represent it
        ///     on an <seealso cref="IBoard" />, and also enough to clone it.
        /// </summary>
        public char Notation { get; }

        /// <summary>
        ///     The <seealso cref="Pieces.PieceType" /> of this <seealso cref="Piece" />.
        /// </summary>
        public PieceType PieceType { get; }

        /// <summary>
        ///     Return a clone of the current <seealso cref="Piece" />.
        /// </summary>
        /// <returns>An <seealso cref="IPiece" /> that is the clone of the current <seealso cref="Piece" />.</returns>
        public object Clone()
        {
            return PieceType.GetPiece(Side);
        }
    }
}