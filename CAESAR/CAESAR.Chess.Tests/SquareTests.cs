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
            _darkSquare = new Square(_board);
            _lightSquare = new Square(_board, true);
            _square = _board.Squares.FirstOrDefault();
        }

        [Fact]
        public void SquareCannotBeConstructedWithoutBoard()
        {
            Assert.Throws<ArgumentNullException>(() => { var s = new Square(null); });
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
        public void StringRepresentationOfSquareIsItsName()
        {
            Assert.Equal(_darkSquare.Name, _darkSquare.ToString());
            Assert.Equal(_lightSquare.Name, _lightSquare.ToString());
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
    }
}