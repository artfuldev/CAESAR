using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CAESAR.Chess.Implementation
{
    public class Board : IBoard
    {
        private const byte RankCount = 8;
        private const byte FileCount = 8;
        private const byte SquareCount = 64;

        public Board()
        {
            var squares = new ISquare[SquareCount];
            for (var i = 0; i < SquareCount; i++)
                squares[i] = new Square(this, i%2 == 0);
            Squares = squares;

            var ranks = new IRank[RankCount];
            for (var i = 0; i < RankCount; i++)
                ranks[i] = new Rank(this, (byte) (i + 1));
            Ranks = ranks;

            var files = new IFile[FileCount];
            for (var i = 0; i < FileCount; i++)
                files[i] = new File(this, (char)(97 + i));
            Files = files;

        }
        public IReadOnlyCollection<IFile> Files { get; }
        public IReadOnlyCollection<IRank> Ranks { get; }
        public IReadOnlyCollection<ISquare> Squares { get; }
        public ISquare GetSquare(string squareName)
        {
            throw new System.NotImplementedException();
        }

        public ISquare GetSquare(IFile file, IRank rank)
        {
            throw new System.NotImplementedException();
        }

        public ISquare GetSquare(string fileName, string rankNumber)
        {
            throw new System.NotImplementedException();
        }

        public ISquare GetSquare(char fileName, byte rankNumber)
        {
            throw new System.NotImplementedException();
        }

        public ISquare GetSquare(byte fileIndex, byte rankIndex)
        {
            throw new System.NotImplementedException();
        }

        public IFile GetFile(char fileName)
        {
            throw new System.NotImplementedException();
        }

        public IFile GetFile(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public IFile GetFileByIndex(byte fileIndex)
        {
            throw new System.NotImplementedException();
        }

        public IRank GetRank(byte rankNumber)
        {
            throw new System.NotImplementedException();
        }

        public IRank GetRank(string rankNumber)
        {
            throw new System.NotImplementedException();
        }

        public IRank GetRankByIndex(byte rankIndex)
        {
            throw new System.NotImplementedException();
        }
    }
}