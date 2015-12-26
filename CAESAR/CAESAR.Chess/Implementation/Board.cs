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
            var fileSquares = new List<ISquare>[FileCount];
            var files = new IFile[FileCount];
            for (var i = 0; i < FileCount; i++)
            {
                fileSquares[i] = new ISquare[8].ToList();
                files[i] = new File(this, (char) (97 + i), fileSquares[i]);
            }

            var rankSquares = new List<ISquare>[RankCount];
            var ranks = new IRank[RankCount];
            for (var i = 0; i < RankCount; i++)
            {
                rankSquares[i] = new ISquare[8].ToList();
                ranks[i] = new Rank(this, (byte) (i + 1), rankSquares[i]);
            }

            var squares = new ISquare[SquareCount];
            for (var i = 0; i < RankCount; i++)
                for (var j = 0; j < FileCount; j++)
                {
                    var squareIndex = (i * RankCount) + j;
                    var square = new Square(this, files[j], ranks[i],
                        files[j].Name.ToString() + ranks[i].Number.ToString(), squareIndex % 2 != 0);

                    squares[squareIndex] = square;
                    rankSquares[i][j] = square;
                    fileSquares[j][i] = square;
                }

            Squares = squares.ToList().AsReadOnly();
            Ranks = ranks.ToList().AsReadOnly();
            Files = files.ToList().AsReadOnly();
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
            return file.Squares.FirstOrDefault(rank.Squares.Contains);
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