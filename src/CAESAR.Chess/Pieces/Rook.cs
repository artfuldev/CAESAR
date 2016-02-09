using CAESAR.Chess.Core;
using CAESAR.Chess.Games;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Moves.Generation;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Pieces
{
    /// <summary>
    ///     Represents a rook in the <seealso cref="IGame" />. It belongs to a <seealso cref="Side" />, occupies an
    ///     <seealso cref="ISquare" />, and can have <seealso cref="IMove" />s available.
    /// </summary>
    public class Rook : Piece
    {
        /// <summary>
        ///     Instantiates a <seealso cref="Rook" /> of a particular <seealso cref="Side" />.
        /// </summary>
        /// <param name="side">The <seealso cref="Side" /> to which this <seealso cref="Rook" /> belongs.</param>
        public Rook(Side side) : base(side, PieceType.Rook, new RookMovesGenerator())
        {
        }
    }
}