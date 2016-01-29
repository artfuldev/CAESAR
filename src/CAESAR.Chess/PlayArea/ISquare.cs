using CAESAR.Chess.Pieces;

namespace CAESAR.Chess.PlayArea
{
    public interface ISquare
    {
        IFile File { get; }
        IRank Rank { get; }
        string Name { get; }
        bool IsLight { get; }
        bool IsDark { get; }
        IBoard Board { get; }
        IPiece Piece { get; set; }
        bool IsEmpty { get; }
        bool HasPiece { get; }
    }
}