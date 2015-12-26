using System.Collections.Generic;

namespace CAESAR.Chess
{
    public interface IFile
    {
        char Name { get; }
        IBoard Board { get; }
        IReadOnlyCollection<ISquare> Squares { get; }
    }
}