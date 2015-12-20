using System;
using CAESAR.Chess.Implementation;
using System.Linq;
using Xunit;

namespace CAESAR.Chess.Tests
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class BoardTests
    {
        private readonly IBoard _board;

        public BoardTests() : this(new Board())
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
            Assert.True(_board.Files.ElementAt(n-1).Name == x);
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

        [Fact]
        public void FirstSquareofBoardIsA1()
        {
            Assert.True(_board.Squares.ElementAt(0).Name == "a1");
        }
    }
}
