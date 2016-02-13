using System.Linq;
using CAESAR.Chess.Pieces;

namespace CAESAR.Chess.Moves.Notations
{
    /// <summary>
    ///     Short Algebraic Notation (SAN)
    ///     <para>
    ///         SAN is the official notation of the FIDE which must be used in all recognized international competition
    ///         involving human players. Concerning computer chess, SAN is a representation standard for chess moves inside the
    ///         Portable Game Notation standard using the ASCII Latin alphabet, and should be supported as default notation by
    ///         all modern chess programs and their user interfaces.
    ///     </para>
    /// </summary>
    /// <remarks>https://chessprogramming.wikispaces.com/Algebraic+Chess+Notation#Long%20Algebraic%20Notation%20(LAN)</remarks>
    public class ShortAlgebraicNotation : INotation
    {
        /// <summary>
        ///     Gets the string representation of the <seealso cref="IMove" /> in <seealso cref="ShortAlgebraicNotation" />.
        /// </summary>
        /// <param name="move">The <seealso cref="IMove" /> for which the notation is required.</param>
        /// <returns>The string representation of the <seealso cref="IMove" /> in <seealso cref="ShortAlgebraicNotation" />.</returns>
        public string ToString(IMove move)
        {
            var normalMove = move as NormalMove;
            if (normalMove == null)
                return null;
            var promotionMove = move as PromotionMove;
            var isCapturingMove = move is CapturingMove || move is CapturingPromotionMove;
            var promotionSuffix = promotionMove != null ? "=" + promotionMove.PromotionPieceType.GetNotation() : "";
            return GetNotation(normalMove.Piece) + GetSpecifier(move) + (isCapturingMove ? "x" : "") +
                   normalMove.DestinationSquareName + promotionSuffix;
        }

        /// <summary>
        ///     Gets the notation of the <seealso cref="IPiece" /> as required by <seealso cref="ShortAlgebraicNotation" />.
        /// </summary>
        /// <param name="piece">The <seealso cref="IPiece" /> for which the notation is required.</param>
        /// <returns>The notation of the <seealso cref="IPiece" /> as required by <seealso cref="ShortAlgebraicNotation" />.</returns>
        private static string GetNotation(IPiece piece)
        {
            var pieceType = piece.PieceType;
            switch (pieceType)
            {
                case PieceType.Pawn:
                    return "";
                default:
                    return pieceType.GetNotation().ToString();
            }
        }

        /// <summary>
        ///     Gets the specifier for an <seealso cref="IMove" />, used to disambiguate between pieces involved.
        /// </summary>
        /// <param name="move">The <seealso cref="IMove" /> for which the specifier is required.</param>
        /// <returns>The specifier for the <seealso cref="move" />, used to disambiguate between pieces involved.</returns>
        private static string GetSpecifier(IMove move)
        {
            var normalMove = move as NormalMove;
            if (normalMove == null)
                return null;

            var source = normalMove.Source;
            var piece = normalMove.Piece;
            var pieceType = piece.PieceType;

            var isCapture = move is CapturingMove || move is CapturingPromotionMove;

            // If pawn captures, return file name
            if (isCapture && pieceType == PieceType.Pawn)
                return source.Name[0].ToString();

            // If there are two pieces on the board which can move to the same destination square, use a specifier
            var similarPieces =
                source.Board.Squares.Where(
                    x => x.HasPiece && x.Piece.Side == piece.Side && x.Piece.PieceType == pieceType && x.Piece != source.Piece)
                    .Select(x => x.Piece);
            var similarPiecesWhichCanMoveToSameDestination =
                similarPieces.Where(
                    x => x.Moves.Any(m => (m as NormalMove)?.DestinationSquareName == normalMove.DestinationSquareName))
                    .ToList();
            if (similarPiecesWhichCanMoveToSameDestination.Count > 0)
            {
                return similarPiecesWhichCanMoveToSameDestination.Count > 1
                    ? source.Name
                    : (similarPiecesWhichCanMoveToSameDestination[0].Square.File.Name != source.File.Name
                        ? source.File.Name.ToString()
                        : source.Rank.Number.ToString());
            }
            return null;
        }
    }
}