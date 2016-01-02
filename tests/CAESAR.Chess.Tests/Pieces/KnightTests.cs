using CAESAR.Chess.Implementation;
using CAESAR.Chess.Pieces;
using Xunit;

namespace CAESAR.Chess.Tests.Pieces
{
    public class KnightTests
    {
        private readonly IPiece _whitePiece = new Knight(true);
        private readonly IPiece _blackPiece = new Knight(false);
        private readonly IBoard _board = new Board();
        private readonly IPlayer _player = new Player();

        [Fact]
        public void NameOfKnightPieceIsKnight()
        {
            Assert.Equal("Knight",_whitePiece.Name);
            Assert.Equal("Knight", _blackPiece.Name);
        }

        [Fact]
        public void IsWhiteOfKnightPieceIsStored()
        {
            Assert.Equal(true, _whitePiece.IsWhite);
            Assert.Equal(false, _blackPiece.IsWhite);
        }

        [Fact]
        public void IsWhiteOfKnightPieceIsOppositeOfIsBlack()
        {
            Assert.NotEqual(_whitePiece.IsBlack, _whitePiece.IsWhite);
            Assert.NotEqual(_blackPiece.IsBlack, _blackPiece.IsWhite);
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