using System;
using System.Collections.Generic;
using System.Linq;

namespace CAESAR.Chess.PlayArea
{
    /// <summary>
    ///     Represents a rank on the <seealso cref="IBoard" />. It's a numbered row on the chessboard.
    /// </summary>
    public class Rank : IRank
    {
        /// <summary>
        ///     Instantiates a <seealso cref="Rank" /> with an <seealso cref="IBoard" />, a <seealso cref="number" /> and the
        ///     <seealso cref="ISquare" />s it contains.
        /// </summary>
        /// <param name="board">The <seealso cref="IBoard" /> to which this <seealso cref="Rank" /> belongs.</param>
        /// <param name="number">The number of this <seealso cref="Rank" />.</param>
        /// <param name="squares">The <seealso cref="ISquare" />s that make up this <seealso cref="Rank" />.</param>
        public Rank(IBoard board, byte number, IEnumerable<ISquare> squares)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board), "A rank cannot be created without a board reference");
            if (number < 1 || number > 8)
                throw new ArgumentOutOfRangeException();
            if (squares == null)
                throw new ArgumentNullException(nameof(squares), "A rank cannot be created without squares");
            var list = squares as List<ISquare> ?? squares.ToList();
            if (!list.Any())
                throw new ArgumentNullException(nameof(squares), "A rank cannot be created without squares");
            if (list.Count != 8)
                throw new ArgumentException("A rank can only be created with 8 squares", nameof(squares));

            Board = board;
            Number = number;
            Squares = list.AsReadOnly();
        }

        /// <summary>
        ///     The number of this <seealso cref="IRank" />.
        /// </summary>
        public byte Number { get; }

        /// <summary>
        ///     The <seealso cref="IBoard" /> to which this <seealso cref="IRank" /> belongs.
        /// </summary>
        public IBoard Board { get; }

        /// <summary>
        ///     The <seealso cref="ISquare" />s that make up this <seealso cref="IRank" />.
        /// </summary>
        public IReadOnlyCollection<ISquare> Squares { get; }

        /// <summary>
        ///     Returns a string that represents the current <seealso cref="Rank" />. This is usually the <seealso cref="Number" />
        ///     of the <seealso cref="Rank" />.
        /// </summary>
        /// <returns>The <seealso cref="Number" /> of the <seealso cref="Rank" /> as a <seealso cref="string" />.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return Number.ToString();
        }
    }
}