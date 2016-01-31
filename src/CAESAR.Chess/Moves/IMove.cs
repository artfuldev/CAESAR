using CAESAR.Chess.Core;
using CAESAR.Chess.Moves.Notations;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Moves
{
    public interface IMove
    {
        ISquare Source { get; }
        ISquare Destination { get; }
        IPiece Piece { get; }
        Side Side { get; }
        MoveType MoveType { get; }
        IPiece PromotionPiece { get; }
        IPiece CapturedPiece { get; }
        string ToString(INotation notation);
    }
}