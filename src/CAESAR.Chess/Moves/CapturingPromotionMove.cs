using CAESAR.Chess.Core;

namespace CAESAR.Chess.Moves
{
    public class CapturingPromotionMove:PromotionMove
    {
        public CapturingPromotionMove(Side side, string sourceSquareName, string destinationSquareName,
            char promotionPieceNotation) : base(side, sourceSquareName, destinationSquareName, promotionPieceNotation)
        {
        }
    }
}