using System.Collections.Generic;

namespace CAESAR.Chess.PlayArea
{
    /// <summary>
    ///     Represents a file on the <seealso cref="IBoard" />. It's a named column on the chessboard.
    /// </summary>
    public interface IFile
    {
        /// <summary>
        ///     The name of this <seealso cref="IFile" />
        /// </summary>
        char Name { get; }

        /// <summary>
        ///     The <seealso cref="IBoard" /> to which this <seealso cref="IFile" /> belongs.
        /// </summary>
        IBoard Board { get; }

        /// <summary>
        ///     The <seealso cref="ISquare" />s that make up this <seealso cref="IFile" />.
        /// </summary>
        IReadOnlyCollection<ISquare> Squares { get; }
    }
}