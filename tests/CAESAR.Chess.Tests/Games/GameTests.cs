using CAESAR.Chess.Games;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Players;
using CAESAR.Chess.Positions;
using Xunit;
using CAESAR.Chess.Games.Exceptions;

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
            var position = new Position {SideToMove = startingSide};
            var game = new Game(position);
            for (var i = 0; i < halfMovesPlayed; i++)
                game.Play();
            Assert.Equal(expectedSide, game.CurrentPlayer.Side);
            Assert.Equal(expectedSide, game.Position.SideToMove);
        }

        [Fact]
        public void SkippingAMoveIsIllegal()
        {
            var position = new Position() {SideToMove = Side.White};
            var game = new Game(position);
            Assert.Throws<CannotSkipMoveException>(() => { game.Play(null); });
        }
    }
}