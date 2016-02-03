using System.Collections.Generic;
using CAESAR.Chess.Core;

namespace CAESAR.Chess.PlayArea
{
    public interface IBoard : ICloneable
    {
        IReadOnlyCollection<IFile> Files { get; }
        IReadOnlyCollection<IRank> Ranks { get; }
        IReadOnlyCollection<ISquare> Squares { get; }
        ISquare GetSquare(string squareName);
        ISquare GetSquare(IFile file, IRank rank);
        ISquare GetSquare(char fileName, byte rankNumber);
        IFile GetFile(char fileName);
        IRank GetRank(byte rankNumber);
    }
}