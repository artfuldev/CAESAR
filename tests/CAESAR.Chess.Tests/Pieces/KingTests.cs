using CAESAR.Chess.Implementation;
using CAESAR.Chess.Pieces;
using Xunit;

namespace CAESAR.Chess.Tests.Pieces
{
    public class KingTests
    {
        private readonly IPiece _whitePiece = new King(true);
        private readonly IPiece _blackPiece = new King(false);
        private readonly IBoard _board = new Board();
        private readonly IPlayer _player = new Player();
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
        public void IsWhiteOfKingPieceIsStored()
        {
            Assert.Equal(true, _whitePiece.IsWhite);
            Assert.Equal(false, _blackPiece.IsWhite);
        }

        [Fact]
        public void IsWhiteOfKingPieceIsOppositeOfIsBlack()
        {
            Assert.NotEqual(_whitePiece.IsBlack, _whitePiece.IsWhite);
            Assert.NotEqual(_blackPiece.IsBlack, _blackPiece.IsWhite);
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