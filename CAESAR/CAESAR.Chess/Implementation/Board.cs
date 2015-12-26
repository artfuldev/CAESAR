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
            var files = new IFile[FileCount];
            for (var i = 0; i < FileCount; i++)
                files[i] = new File(this, (char)(97 + i));

            var ranks = new IRank[RankCount];
            for (var i = 0; i < RankCount; i++)
                ranks[i] = new Rank(this, (byte)(i + 1), new ISquare[8]);

            var squares = new ISquare[SquareCount];
            for (var i = 0; i < RankCount; i++)
                for (var j = 0; j < FileCount; j++)
                {
                    // Initialize Square
                    squares[(i * RankCount) + j] = new Square(this, files[j], ranks[i],
                        files[j].Name.ToString() + ranks[i].Number.ToString(), ((i * RankCount) + j) % 2 != 0);

                    // Add square to Rank
                    var rankSquares = ranks[i].Squares as List<ISquare>;
                    rankSquares[j] = squares[(i * RankCount) + j];
                }

            Squares = squares;
            Ranks = ranks;
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
            return file.FirstOrDefault(rank.Squares.Contains);
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