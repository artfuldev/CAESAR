using CAESAR.Chess.Core;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Moves.Notations;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.Positions;
using System.Linq;
using Xunit;

namespace CAESAR.Chess.Tests.Moves.Notations
{
    public class ShortAlgebraicNotationTests
    {
        private readonly IPosition _castlingPosition = new Position("r3k2r/8/8/8/8/8/8/R3K2R w KQkq - 1 1");
        private readonly INotation _notation = new ShortAlgebraicNotation();

        [Theory]
        [InlineData(Side.White, CastleSide.King, "O-O")]
        [InlineData(Side.White, CastleSide.Queen, "O-O-O")]
        [InlineData(Side.Black, CastleSide.King, "O-O")]
        [InlineData(Side.Black, CastleSide.Queen, "O-O-O")]
        public void CastlingMoveProducesCorrectStringRepresentation(Side side, CastleSide castleSide,
            string moveRepresentation)
        {
            // Arrange
            var square =
                _castlingPosition.Board.Squares.First(
                    x => x.HasPiece && x.Piece.PieceType == PieceType.King && x.Piece.Side == side);
            var move = new CastlingMove(square, castleSide);
            
            // Act
            var moveString = _notation.ToString(move);

            // Assert
            Assert.Equal(moveRepresentation, moveString);
        }
    }
}