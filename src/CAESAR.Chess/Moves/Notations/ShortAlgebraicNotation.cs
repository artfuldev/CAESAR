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
        public string ToString(IMove move)
        {
            var piece = move.Source.Piece;
            return GetNotation(piece) + GetSpecifier(move) +
                   (move.CapturedPiece != null ? "x" : "") + move.Destination.Name +
                   (move.PromotionPiece != null ? move.PromotionPiece.Notation.ToString().ToUpperInvariant() : "");
        }

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

        private static string GetSpecifier(IMove move)
        {
            var source = move.Source;
            var piece = source.Piece;
            var pieceType = piece.PieceType;

            // If pawn captures, return file name
            if (move.CapturedPiece != null && pieceType == PieceType.Pawn)
                return source.Name[0].ToString();

            // If there are two pieces on the board which can move to the same destination square, use a specifier
            var similarPieces =
                source.Board.Squares.Where(
                    x => x.HasPiece && x.Piece.Side == piece.Side && x.Piece.PieceType == pieceType)
                    .Select(x => x.Piece);
            var similarPiecesWhichCanMoveToSameDestination =
                similarPieces.Where(x => x.Moves.Any(m => m.Destination.Name == move.Destination.Name)).ToList();
            if (similarPiecesWhichCanMoveToSameDestination.Count > 0)
            {
                return similarPiecesWhichCanMoveToSameDestination.Count > 1
                    ? source.Name
                    : (similarPiecesWhichCanMoveToSameDestination[0].Square.File.Name != source.File.Name
                        ? source.File.Name.ToString()
                        : source.Rank.Number.ToString());
            }
            return "";
        }
    }
}