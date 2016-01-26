using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
using Xunit;

namespace CAESAR.Chess.Tests.Pieces
{
    public class KingTests
    {
        private readonly IPiece _blackPiece = new King(Side.Black);
        private readonly IPiece _whitePiece = new King(Side.White);

        [Fact]
        public void NameOfKingPieceIsKing()
        {
            Assert.Equal("King", _whitePiece.Name);
            Assert.Equal("King", _blackPiece.Name);
        }

        [Fact]
        public void SideOfKingPieceIsStored()
        {
            Assert.Equal(Side.White, _whitePiece.Side);
            Assert.Equal(Side.Black, _blackPiece.Side);
        }

        [Fact]
        public void NotationOfWhiteKingIsK()
        {
            Assert.Equal('K', _whitePiece.Notation);
        }

        [Fact]
        public void NotationOfBlackKingIsk()
        {
            Assert.Equal('k', _blackPiece.Notation);
        }
    }
}