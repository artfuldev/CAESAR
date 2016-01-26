using System;
using Xunit;
using System.Linq;
using CAESAR.Chess.PlayArea;
using Rank = CAESAR.Chess.PlayArea.Rank;

namespace CAESAR.Chess.Tests
{
    public class RankTests
    {
        private readonly IBoard _board;
        private readonly IRank _rank;

        public RankTests() : this(new Board())
        {
        }

        // Injection Constructor
        private RankTests(IBoard board)
        {
            _board = board;
            _rank = _board.Ranks.FirstOrDefault();
        }

        [Fact]
        public void RankCannotBeConstructedWithoutBoard()
        {
            Assert.Throws<ArgumentNullException>(() => { var s = new Rank(null, 1, null); });
        }

        [Fact]
        public void RankCannotBeConstructedWithoutSquares()
        {
            Assert.Throws<ArgumentNullException>(() => { var s = new Rank(_board, 1, null); });
            Assert.Throws<ArgumentNullException>(() => { var s = new Rank(_board, 1, _board.Squares.Take(0)); });
        }

        [Fact]
        public void RankCannotBeConstructedWithout8Squares()
        {
            Assert.Throws<ArgumentException>(() => { var s = new Rank(_board, 1, _board.Squares.Take(2)); });
            Assert.Throws<ArgumentException>(() => { var s = new Rank(_board, 1, _board.Squares.Take(9)); });
        }

        [Theory]
        [InlineData((byte)0)]
        [InlineData((byte)9)]
        [InlineData(byte.MaxValue)]
        public void RankCannotBeConstructedWithoutNameFromAtoH(byte number)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { var s = new Rank(_board, number, null); });
        }

        [Fact]
        public void RankContainsReferenceToItsBoard()
        {
            Assert.Equal(_board, _rank.Board);
        }

        [Fact]
        public void StringRepresentationOfRankIsItsNumber()
        {
            Assert.Equal(_rank.Number.ToString(), _rank.ToString());
        }

        [Fact]
        public void RankCanBeQueriedForItsNumber()
        {
            Assert.NotNull(_rank.Number);
            Assert.Equal(_rank.Number, 1);
            foreach (var rank in _board.Ranks)
                Assert.True(rank.Number != 0);
        }

        [Fact]
        public void RankCanBeQueriedForItsSquares()
        {
            Assert.NotNull(_rank);
            Assert.NotEmpty(_rank.Squares);
            foreach (var rank in _board.Ranks)
                Assert.NotEmpty(rank.Squares);
        }

        [Fact]
        public void NumberOfSquaresInRankIs8()
        {
            Assert.Equal(8, _rank.Squares.Count);
            foreach (var rank in _board.Ranks)
                Assert.Equal(8, rank.Squares.Count);
        }

        [Fact]
        public void FileOfSquaresInRankRangeFromAtoH()
        {
            Assert.Equal(string.Join(",", _rank.Squares.Select(x => x.File.Name).OrderBy(x => x).Select(x => x.ToString())), "a,b,c,d,e,f,g,h");
            foreach (var rank in _board.Ranks)
                Assert.Equal(string.Join(",", rank.Squares.Select(x => x.File.Name).OrderBy(x => x).Select(x => x.ToString())), "a,b,c,d,e,f,g,h");
        }
    }
}