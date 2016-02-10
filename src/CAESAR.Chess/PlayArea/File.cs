using System;
using System.Collections.Generic;
using System.Linq;

namespace CAESAR.Chess.PlayArea
{
    /// <summary>
    ///     Represents a file on the <seealso cref="IBoard" />. It's a named column on the chessboard.
    /// </summary>
    public class File : IFile
    {
        /// <summary>
        ///     Instantiates a <seealso cref="File" /> with an <seealso cref="IBoard" />, a <seealso cref="name" /> and the
        ///     <seealso cref="ISquare" />s it contains.
        /// </summary>
        /// <param name="board">The <seealso cref="IBoard" /> to which this <seealso cref="File" /> belongs.</param>
        /// <param name="name">The name of this <seealso cref="File" />.</param>
        /// <param name="squares">The <seealso cref="ISquare" />s that make up this <seealso cref="File" />.</param>
        public File(IBoard board, char name, IEnumerable<ISquare> squares)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board), "A file cannot be created without a board reference");
            if (name < 97 || name > 104)
                throw new ArgumentOutOfRangeException(nameof(name), "A file can only have names from a to h");
            if (squares == null)
                throw new ArgumentNullException(nameof(squares), "A file cannot be created without squares");
            var list = squares as List<ISquare> ?? squares.ToList();
            if (!list.Any())
                throw new ArgumentNullException(nameof(squares), "A file cannot be created without squares");
            if (list.Count() != 8)
                throw new ArgumentException("A file can only be created with 8 squares", nameof(squares));

            Board = board;
            Name = name;
            Squares = list.AsReadOnly();
        }

        /// <summary>
        ///     The name of this <seealso cref="File" />
        /// </summary>
        public char Name { get; }

        /// <summary>
        ///     The <seealso cref="IBoard" /> to which this <seealso cref="File" /> belongs.
        /// </summary>
        public IBoard Board { get; }

        /// <summary>
        ///     The <seealso cref="ISquare" />s that make up this <seealso cref="File" />.
        /// </summary>
        public IReadOnlyCollection<ISquare> Squares { get; }

        /// <summary>
        ///     Returns a string that represents the current <seealso cref="File" />. This is usually the <seealso cref="Name" />
        ///     of the <seealso cref="File" />.
        /// </summary>
        /// <returns>The <seealso cref="Name" /> of the <seealso cref="File" /> as a <seealso cref="string" />.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}