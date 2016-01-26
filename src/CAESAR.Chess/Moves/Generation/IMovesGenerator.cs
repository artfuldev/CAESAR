using System.Collections.Generic;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Moves.Generation
{
    public interface IMovesGenerator
    {
        IEnumerable<IMove> Moves { get; }
        ISquare Square { set; }
    }
}