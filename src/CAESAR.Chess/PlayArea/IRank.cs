using System.Collections.Generic;

namespace CAESAR.Chess.PlayArea
{
    public interface IRank
    {
        byte Number { get; }
        IBoard Board { get; }
        IReadOnlyCollection<ISquare> Squares { get; }
    }
}