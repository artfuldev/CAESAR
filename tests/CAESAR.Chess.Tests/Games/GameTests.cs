using CAESAR.Chess.Games;
using CAESAR.Chess.Core;
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
    }
}