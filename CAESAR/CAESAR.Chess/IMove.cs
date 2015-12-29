using CAESAR.Chess.Pieces;

namespace CAESAR.Chess
{
    public interface IMove
    {
        ISquare Source { get; }
        ISquare Destination { get; }
        IPiece Piece { get; }
        IPlayer Player { get; }
        bool IsWhite { get; }
        bool IsBlack { get; }
        MoveType MoveType { get; }
        IPiece PromotionPiece { get; }
    }
}