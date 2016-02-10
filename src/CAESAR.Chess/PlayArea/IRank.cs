using System.Collections.Generic;

namespace CAESAR.Chess.PlayArea
{
    /// <summary>
    ///     Represents a rank on the <seealso cref="IBoard" />. It's a numbered row on the chessboard.
    /// </summary>
    public interface IRank
    {
        /// <summary>
        ///     The number of this <seealso cref="IRank" />.
        /// </summary>
        byte Number { get; }

        /// <summary>
        ///     The <seealso cref="IBoard" /> to which this <seealso cref="IRank" /> belongs.
        /// </summary>
        IBoard Board { get; }

        /// <summary>
        ///     The <seealso cref="ISquare" />s that make up this <seealso cref="IRank" />.
        /// </summary>
        IReadOnlyCollection<ISquare> Squares { get; }
    }
}