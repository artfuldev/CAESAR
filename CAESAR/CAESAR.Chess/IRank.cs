using System.Collections.Generic;

namespace CAESAR.Chess
{
    public interface IRank : IReadOnlyCollection<ISquare>
    {
        byte Number { get; }
        IBoard Board { get; }
    }
}