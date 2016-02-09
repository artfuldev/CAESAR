using CAESAR.Chess.Core;
using CAESAR.Chess.Games;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Moves.Generation;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Pieces
{
    /// <summary>
    ///     Represents a king in the <seealso cref="IGame" />. It belongs to a <seealso cref="Side" />, occupies an
    ///     <seealso cref="ISquare" />, and can have <seealso cref="IMove" />s available.
    /// </summary>
    public class King : Piece
    {
        /// <summary>
        ///     Instantiates a <seealso cref="King" /> of a particular <seealso cref="Side" />.
        /// </summary>
        /// <param name="side">The <seealso cref="Side" /> to which this <seealso cref="King" /> belongs.</param>
        public King(Side side) : base(side, PieceType.King, new KingMovesGenerator())
        {
        }
    }
}