using System.Collections.Generic;

namespace CAESAR.Chess
{
    public interface IDiagonal
    {
        ISquare[] Squares { get; }  
        string Name { get; }
        IBoard Board { get; }
    }
}