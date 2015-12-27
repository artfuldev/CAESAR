using System;
using CAESAR.Chess.Implementation;
using Xunit;
using System.Linq;
using File = CAESAR.Chess.Implementation.File;

namespace CAESAR.Chess.Tests
{
    public class FileTests
    {
        private readonly IBoard _board;
        private readonly IFile _file;

        public FileTests() : this(new Board())
        {
        }

        // Injection Constructor
        private FileTests(IBoard board)
        {
            _board = board;
            _file = _board.Files.FirstOrDefault();
        }

        [Fact]
        public void FileCannotBeConstructedWithoutBoard()
        {
            Assert.Throws<ArgumentNullException>(() => { var s = new File(null, 'a', null); });
        }

        [Fact]
        public void FileCannotBeConstructedWithoutSquares()
        {
            Assert.Throws<ArgumentNullException>(() => { var s = new File(_board, 'a', null); });
            Assert.Throws<ArgumentNullException>(() => { var s = new File(_board, 'a', _board.Squares.Take(0)); });
        }

        [Fact]
        public void FileCannotBeConstructedWithout8Squares()
        {
            
            Assert.Throws<ArgumentException>(() => { var s = new File(_board, 'a', _board.Squares.Take(2)); });
            Assert.Throws<ArgumentException>(() => { var s = new File(_board, 'a', _board.Squares.Take(9)); });
        }

        [Theory]
        [InlineData('i')]
        [InlineData((char)0)]
        [InlineData('A')]
        public void FileCannotBeConstructedWithoutNameFromAtoH(char name)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { var s = new File(_board, name, null); });
        }

        [Fact]
        public void FileContainsReferenceToItsBoard()
        {
            Assert.Equal(_board, _file.Board);
        }

        [Fact]
        public void StringRepresentationOfFileIsItsName()
        {
            Assert.Equal(_file.Name.ToString(), _file.ToString());
        }

        [Fact]
        public void FileCanBeQueriedForItsName()
        {
            Assert.NotNull(_file.Name);
            Assert.Equal(_file.Name, 'a');
            foreach (var file in _board.Files)
                Assert.NotNull(file.Name);
        }

        [Fact]
        public void FileCanBeQueriedForItsSquares()
        {
            Assert.NotNull(_file);
            Assert.NotEmpty(_file.Squares);
            foreach (var file in _board.Files)
                Assert.NotEmpty(file.Squares);
        }

        [Fact]
        public void NumberOfSquaresInFileIs8()
        {
            Assert.Equal(8, _file.Squares.Count);
            foreach (var file in _board.Files)
                Assert.Equal(8, file.Squares.Count);
        }

        [Fact]
        public void RankOfSquaresInFileRangeFrom1To8()
        {
            Assert.Equal(string.Join(",", _file.Squares.Select(x => x.Rank.Number).OrderBy(x => x).Select(x => x.ToString())), "1,2,3,4,5,6,7,8");
            foreach (var file in _board.Files)
                Assert.Equal(string.Join(",", file.Squares.Select(x => x.Rank.Number).OrderBy(x => x).Select(x => x.ToString())), "1,2,3,4,5,6,7,8");
        }

    }
}