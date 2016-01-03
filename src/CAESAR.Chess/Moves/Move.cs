using System.Linq;
using CAESAR.Chess.Pieces;

namespace CAESAR.Chess.Moves
{
    public class Move : IMove
    {
        public Move(IPiece piece, ISquare destination, MoveType moveType = MoveType.Normal, IPiece promotionPiece = null)
        {
            Piece = piece;
            Destination = destination;
            MoveType = moveType;
            Source = piece.Square;
            IsWhite = Piece.IsWhite;
            if (moveType == MoveType.Promotion)
                PromotionPiece = promotionPiece;
            if (moveType == MoveType.Capture)
                CapturedPiece = Destination.Piece;
        }

        public ISquare Source { get; }
        public ISquare Destination { get; }
        public IPiece Piece { get; }
        public bool IsWhite { get; }
        public bool IsBlack => !IsWhite;
        public MoveType MoveType { get; }
        public IPiece PromotionPiece { get; }
        public IPiece CapturedPiece { get; }

        public override string ToString()
        {
            return Piece.Notation + (MoveType == MoveType.Capture ? "x" : "") + Destination.Name +
                   (MoveType == MoveType.Promotion
                       ? "=" + PromotionPiece.Notation.ToString().ToUpperInvariant().ToCharArray().First()
                       : "");
        }
    }
}