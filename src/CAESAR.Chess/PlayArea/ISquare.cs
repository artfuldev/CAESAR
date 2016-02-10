using CAESAR.Chess.Pieces;

namespace CAESAR.Chess.PlayArea
{
    /// <summary>
    ///     Represents a square on the <seealso cref="IBoard" />. It's a named square on the chessboard, belonging to a
    ///     <seealso cref="IFile" /> and an <seealso cref="IRank" />. It can be light or dark, and can be empty or can be
    ///     occupied by an <seealso cref="IPiece" />.
    /// </summary>
    public interface ISquare
    {
        /// <summary>
        ///     The <seealso cref="IFile" /> to which this <seealso cref="ISquare" /> belongs.
        /// </summary>
        IFile File { get; }

        /// <summary>
        ///     The <seealso cref="IRank" /> to which this <seealso cref="ISquare" /> belongs.
        /// </summary>
        IRank Rank { get; }

        /// <summary>
        ///     The name of this <seealso cref="ISquare" />.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     A boolean that tells if this <seealso cref="ISquare" /> is light.
        /// </summary>
        bool IsLight { get; }

        /// <summary>
        ///     A boolean that tells if this <seealso cref="ISquare" /> is dark.
        /// </summary>
        bool IsDark { get; }

        /// <summary>
        ///     The <seealso cref="IBoard" /> to which this <seealso cref="ISquare" /> belongs.
        /// </summary>
        IBoard Board { get; }

        /// <summary>
        ///     The <seealso cref="IPiece" /> that occupies this <seealso cref="ISquare" />, if any.
        /// </summary>
        IPiece Piece { get; set; }

        /// <summary>
        ///     A boolean that tells if this <seealso cref="ISquare" /> is empty.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        ///     A boolean that tells if this <seealso cref="ISquare" /> is occupied by an <seealso cref="IPiece" />.
        /// </summary>
        bool HasPiece { get; }
    }
}