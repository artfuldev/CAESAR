using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Players;
using Xunit;

namespace CAESAR.Chess.Tests.Pieces
{
    public class PawnTests
    {
        private readonly IPiece _whitePiece = new Pawn(true);
        private readonly IPiece _blackPiece = new Pawn(false);
        private readonly IBoard _board = new Board();
        private readonly IPlayer _player = new Player();

        [Fact]
        public void NameOfPawnPieceIsPawn()
        {
            Assert.Equal("Pawn",_whitePiece.Name);
            Assert.Equal("Pawn", _blackPiece.Name);
        }

        [Fact]
        public void IsWhiteOfPawnPieceIsStored()
        {
            Assert.Equal(true, _whitePiece.IsWhite);
            Assert.Equal(false, _blackPiece.IsWhite);
        }

        [Fact]
        public void IsWhiteOfPawnPieceIsOppositeOfIsBlack()
        {
            Assert.NotEqual(_whitePiece.IsBlack, _whitePiece.IsWhite);
            Assert.NotEqual(_blackPiece.IsBlack, _blackPiece.IsWhite);
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