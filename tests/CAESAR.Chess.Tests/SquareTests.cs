using System;
using CAESAR.Chess.Implementation;
using Xunit;
using System.Linq;

namespace CAESAR.Chess.Tests
{
    public class SquareTests
    {
        private readonly IBoard _board;
        private readonly ISquare _darkSquare;
        private readonly ISquare _lightSquare;
        private readonly ISquare _square;

        public SquareTests() : this(new Board())
        {
        }

        // Injection Constructor
        private SquareTests(IBoard board)
        {
            _board = board;
            _darkSquare = new Square(_board, _board.Files.ElementAt(0), _board.Ranks.ElementAt(0), "a1");
            _lightSquare = new Square(_board, _board.Files.ElementAt(7), _board.Ranks.ElementAt(2), "h3", true);
            _square = _board.Squares.FirstOrDefault();
        }

        [Fact]
        public void SquareCannotBeConstructedWithoutBoard()
        {
            Assert.Throws<ArgumentNullException>(() => { var s = new Square(null, null, null, null, false); });
        }

        [Fact]
        public void SquareCannotBeConstructedWithoutFile()
        {
            Assert.Throws<ArgumentNullException>(() => { var s = new Square(_board, null, null, null, false); });
        }

        [Fact]
        public void SquareCannotBeConstructedWithoutRank()
        {
            Assert.Throws<ArgumentNullException>(() => { var s = new Square(_board, _board.Files.ElementAt(0), null, null, false); });
        }

        [Fact]
        public void SquareCannotBeConstructedWithoutName()
        {
            Assert.Throws<ArgumentException>(() => { var s = new Square(_board, _board.Files.ElementAt(0), _board.Ranks.ElementAt(0), null, false); });
            Assert.Throws<ArgumentException>(() => { var s = new Square(_board, _board.Files.ElementAt(0), _board.Ranks.ElementAt(0), "", false); });
            Assert.Throws<ArgumentException>(() => { var s = new Square(_board, _board.Files.ElementAt(0), _board.Ranks.ElementAt(0), "   ", false); });
            Assert.Throws<ArgumentException>(() => { var s = new Square(_board, _board.Files.ElementAt(0), _board.Ranks.ElementAt(0), "\n", false); });
        }

        [Fact]
        public void SquareContainsReferenceToItsBoard()
        {
            Assert.Equal(_board, _darkSquare.Board);
            Assert.Equal(_board, _lightSquare.Board);
            Assert.Equal(_board, _square.Board);
        }

        [Fact]
        public void SquareKnowsIfItIsLightOrDark()
        {
            Assert.Equal(false, _darkSquare.IsLight);
            Assert.Equal(true, _lightSquare.IsLight);
        }

        [Fact]
        public void SquareCannotBeDarkIfItIsLight()
        {
            Assert.NotEqual(_darkSquare.IsDark, _darkSquare.IsLight);
            Assert.NotEqual(_lightSquare.IsDark, _lightSquare.IsLight);
            Assert.NotEqual(_square.IsDark, _square.IsLight);
        }

        [Fact]
        public void StringRepresentationOfSquareOfBoardIsItsName()
        { 
            Assert.Equal(_square.Name, _square.ToString());
        }

        [Fact]
        public void SquareOfBoardContainsReferenceToFile()
        {
            Assert.NotNull(_square.File);
        }

        [Fact]
        public void SquareOfBoardContainsReferenceToRank()
        {
            Assert.NotNull(_square.Rank);
        }

        [Fact]
        public void SquareOfBoardHasName()
        {
            Assert.False(string.IsNullOrWhiteSpace(_square.Name));
        }

        [Fact]
        public void SquareOfBoardsNameIsFileNamePlusRankNumber()
        {
            Assert.Equal(_square.Name, _square.File.Name.ToString() + _square.Rank.Number);
        }
    }
}