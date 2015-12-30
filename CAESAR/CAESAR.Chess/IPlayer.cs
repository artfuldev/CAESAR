using CAESAR.Chess.Pieces;

namespace CAESAR.Chess
{
    public interface IPlayer
    {
        bool IsWhite { get; }
        bool IsBlack { get; }
        void Place(IBoard board, IPiece piece, string squareName);
        IBoard MakeMove(IMove move, IBoard board);
        IBoard UnMakeMove(IMove move, IBoard board);
    }
}