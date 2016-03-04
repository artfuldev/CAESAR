using CAESAR.Chess.Games;
using CAESAR.Chess.Core;
using CAESAR.Chess.Positions;
using Xunit;

namespace CAESAR.Chess.Tests.Games
{
    public class GameTests
    {
        private readonly IGame _game = new Game();

        [Fact]
        public void GamesWhitePlayersSideIsWhite()
        {
            Assert.Equal(Side.White, _game.White.Side);
        }

        [Fact]
        public void GamesBlackPlayersSideIsBlack()
        {
            Assert.Equal(Side.Black, _game.Black.Side);
        }

        [Theory]
        [InlineData(Side.White, 0U, Side.White)]
        [InlineData(Side.White, 2U, Side.White)]
        [InlineData(Side.White, 3U, Side.Black)]
        [InlineData(Side.Black, 0U, Side.Black)]
        [InlineData(Side.Black, 2U, Side.Black)]
        [InlineData(Side.Black, 3U, Side.White)]
        public void GamesSideToPlayIsCorrect(Side startingSide, uint halfMovesPlayed, Side expectedSide)
        {
            var position = new Position();
            position.SideToMove = startingSide;
            var game = new Game(position);
            for (var i = 0; i < halfMovesPlayed; i++)
                game.Play();
            Assert.Equal(expectedSide, game.CurrentPlayer.Side);
            Assert.Equal(expectedSide, game.Position.SideToMove);
        }
    }
}