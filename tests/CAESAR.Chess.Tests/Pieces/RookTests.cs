using CAESAR.Chess.Implementation;
using CAESAR.Chess.Pieces;
using Xunit;

namespace CAESAR.Chess.Tests.Pieces
{
    public class RookTests
    {
        private readonly IPiece _whitePiece = new Rook(true);
        private readonly IPiece _blackPiece = new Rook(false);
        private readonly IBoard _board = new Board();
        private readonly IPlayer _player = new Player();

        [Fact]
        public void NameOfRookPieceIsRook()
        {
            Assert.Equal("Rook",_whitePiece.Name);
            Assert.Equal("Rook", _blackPiece.Name);
        }

        [Fact]
        public void IsWhiteOfRookPieceIsStored()
        {
            Assert.Equal(true, _whitePiece.IsWhite);
            Assert.Equal(false, _blackPiece.IsWhite);
        }

        [Fact]
        public void IsWhiteOfRookPieceIsOppositeOfIsBlack()
        {
            Assert.NotEqual(_whitePiece.IsBlack, _whitePiece.IsWhite);
            Assert.NotEqual(_blackPiece.IsBlack, _blackPiece.IsWhite);
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