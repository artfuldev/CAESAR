using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
using Xunit;

namespace CAESAR.Chess.Tests.Pieces
{
    public class KnightTests
    {
        private readonly IPiece _blackPiece = new Knight(Side.Black);
        private readonly IPiece _whitePiece = new Knight(Side.White);

        [Fact]
        public void NameOfKnightPieceIsKnight()
        {
            Assert.Equal("Knight", _whitePiece.Name);
            Assert.Equal("Knight", _blackPiece.Name);
        }

        [Fact]
        public void SideOfKnightPieceIsStored()
        {
            Assert.Equal(Side.White, _whitePiece.Side);
            Assert.Equal(Side.Black, _blackPiece.Side);
        }

        [Fact]
        public void NotationOfWhiteKnightIsN()
        {
            Assert.Equal('N', _whitePiece.Notation);
        }

        [Fact]
        public void NotationOfBlackKnightIsn()
        {
            Assert.Equal('n', _blackPiece.Notation);
        }
    }
}