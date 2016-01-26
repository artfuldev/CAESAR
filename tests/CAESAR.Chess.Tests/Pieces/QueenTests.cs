using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Players;
using Xunit;

namespace CAESAR.Chess.Tests.Pieces
{
    public class QueenTests
    {
        private readonly IPiece _whitePiece = new Queen(true);
        private readonly IPiece _blackPiece = new Queen(false);
        private readonly IBoard _board = new Board();
        private readonly IPlayer _player = new Player();

        [Fact]
        public void NameOfQueenPieceIsQueen()
        {
            Assert.Equal("Queen",_whitePiece.Name);
            Assert.Equal("Queen", _blackPiece.Name);
        }

        [Fact]
        public void IsWhiteOfQueenPieceIsStored()
        {
            Assert.Equal(true, _whitePiece.IsWhite);
            Assert.Equal(false, _blackPiece.IsWhite);
        }

        [Fact]
        public void IsWhiteOfQueenPieceIsOppositeOfIsBlack()
        {
            Assert.NotEqual(_whitePiece.IsBlack, _whitePiece.IsWhite);
            Assert.NotEqual(_blackPiece.IsBlack, _blackPiece.IsWhite);
        }

        [Fact]
        public void NotationOfWhiteQueenIsQ()
        {
            Assert.Equal('Q', _whitePiece.Notation);
        }

        [Fact]
        public void NotationOfBlackQueenIsq()
        {
            Assert.Equal('q', _blackPiece.Notation);
        }

    }
}