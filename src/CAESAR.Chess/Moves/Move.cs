using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;

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
            Side = piece.Side;
            if (moveType == MoveType.Promotion)
                PromotionPiece = promotionPiece;
            if (moveType == MoveType.Capture)
                CapturedPiece = Destination.Piece;
        }

        public ISquare Source { get; }
        public ISquare Destination { get; }
        public IPiece Piece { get; }
        public Side Side { get; }
        public MoveType MoveType { get; }
        public IPiece PromotionPiece { get; }
        public IPiece CapturedPiece { get; }

        public override string ToString()
        {
            // Long e2e4, e7e8Q
            return Source.Name + Destination.Name +
                   (MoveType == MoveType.Promotion
                       ? PromotionPiece.Notation.ToString().ToUpperInvariant().ToCharArray().First().ToString()
                       : "");
        }
    }
}