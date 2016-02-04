using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.PlayArea
{
    public class Board : IBoard
    {
        private const byte RankCount = 8;
        private const byte FileCount = 8;
        private const byte SquareCount = 64;

        public Board(IPosition position)
        {
            Position = position;
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
                    var squareIndex = i*RankCount + j;
                    var square = new Square(this, files[j], ranks[i],
                        files[j].Name + ranks[i].Number.ToString(), (i + j)%2 != 0);

                    squares[squareIndex] = square;
                    rankSquares[i][j] = square;
                    fileSquares[j][i] = square;
                }

            Squares = squares.ToList().AsReadOnly();
            Ranks = ranks.ToList().AsReadOnly();
            Files = files.ToList().AsReadOnly();
        }

        public IPosition Position { get; }
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

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var rank in Ranks.Reverse())
            {
                stringBuilder.AppendLine("________________________________");
                stringBuilder.AppendLine(rank.Squares.Aggregate("",
                    (current, square) => current + ("| " + (square.Piece?.Notation ?? ' ')) + " ") + "| " + rank.Number);
            }
            stringBuilder.AppendLine("________________________________");
            stringBuilder.Append("  a   b   c   d   e   f   g   h");
            return stringBuilder.ToString();
        }

        public object Clone()
        {
            var returnable = new Board(Position);
            for (var i = 0; i < Squares.Count; i++)
                returnable.Squares.ElementAt(i).Piece = Squares.ElementAt(i).IsEmpty
                    ? null
                    : (IPiece) Squares.ElementAt(i).Piece.Clone();
            return returnable;
        }
    }
}