using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;

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

        protected override IBoard MakeImplementation(IBoard board)
        {
            // Make normal move
            board = base.MakeImplementation(board);
            var destinationSquare = board.GetSquare(DestinationSquareName);
            destinationSquare.Piece = PromotionPieceType.GetPiece(Side);
            return board;
        }
    }
}