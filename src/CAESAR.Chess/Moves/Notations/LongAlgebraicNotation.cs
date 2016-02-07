using CAESAR.Chess.Pieces;

namespace CAESAR.Chess.Moves.Notations
{
    /// <summary>
    ///     Long Algebraic Notation (LAN)
    ///     <para>
    ///         Beside the already sufficient and unambiguous pure origin- and target-coordinates, LAN uses a leading
    ///         redundant, national dependent uppercase piece letter or figurine piece symbol of the moving piece usually other
    ///         than a pawn, to represent the move, which makes it more human readable and compatible with SAN and desciptive
    ///         notation. However, for chess programs using pure from-to move encoding, converting the move list to LAN already
    ///         requires a board representation in sync with the leading moves already played, to lookup the piece on the
    ///         board.
    ///     </para>
    /// </summary>
    /// <remarks>https://chessprogramming.wikispaces.com/Algebraic+Chess+Notation#Long%20Algebraic%20Notation%20(LAN)</remarks>
    public class LongAlgebraicNotation : INotation
    {
        /// <summary>
        ///     Gets the string representation of the <seealso cref="IMove" /> in <seealso cref="LongAlgebraicNotation" />.
        /// </summary>
        /// <param name="move">The <seealso cref="IMove" /> for which the notation is required.</param>
        /// <returns>The string representation of the <seealso cref="IMove" /> in <seealso cref="LongAlgebraicNotation" />.</returns>
        public string ToString(IMove move)
        {
            var normalMove = move as NormalMove;
            if (normalMove == null)
                return null;
            var isCapturingMove = move is CapturingMove || move is CapturingPromotionMove;
            var promotionMove = move as PromotionMove;
            return GetNotation(normalMove.Piece) + normalMove.SourceSquareName +
                   (isCapturingMove ? "x" : "-") + normalMove.DestinationSquareName +
                   promotionMove?.PromotionPieceType.GetNotation();
        }

        /// <summary>
        ///     Gets the notation of the <seealso cref="IPiece" /> required for <seealso cref="LongAlgebraicNotation" />.
        /// </summary>
        /// <param name="piece">The <seealso cref="IPiece" /> for which the notation is required.</param>
        /// <returns>The notation of the <seealso cref="IPiece" /> required for <seealso cref="LongAlgebraicNotation" />.</returns>
        private static string GetNotation(IPiece piece)
        {
            var pieceType = piece.PieceType;
            switch (pieceType)
            {
                case PieceType.Pawn:
                    return null;
                default:
                    return pieceType.GetNotation().ToString();
            }
        }
    }
}