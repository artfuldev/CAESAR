using CAESAR.Chess.Positions;
using CAESAR.Chess.Core;
using Xunit;



namespace CAESAR.Chess.Tests.Positions
{
    public class PositionTests
    {
        private readonly IPosition _position = Position.EmptyPosition;

        [Theory]
        [InlineData("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR")]
        public void FenStringSetsPiecePlacementOnPosition(string fen, string piecePlacement)
        {
            // Arrange

            // Act
            _position.SetPosition(fen);
            var actual = _position.ToFenString().PiecePlacement;

            // Assert
            Assert.Equal(piecePlacement, actual);
        }

        [Theory]
        [InlineData("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", CastlingRights.WhiteShort | CastlingRights.WhiteLong | CastlingRights.BlackShort | CastlingRights.BlackLong)]
        public void FenStringSetsCastlingRightsOnPosition(string fen, CastlingRights castlingRights)
        {
            // Arrange

            // Act
            _position.SetPosition(fen);
            var actual = _position.CastlingRights;

            // Assert
            Assert.Equal(castlingRights, actual);
        }

        [Theory]
        [InlineData("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", Side.White)]
        public void FenStringSetsSideToMoveOnPosition(string fen, Side side)
        {
            // Arrange

            // Act
            _position.SetPosition(fen);
            var actual = _position.SideToMove;

            // Assert
            Assert.Equal(side, actual);
        }

        [Theory]
        [InlineData("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq e6 0 1", "e6")]
        public void FenStringSetsEnPassantSquareOnPosition(string fen, string enPassantSquare)
        {
            // Arrange

            // Act
            _position.SetPosition(fen);
            var actual = _position.EnPassantSquare.Name;

            // Assert
            Assert.Equal(enPassantSquare, actual);
        }

        [Theory]
        [InlineData("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 49 1", (byte)49)]
        public void FenStringSetsHalfMoveClockOnPosition(string fen, byte halfMoveClock)
        {
            // Arrange

            // Act
            _position.SetPosition(fen);
            var actual = _position.HalfMoveClock;

            // Assert
            Assert.Equal(halfMoveClock, actual);
        }

        [Theory]
        [InlineData("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 15", (ushort)15)]
        public void FenStringSetsFullMoveNumberOnPosition(string fen, ushort fullMoveNumber)
        {
            // Arrange

            // Act
            _position.SetPosition(fen);
            var actual = _position.FullMoveNumber;

            // Assert
            Assert.Equal(fullMoveNumber, actual);
        }
    }
}