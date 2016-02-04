using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Moves
{
    public class PromotionMove : NormalMove
    {
        public PieceType PromotionPieceType { get; }

        public PromotionMove(ISquare source, string destinationSquareName, PieceType promotionPieceType)
            : base(source, destinationSquareName)
        {
            PromotionPieceType = promotionPieceType;
            MoveString = SourceSquareName + DestinationSquareName + PromotionPieceType.GetNotation();
        }

        protected override IPosition MakeImplementation(IPosition position)
        {
            position = base.MakeImplementation(position);
            var destinationSquare = position.Board.GetSquare(DestinationSquareName);
            destinationSquare.Piece = PromotionPieceType.GetPiece(Side);
            return position;
        }
    }
}