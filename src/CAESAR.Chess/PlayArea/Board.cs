using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.PlayArea
{
    /// <summary>
    ///     Represents a chessboard belonging to an <seealso cref="IPosition" />. It is made up of <seealso cref="IFile" />s,
    ///     <seealso cref="IRank" />s, all made up of <seealso cref="ISquare" />s. It is also an <seealso cref="ICloneable" />.
    /// </summary>
    public class Board : IBoard
    {
        /// <summary>
        ///     The number of <seealso cref="IRank" />s on this <seealso cref="Board" />.
        /// </summary>
        private const byte RankCount = 8;

        /// <summary>
        ///     The number of <seealso cref="IFile" />s on this <seealso cref="Board" />.
        /// </summary>
        private const byte FileCount = 8;

        /// <summary>
        ///     The number of <seealso cref="ISquare" />s on this <seealso cref="Board" />.
        /// </summary>
        private const byte SquareCount = 64;

        /// <summary>
        ///     Instantiates a <seealso cref="Board" /> that belongs to a particular <seealso cref="IPosition" />.
        /// </summary>
        /// <param name="position">The <seealso cref="IPosition" /> to which this <seealso cref="IBoard" /> belongs.</param>
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

        /// <summary>
        ///     The <seealso cref="IPosition" /> to which this <seealso cref="Board" /> belongs.
        /// </summary>
        public IPosition Position { get; }

        /// <summary>
        ///     The <seealso cref="IFile" />s that this <seealso cref="Board" /> contains.
        /// </summary>
        public IReadOnlyCollection<IFile> Files { get; }

        /// <summary>
        ///     The <seealso cref="IRank" />s that this <seealso cref="Board" /> contains.
        /// </summary>
        public IReadOnlyCollection<IRank> Ranks { get; }

        /// <summary>
        ///     The <seealso cref="ISquare" />s that this <seealso cref="Board" /> contains.
        /// </summary>
        public IReadOnlyCollection<ISquare> Squares { get; }

        /// <summary>
        ///     Gets the <seealso cref="ISquare" /> of the specified <seealso cref="squareName" /> that belongs to this
        ///     <seealso cref="Board" />.
        /// </summary>
        /// <param name="squareName">The name of the <seealso cref="ISquare" /> belonging to this <seealso cref="Board" />.</param>
        /// <returns>
        ///     The <seealso cref="ISquare" /> of the specified <seealso cref="squareName" /> that belongs to this
        ///     <seealso cref="Board" />.
        /// </returns>
        public ISquare GetSquare(string squareName)
        {
            return Squares.FirstOrDefault(x => x.Name == squareName);
        }

        /// <summary>
        ///     Gets the <seealso cref="ISquare" /> that belongs to the specified <seealso cref="IFile" /> and
        ///     <seealso cref="IRank" />.
        /// </summary>
        /// <param name="file">The <seealso cref="IFile" /> to which the <seealso cref="ISquare" /> belongs.</param>
        /// <param name="rank">The <seealso cref="IRank" /> to which the <seealso cref="ISquare" /> belongs.</param>
        /// <returns>
        ///     The <seealso cref="ISquare" /> that belongs to the specified <seealso cref="IFile" /> and
        ///     <seealso cref="IRank" />.
        /// </returns>
        public ISquare GetSquare(IFile file, IRank rank)
        {
            return file.Squares.FirstOrDefault(rank.Squares.Contains);
        }

        /// <summary>
        ///     Gets the <seealso cref="IFile" /> of the specified <seealso cref="fileName" /> that belongs to this
        ///     <seealso cref="Board" />.
        /// </summary>
        /// <param name="fileName">The name of the <seealso cref="IFile" /> belonging to this <seealso cref="Board" />.</param>
        /// <returns>
        ///     The <seealso cref="IFile" /> of the specified <seealso cref="fileName" /> that belongs to this
        ///     <seealso cref="Board" />.
        /// </returns>
        public IFile GetFile(char fileName)
        {
            return Files.FirstOrDefault(x => x.Name == fileName);
        }

        /// <summary>
        ///     Gets the <seealso cref="IRank" /> of the specified <seealso cref="rankNumber" /> that belongs to this
        ///     <seealso cref="Board" />.
        /// </summary>
        /// <param name="rankNumber">The name of the <seealso cref="IRank" /> belonging to this <seealso cref="Board" />.</param>
        /// <returns>
        ///     The <seealso cref="IRank" /> of the specified <seealso cref="rankNumber" /> that belongs to this
        ///     <seealso cref="Board" />.
        /// </returns>
        public IRank GetRank(byte rankNumber)
        {
            return Ranks.FirstOrDefault(x => x.Number == rankNumber);
        }

        /// <summary>
        ///     Return a clone of the current <seealso cref="Board" />
        /// </summary>
        /// <returns>A <seealso cref="Board" /> that is the clone of the current <seealso cref="Board" />.</returns>
        public object Clone()
        {
            var returnable = new Board(Position);
            for (var i = 0; i < Squares.Count; i++)
                returnable.Squares.ElementAt(i).Piece = Squares.ElementAt(i).IsEmpty
                    ? null
                    : (IPiece) Squares.ElementAt(i).Piece.Clone();
            return returnable;
        }

        /// <summary>
        ///     Returns a string that represents the current <seealso cref="Board" />.
        /// </summary>
        /// <returns>A string that represents the current <seealso cref="Board" />.</returns>
        /// <filterpriority>2</filterpriority>
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
    }
}