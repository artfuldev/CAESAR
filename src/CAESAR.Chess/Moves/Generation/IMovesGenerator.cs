using System.Collections.Generic;
using CAESAR.Chess.Pieces;

namespace CAESAR.Chess.Moves.Generation
{
    public interface IMovesGenerator
    {
        IEnumerable<IMove> Moves { get; }
        ISquare Square { set; }
    }
}