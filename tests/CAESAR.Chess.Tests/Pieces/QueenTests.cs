using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
using Xunit;

namespace CAESAR.Chess.Tests.Pieces
{
    public class QueenTests
    {
        private readonly IPiece _blackPiece = new Queen(Side.Black);
        private readonly IPiece _whitePiece = new Queen(Side.White);

        [Fact]
        public void NameOfQueenPieceIsQueen()
        {
            Assert.Equal("Queen", _whitePiece.Name);
            Assert.Equal("Queen", _blackPiece.Name);
        }

        [Fact]
        public void SideOfQueenPieceIsStored()
        {
            Assert.Equal(Side.White, _whitePiece.Side);
            Assert.Equal(Side.Black, _blackPiece.Side);
        }

        [Fact]
        public void NotationOfWhiteQueenIsQ()
        {
            Assert.Equal('Q', _whitePiece.Notation);
        }

        [Fact]
        public void NotationOfBlackQueenIsq()
        {
            Assert.Equal('q', _blackPiece.Notation);
        }
    }
}