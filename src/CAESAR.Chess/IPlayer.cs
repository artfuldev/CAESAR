using CAESAR.Chess.Moves;
using CAESAR.Chess.Pieces;

namespace CAESAR.Chess
{
    public interface IPlayer
    {
        bool IsWhite { get; }
        bool IsBlack { get; }
        void Place(IBoard board, IPiece piece, string squareName);
        void Place(ISquare square, IPiece piece);
        void MakeMove(IMove move);
        void UnMakeMove(IMove move);
    }
}