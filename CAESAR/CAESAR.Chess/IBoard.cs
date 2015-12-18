using System.Collections.Generic;

namespace CAESAR.Chess
{
    public interface IBoard
    { 
        IReadOnlyCollection<IFile> Files { get; }
        IReadOnlyCollection<IRank> Ranks { get; }
        IReadOnlyCollection<ISquare> Squares { get; }
        ISquare GetSquare(string squareName);
        ISquare GetSquare(IFile file, IRank rank);
        ISquare GetSquare(string fileName, string rankNumber);
        ISquare GetSquare(char fileName, byte rankNumber);
        ISquare GetSquare(byte fileIndex, byte rankIndex);
        IFile GetFile(char fileName);
        IFile GetFile(string fileName);
        IFile GetFileByIndex(byte fileIndex);
        IRank GetRank(byte rankNumber);
        IRank GetRank(string rankNumber);
        IRank GetRankByIndex(byte rankIndex);
    }
}