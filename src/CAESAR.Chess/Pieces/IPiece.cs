using System.Collections.Generic;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Pieces
{
    public interface IPiece
    {
        Side Side { get; }
        ISquare Square { get; set; }
        IEnumerable<IMove> Moves { get; }
        string Name { get; }
        char Notation { get; }
        PieceType PieceType { get; }
    }
}