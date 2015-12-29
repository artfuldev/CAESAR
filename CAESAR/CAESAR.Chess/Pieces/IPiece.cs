using System.Collections.Generic;

namespace CAESAR.Chess.Pieces
{
    public interface IPiece
    {
        bool IsWhite { get; }
        bool IsBlack { get; }
        ISquare Square { get; }
        IEnumerable<IMove> GetMoves();
        string Name { get; }
        char Notation { get; }
    }
}