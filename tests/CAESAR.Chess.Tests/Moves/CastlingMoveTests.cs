using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.Players;
using CAESAR.Chess.Positions;
using Xunit;

namespace CAESAR.Chess.Tests.Moves
{
    public class CastlingMoveTests
    {
        /// <summary>
        /// Position allowing all castles
        /// </summary>
        private readonly IPosition _position = new Position("r3k2r/8/8/8/8/8/8/R3K2R w KQkq - 1 1");

        [Theory]
        [InlineData(Side.White, CastleSide.King, "g1")]
        [InlineData(Side.White, CastleSide.Queen, "c1")]
        [InlineData(Side.Black, CastleSide.King, "g8")]
        [InlineData(Side.Black, CastleSide.Queen, "c8")]
        public void CastlingMoveMovesKingToCorrectSquare(Side side, CastleSide castleSide, string squareName)
        {
            // Arrange
            var square =
                _position.Board.Squares.First(
                    x => x.HasPiece && x.Piece.PieceType == PieceType.King && x.Piece.Side == side);
            var move = new CastlingMove(square, castleSide);
            var player = new Player() {Side = side};

            // Act
            var position = player.MakeMove(move);
            square =
                position.Board.Squares.First(
                    x => x.HasPiece && x.Piece.PieceType == PieceType.King && x.Piece.Side == side);

            // Assert
            Assert.Equal(squareName, square.Name);
        }

        [Theory]
        [InlineData(Side.White, CastleSide.King, "f1")]
        [InlineData(Side.White, CastleSide.Queen, "d1")]
        [InlineData(Side.Black, CastleSide.King, "f8")]
        [InlineData(Side.Black, CastleSide.Queen, "d8")]
        public void CastlingMoveMovesRookToCorrectSquare(Side side, CastleSide castleSide, string squareName)
        {
            // Arrange
            var square =
                _position.Board.Squares.First(
                    x => x.HasPiece && x.Piece.PieceType == PieceType.King && x.Piece.Side == side);
            var move = new CastlingMove(square, castleSide);
            var player = new Player() { Side = side };

            // Act
            var position = player.MakeMove(move);
            var rookSquare = position.Board.GetSquare(squareName);

            // Assert
            Assert.Equal(PieceType.Rook, rookSquare.Piece.PieceType);
        }
    }
}