using CAESAR.Chess.Pieces;
using System.Linq;

namespace CAESAR.Chess.Implementation
{
    public class Move : IMove
    {
        public Move(IPiece piece, ISquare destination, MoveType moveType = MoveType.Normal, IPiece promotionPiece = null)
        {
            Piece = piece;
            Destination = destination;
            MoveType = moveType;
            PromotionPiece = promotionPiece;
            Source = piece.Square;
            IsWhite = Piece.IsWhite;
        }

        public ISquare Source { get; }
        public ISquare Destination { get; }
        public IPiece Piece { get; }
        public bool IsWhite { get; }
        public bool IsBlack => !IsWhite;
        public MoveType MoveType { get; }
        public IPiece PromotionPiece { get; }

        public override string ToString()
        {
            return Piece.Notation + Destination.Name +
                   (PromotionPiece != null
                       ? "=" + PromotionPiece.Notation.ToString().ToUpperInvariant().ToCharArray().First()
                       : "");
        }
    }
}