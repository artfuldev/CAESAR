using System.Collections.Generic;

namespace CAESAR.Chess.PlayArea
{
    public interface IFile
    {
        char Name { get; }
        IBoard Board { get; }
        IReadOnlyCollection<ISquare> Squares { get; }
    }
}