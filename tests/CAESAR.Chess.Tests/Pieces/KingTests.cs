using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Players;
using Xunit;

namespace CAESAR.Chess.Tests.Pieces
{
    public class KingTests
    {
        private readonly IPiece _whitePiece = new King(Side.White);
        private readonly IPiece _blackPiece = new King(Side.Black);
        public KingTests()
        {
            
        }

        [Fact]
        public void NameOfKingPieceIsKing()
        {
            Assert.Equal("King",_whitePiece.Name);
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