using CAESAR.Chess.Pieces;

namespace CAESAR.Chess.Moves.Notations
{
    public class LongAlgebraicNotation : INotation
    {
        public string ToString(IMove move)
        {
            var piece = move.Source.Piece;
            return (piece is Pawn ? "" : piece.Notation.ToString().ToUpperInvariant()) + move.Source.Name +
                   (move.MoveType == MoveType.Capture ? "x" : "-") + move.Destination.Name +
                   (move.MoveType == MoveType.Promotion
                       ? move.PromotionPiece.Notation.ToString().ToUpperInvariant()
                       : "");
        }
    }
}