using System.Collections.Generic;

namespace CAESAR.Chess
{
    public interface IFile : IReadOnlyCollection<ISquare>
    {
        char Name { get; }
        IBoard Board { get; }
    }
}