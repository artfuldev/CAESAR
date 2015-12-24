﻿using System;
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
            _file = new File(_board, 'a');
        }

        [Fact]
        public void FileCannotBeConstructedWithoutBoard()
        {
            Assert.Throws<ArgumentNullException>(() => { var s = new File(null, 'a'); });
        }

        [Theory]
        [InlineData('i')]
        [InlineData((char) 0)]
        [InlineData('A')]
        public void FileCannotBeConstructedWithoutNameFromAtoH(char name)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { var s = new File(_board, name); });
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

    }
}