using System;
using System.Linq;
using System.Text;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Positions;
using Xunit;

namespace CAESAR.Chess.Tests.PlayArea
{
    public class BoardTests
    {
        private readonly IBoard _board;

        public BoardTests() : this(Position.EmptyPosition.Board)
        {
        }

        // Injection Constructor
        private BoardTests(IBoard board)
        {
            _board = board;
        }


        [Fact]
        public void TotalNumberOfFilesInBoardIs8()
        {
            Assert.True(_board.Files.Count == 8);
        }

        [Theory]
        [InlineData(1, 'a')]
        [InlineData(2, 'b')]
        [InlineData(3, 'c')]
        [InlineData(4, 'd')]
        [InlineData(5, 'e')]
        [InlineData(6, 'f')]
        [InlineData(7, 'g')]
        [InlineData(8, 'h')]
        public void NthFileInBoardIsNamedX(int n, char x)
        {
            Assert.True(_board.Files.ElementAt(n - 1).Name == x);
        }

        [Fact]
        public void TotalNumberOfRanksInBoardIs8()
        {
            Assert.True(_board.Ranks.Count == 8);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void NthRankInBoardIsNumberedN(int n)
        {
            Assert.True(_board.Ranks.ElementAt(n - 1).Number == n);
        }

        [Fact]
        public void TotalNumberOfSquaresInBoardIs64()
        {
            Assert.True(_board.Squares.Count == 64);
        }

        [Theory]
        [InlineData(1, "a1")]
        [InlineData(2, "b1")]
        [InlineData(3, "c1")]
        [InlineData(4, "d1")]
        [InlineData(5, "e1")]
        [InlineData(6, "f1")]
        [InlineData(7, "g1")]
        [InlineData(8, "h1")]
        [InlineData(9, "a2")]
        [InlineData(10, "b2")]
        [InlineData(11, "c2")]
        [InlineData(12, "d2")]
        [InlineData(13, "e2")]
        [InlineData(14, "f2")]
        [InlineData(15, "g2")]
        [InlineData(16, "h2")]
        [InlineData(17, "a3")]
        [InlineData(18, "b3")]
        [InlineData(19, "c3")]
        [InlineData(20, "d3")]
        [InlineData(21, "e3")]
        [InlineData(22, "f3")]
        [InlineData(23, "g3")]
        [InlineData(24, "h3")]
        [InlineData(25, "a4")]
        [InlineData(26, "b4")]
        [InlineData(27, "c4")]
        [InlineData(28, "d4")]
        [InlineData(29, "e4")]
        [InlineData(30, "f4")]
        [InlineData(31, "g4")]
        [InlineData(32, "h4")]
        [InlineData(33, "a5")]
        [InlineData(34, "b5")]
        [InlineData(35, "c5")]
        [InlineData(36, "d5")]
        [InlineData(37, "e5")]
        [InlineData(38, "f5")]
        [InlineData(39, "g5")]
        [InlineData(40, "h5")]
        [InlineData(41, "a6")]
        [InlineData(42, "b6")]
        [InlineData(43, "c6")]
        [InlineData(44, "d6")]
        [InlineData(45, "e6")]
        [InlineData(46, "f6")]
        [InlineData(47, "g6")]
        [InlineData(48, "h6")]
        [InlineData(49, "a7")]
        [InlineData(50, "b7")]
        [InlineData(51, "c7")]
        [InlineData(52, "d7")]
        [InlineData(53, "e7")]
        [InlineData(54, "f7")]
        [InlineData(55, "g7")]
        [InlineData(56, "h7")]
        [InlineData(57, "a8")]
        [InlineData(58, "b8")]
        [InlineData(59, "c8")]
        [InlineData(60, "d8")]
        [InlineData(61, "e8")]
        [InlineData(62, "f8")]
        [InlineData(63, "g8")]
        [InlineData(64, "h8")]
        public void NthSquareInBoardIsNamedX(int n, string x)
        {
            Assert.Equal(x, _board.Squares.ElementAt(n - 1).Name);
        }

        [Theory]
        [InlineData("h1")]
        [InlineData("a2")]
        public void SquareNamedXInBoardIsALightSquare(string x)
        {
            Assert.True(_board.Squares.First(square => square.Name == x).IsLight);
        }

        [Theory]
        [InlineData("a1")]
        public void SquareNamedXInBoardIsADarkSquare(string x)
        {
            Assert.True(_board.Squares.First(square => square.Name == x).IsDark);
        }

        [Theory]
        [InlineData("g2", 'g')]
        public void SquareNamedXnBelongsToFileX(string xn, char x)
        {
            var square = _board.Squares.First(s => s.Name == xn);
            var file = _board.Files.First(f => f.Name == x);
            Assert.True(file.Squares.Contains(square));
        }

        [Theory]
        [InlineData("g2", (byte) 2)]
        public void SquareNamedXnBelongsToRankN(string xn, byte n)
        {
            var square = _board.Squares.First(x => x.Name == xn);
            var rank = _board.Ranks.First(x => x.Number == n);
            Assert.True(rank.Squares.Contains(square));
        }

        [Theory]
        [InlineData("g2")]
        public void GetSquareReturnsCorrectSquare(string name)
        {
            var square = _board.Squares.FirstOrDefault(x => x.Name == name);
            Assert.Equal(square, _board.GetSquare(name));
        }

        [Theory]
        [InlineData("g2")]
        public void GetSquareByFileAndRankReturnsCorrectSquare(string name)
        {
            var fileName = name[0];
            var rankNumber = Convert.ToByte(name[1].ToString());
            var file = _board.Files.ElementAtOrDefault(fileName - 97);
            var rank = _board.Ranks.ElementAtOrDefault(rankNumber - 1);
            var square = _board.Squares.FirstOrDefault(x => x.File.Equals(file) && x.Rank.Equals(rank));
            Assert.Equal(square, _board.GetSquare(file, rank));
        }

        [Theory]
        [InlineData('g')]
        public void GetFileReturnsCorrectFile(char name)
        {
            var file = _board.Files.FirstOrDefault(x => x.Name == name);
            Assert.Equal(file, _board.GetFile(name));
        }

        [Theory]
        [InlineData((byte) 2)]
        public void GetRankReturnsCorrectRank(byte rankNumber)
        {
            var rank = _board.Ranks.FirstOrDefault(x => x.Number == rankNumber);
            Assert.Equal(rank, _board.GetRank(rankNumber));
        }

        [Fact]
        public void StringRepresentationEmptyBoardIsAsExpected()
        {
            var actual = _board.ToString();
            var expectedStringBuilder = new StringBuilder();
            const string rankLine = "________________________________";
            const string rankSquares = "|   |   |   |   |   |   |   |   | ";
            for (var i = 8; i > 0;)
            {
                expectedStringBuilder.AppendLine(rankLine);
                expectedStringBuilder.AppendLine(rankSquares + i--);
            }
            expectedStringBuilder.AppendLine(rankLine);
            expectedStringBuilder.Append("  a   b   c   d   e   f   g   h");
            var expected = expectedStringBuilder.ToString();
            Assert.Equal(expected, actual);
        }
    }
}