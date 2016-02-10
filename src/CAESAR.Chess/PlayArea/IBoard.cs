using System.Collections.Generic;
using CAESAR.Chess.Core;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.PlayArea
{
    /// <summary>
    ///     Represents a chessboard belonging to an <seealso cref="IPosition" />. It is made up of <seealso cref="IFile" />s,
    ///     <seealso cref="IRank" />s, all made up of <seealso cref="ISquare" />s. It is also an <seealso cref="ICloneable"/>.
    /// </summary>
    public interface IBoard : ICloneable
    {
        /// <summary>
        ///     The <seealso cref="IPosition" /> to which this <seealso cref="IBoard" /> belongs.
        /// </summary>
        IPosition Position { get; }

        /// <summary>
        ///     The <seealso cref="IFile" />s that this <seealso cref="IBoard" /> contains.
        /// </summary>
        IReadOnlyCollection<IFile> Files { get; }

        /// <summary>
        ///     The <seealso cref="IRank" />s that this <seealso cref="IBoard" /> contains.
        /// </summary>
        IReadOnlyCollection<IRank> Ranks { get; }

        /// <summary>
        ///     The <seealso cref="ISquare" />s that this <seealso cref="IBoard" /> contains.
        /// </summary>
        IReadOnlyCollection<ISquare> Squares { get; }

        /// <summary>
        ///     Gets the <seealso cref="ISquare" /> of the specified <seealso cref="squareName" /> that belongs to this
        ///     <seealso cref="IBoard" />.
        /// </summary>
        /// <param name="squareName">The name of the <seealso cref="ISquare" /> belonging to this <seealso cref="IBoard" />.</param>
        /// <returns>
        ///     The <seealso cref="ISquare" /> of the specified <seealso cref="squareName" /> that belongs to this
        ///     <seealso cref="IBoard" />.
        /// </returns>
        ISquare GetSquare(string squareName);

        /// <summary>
        ///     Gets the <seealso cref="ISquare" /> that belongs to the specified <seealso cref="IFile" /> and
        ///     <seealso cref="IRank" />.
        /// </summary>
        /// <param name="file">The <seealso cref="IFile" /> to which the <seealso cref="ISquare" /> belongs.</param>
        /// <param name="rank">The <seealso cref="IRank" /> to which the <seealso cref="ISquare" /> belongs.</param>
        /// <returns>
        ///     The <seealso cref="ISquare" /> that belongs to the specified <seealso cref="IFile" /> and
        ///     <seealso cref="IRank" />.
        /// </returns>
        ISquare GetSquare(IFile file, IRank rank);

        /// <summary>
        ///     Gets the <seealso cref="IFile" /> of the specified <seealso cref="fileName" /> that belongs to this
        ///     <seealso cref="IBoard" />.
        /// </summary>
        /// <param name="fileName">The name of the <seealso cref="IFile" /> belonging to this <seealso cref="IBoard" />.</param>
        /// <returns>
        ///     The <seealso cref="IFile" /> of the specified <seealso cref="fileName" /> that belongs to this
        ///     <seealso cref="IBoard" />.
        /// </returns>
        IFile GetFile(char fileName);

        /// <summary>
        ///     Gets the <seealso cref="IRank" /> of the specified <seealso cref="rankNumber" /> that belongs to this
        ///     <seealso cref="IBoard" />.
        /// </summary>
        /// <param name="rankNumber">The name of the <seealso cref="IRank" /> belonging to this <seealso cref="IBoard" />.</param>
        /// <returns>
        ///     The <seealso cref="IRank" /> of the specified <seealso cref="rankNumber" /> that belongs to this
        ///     <seealso cref="IBoard" />.
        /// </returns>
        IRank GetRank(byte rankNumber);
    }
}