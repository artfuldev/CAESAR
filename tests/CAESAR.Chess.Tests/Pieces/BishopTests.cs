using CAESAR.Chess.Implementation;
using CAESAR.Chess.Pieces;
using Xunit;

namespace CAESAR.Chess.Tests.Pieces
{
    public class BishopTests
    {
        private readonly IPiece _whitePiece = new Bishop(true);
        private readonly IPiece _blackPiece = new Bishop(false);
        private readonly IBoard _board = new Board();
        private readonly IPlayer _player = new Player();

        [Fact]
        public void NameOfBishopPieceIsBishop()
        {
            Assert.Equal("Bishop",_whitePiece.Name);
            Assert.Equal("Bishop", _blackPiece.Name);
        }

        [Fact]
        public void IsWhiteOfBishopPieceIsStored()
        {
            Assert.Equal(true, _whitePiece.IsWhite);
            Assert.Equal(false, _blackPiece.IsWhite);
        }

        [Fact]
        public void IsWhiteOfBishopPieceIsOppositeOfIsBlack()
        {
            Assert.NotEqual(_whitePiece.IsBlack, _whitePiece.IsWhite);
            Assert.NotEqual(_blackPiece.IsBlack, _blackPiece.IsWhite);
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