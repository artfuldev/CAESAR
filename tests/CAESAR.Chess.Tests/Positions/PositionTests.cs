using CAESAR.Chess.Positions;
using Xunit;

namespace CAESAR.Chess.Tests.Positions
{
    public class PositionTests
    {
        private readonly IPosition _position = new Position();

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
    }
}