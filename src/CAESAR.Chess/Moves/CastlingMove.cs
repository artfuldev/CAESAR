using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Moves
{
    /// <summary>
    ///     A special <seealso cref="NormalMove" /> of the <seealso cref="King" /> where the king and rook move together.
    ///     Castling consists of moving the king two squares towards a rook on the player's first rank, then moving the rook to
    ///     the square over which the king crossed.
    ///     <para>
    ///         Castling may only be done if the king has never moved, the rook involved has never moved, the squares between
    ///         the king and the rook involved are unoccupied, the king is not in check, and the king does not cross over or
    ///         end on a square in which it would be in check. Castling is one of the rules of chess and is technically a king
    ///         move.
    ///     </para>
    /// </summary>
    public class CastlingMove : NormalMove
    {
        /// <summary>
        ///     Instantiates a <seealso cref="CastlingMove" /> from a source <seealso cref="ISquare" /> and a
        ///     <seealso cref="CastleSide" />.
        /// </summary>
        /// <param name="source">The <seealso cref="ISquare" /> in which the move originates.</param>
        /// <param name="castleSide">The <seealso cref="CastleSide" /> on which the castling is performed.</param>
        public CastlingMove(ISquare source, CastleSide castleSide)
            : base(source, GetDestinationSquareName(source.Piece.Side, castleSide))
        {
        }

        /// <summary>
        ///     Gets the destination square name based on the <seealso cref="Side" /> and the <seealso cref="CastleSide" />.
        /// </summary>
        /// <param name="side">The <seealso cref="Side" /> that this <seealso cref="CastlingMove" /> is for.</param>
        /// <param name="castleSide">The <seealso cref="CastleSide" /> on which the castling is to be performed.</param>
        /// <returns></returns>
        private static string GetDestinationSquareName(Side side, CastleSide castleSide)
        {
            var rankNumber = side == Side.White ? 1 : 8;
            var fileName = castleSide == CastleSide.King ? "g" : "c";
            return fileName + rankNumber;
        }
    }

    /// <summary>
    ///     The side on which the castling can be performed.
    /// </summary>
    public enum CastleSide
    {
        /// <summary>
        ///     The king side.
        /// </summary>
        King,

        /// <summary>
        ///     The Queen side.
        /// </summary>
        Queen
    }
}