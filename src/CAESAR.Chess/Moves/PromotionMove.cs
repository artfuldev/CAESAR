using CAESAR.Chess.Core;

namespace CAESAR.Chess.Moves
{
    public class PromotionMove : NormalMove
    {
        public char PromotionPieceNotation { get; }

        public PromotionMove(Side side, string sourceSquareName, string destinationSquareName,
            char promotionPieceNotation) : base(side, sourceSquareName, destinationSquareName + promotionPieceNotation)
        {
            PromotionPieceNotation = promotionPieceNotation;
        }
    }
}