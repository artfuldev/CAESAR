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
        public string ToString(IMove move)
        {
            return GetNotation(move.Source.Piece) + move.Source.Name +
                   (move.CapturedPiece != null ? "x" : "-") + move.Destination.Name +
                   (move.PromotionPiece != null ? move.PromotionPiece.Notation.ToString().ToUpperInvariant() : "");
        }

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