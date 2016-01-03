using System.Collections.Generic;
using CAESAR.Chess.Moves;

namespace CAESAR.Chess.Pieces
{
    public interface IPiece
    {
        bool IsWhite { get; }
        bool IsBlack { get; }
        ISquare Square { get; set; }
        IEnumerable<IMove> Moves { get; }
        string Name { get; }
        char Notation { get; }
    }
}