using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Moves
{
    public class CapturingPromotionMove:PromotionMove
    {
        public CapturingPromotionMove(ISquare source, string destinationSquareName,
            PieceType promotionPieceType) : base(source, destinationSquareName, promotionPieceType)
        {
        }
    }
}