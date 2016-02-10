using System;
using CAESAR.Chess.Pieces;

namespace CAESAR.Chess.PlayArea
{
    /// <summary>
    ///     Represents a square on the <seealso cref="IBoard" />. It's a named square on the chessboard, belonging to a
    ///     <seealso cref="IFile" /> and an <seealso cref="IRank" />. It can be light or dark, and can be empty or can be
    ///     occupied by an <seealso cref="IPiece" />.
    /// </summary>
    public class Square : ISquare
    {
        /// <summary>
        ///     The backing field for <seealso cref="Piece" />.
        /// </summary>
        private IPiece _piece;

        /// <summary>
        ///     Instantiates a <seealso cref="Square" />, with an <seealso cref="IBoard" />, an <seealso cref="IFile" />, an
        ///     <seealso cref="IRank" />, a <seealso cref="name" />, and a boolean indicating whether it is light.
        /// </summary>
        /// <param name="board">The <seealso cref="IBoard" /> to which this <seealso cref="Square" /> belongs.</param>
        /// <param name="file">The <seealso cref="IFile" /> to which this <seealso cref="Square" /> belongs.</param>
        /// <param name="rank">The <seealso cref="IRank" /> to which this <seealso cref="Square" /> belongs.</param>
        /// <param name="name">The name of this <seealso cref="Square" />.</param>
        /// <param name="isLight">A boolean indicating whether this <seealso cref="Square" /> is light.</param>
        public Square(IBoard board, IFile file, IRank rank, string name, bool isLight = false)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board),
                    "A square cannot be constructed without a board reference");
            if (file == null)
                throw new ArgumentNullException(nameof(file),
                    "A square cannot be constructed without a file reference");
            if (rank == null)
                throw new ArgumentNullException(nameof(rank),
                    "A square cannot be constructed without a rank reference");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("A square cannot have an empty name", nameof(name));
            Board = board;
            File = file;
            Rank = rank;
            Name = name;
            IsLight = isLight;
        }

        /// <summary>
        ///     The <seealso cref="IBoard" /> to which this <seealso cref="Square" /> belongs.
        /// </summary>
        public IBoard Board { get; }

        /// <summary>
        ///     The <seealso cref="IPiece" /> that occupies this <seealso cref="Square" />, if any. Setting an
        ///     <seealso cref="IPiece" /> also sets the <seealso cref="IPiece" />'s <seealso cref="ISquare" /> to this instance of
        ///     <seealso cref="ISquare" />.
        /// </summary>
        public IPiece Piece
        {
            get { return _piece; }
            set
            {
                _piece = value;
                if (Piece != null)
                    Piece.Square = this;
            }
        }

        /// <summary>
        ///     The <seealso cref="IFile" /> to which this <seealso cref="Square" /> belongs.
        /// </summary>
        public IFile File { get; }

        /// <summary>
        ///     The <seealso cref="IRank" /> to which this <seealso cref="Square" /> belongs.
        /// </summary>
        public IRank Rank { get; }

        /// <summary>
        ///     The name of this <seealso cref="Square" />.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     A boolean that tells if this <seealso cref="Square" /> is light.
        /// </summary>
        public bool IsLight { get; }

        /// <summary>
        ///     A boolean that tells if this <seealso cref="Square" /> is dark.
        /// </summary>
        public bool IsDark => !IsLight;

        /// <summary>
        ///     A boolean that tells if this <seealso cref="Square" /> is empty.
        /// </summary>
        public bool IsEmpty => Piece == null;

        /// <summary>
        ///     A boolean that tells if this <seealso cref="Square" /> is occupied by an <seealso cref="IPiece" />.
        /// </summary>
        public bool HasPiece => !IsEmpty;

        /// <summary>
        ///     Returns a string that represents the current <seealso cref="Square" />. This is usually the <seealso cref="Name" />
        ///     of the <seealso cref="Square" />.
        /// </summary>
        /// <returns>The <seealso cref="Name" /> of the <seealso cref="Square" />.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return Name;
        }
    }
}