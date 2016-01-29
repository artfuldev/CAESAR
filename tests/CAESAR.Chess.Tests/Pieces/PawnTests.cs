using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
using Xunit;

namespace CAESAR.Chess.Tests.Pieces
{
    public class PawnTests
    {
        private readonly IPiece _blackPiece = new Pawn(Side.Black);
        private readonly IPiece _whitePiece = new Pawn(Side.White);

        [Fact]
        public void NameOfPawnPieceIsPawn()
        {
            Assert.Equal("Pawn", _whitePiece.Name);
            Assert.Equal("Pawn", _blackPiece.Name);
        }

        [Fact]
        public void SideOfPawnPieceIsStored()
        {
            Assert.Equal(Side.White, _whitePiece.Side);
            Assert.Equal(Side.Black, _blackPiece.Side);
        }

        [Fact]
        public void NotationOfWhitePawnIsP()
        {
            Assert.Equal('P', _whitePiece.Notation);
        }

        [Fact]
        public void NotationOfBlackPawnIsp()
        {
            Assert.Equal('p', _blackPiece.Notation);
        }
    }
}