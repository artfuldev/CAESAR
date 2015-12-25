using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
                squares[i] = new Square(this, i%2 != 0);
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
            return Squares.FirstOrDefault(x => x.Name == squareName);
        }

        public ISquare GetSquare(IFile file, IRank rank)
        {
            return file.FirstOrDefault(rank.Contains);
        }

        public ISquare GetSquare(char fileName, byte rankNumber)
        {
            return GetSquare(GetFile(fileName), GetRank(rankNumber));
        }

        public IFile GetFile(char fileName)
        {
            return Files.FirstOrDefault(x => x.Name == fileName);
        }
        public IRank GetRank(byte rankNumber)
        {
            return Ranks.FirstOrDefault(x => x.Number == rankNumber);
        }
    }
}