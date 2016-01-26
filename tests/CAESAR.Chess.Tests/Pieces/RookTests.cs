using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Players;
using Xunit;

namespace CAESAR.Chess.Tests.Pieces
{
    public class RookTests
    {
        private readonly IPiece _whitePiece = new Rook(Side.White);
        private readonly IPiece _blackPiece = new Rook(Side.Black);

        [Fact]
        public void NameOfRookPieceIsRook()
        {
            Assert.Equal("Rook",_whitePiece.Name);
            Assert.Equal("Rook", _blackPiece.Name);
        }

        [Fact]
        public void SideOfRookPieceIsStored()
        {
            Assert.Equal(Side.White, _whitePiece.Side);
            Assert.Equal(Side.Black, _blackPiece.Side);
        }

        [Fact]
        public void NotationOfWhiteRookIsR()
        {
            Assert.Equal('R', _whitePiece.Notation);
        }

        [Fact]
        public void NotationOfBlackRookIsr()
        {
            Assert.Equal('r', _blackPiece.Notation);
        }

    }
}