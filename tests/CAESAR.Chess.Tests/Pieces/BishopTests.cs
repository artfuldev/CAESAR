using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
using Xunit;

namespace CAESAR.Chess.Tests.Pieces
{
    public class BishopTests
    {
        private readonly IPiece _blackPiece = new Bishop(Side.Black);
        private readonly IPiece _whitePiece = new Bishop(Side.White);

        [Fact]
        public void NameOfBishopPieceIsBishop()
        {
            Assert.Equal("Bishop", _whitePiece.Name);
            Assert.Equal("Bishop", _blackPiece.Name);
        }

        [Fact]
        public void SideOfBishopPieceIsStored()
        {
            Assert.Equal(Side.White, _whitePiece.Side);
            Assert.Equal(Side.Black, _blackPiece.Side);
        }

        [Fact]
        public void NotationOfWhiteBishopIsB()
        {
            Assert.Equal('B', _whitePiece.Notation);
        }

        [Fact]
        public void NotationOfBlackBishopIsb()
        {
            Assert.Equal('b', _blackPiece.Notation);
        }
    }
}