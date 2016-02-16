using CAESAR.Chess.Games;
using CAESAR.Chess.Games.Statuses;
using CAESAR.Chess.Games.Statuses.Updaters;
using Xunit;

namespace CAESAR.Chess.Tests.Games.StatusUpdaters
{
    public class FiftyMoveRuleUpdaterTests
    {
        private readonly IStatusUpdater _updater = new FiftyMoveRuleUpdater();

        [Theory]
        [InlineData((byte)5)]
        [InlineData((byte)15)]
        [InlineData((byte)25)]
        [InlineData((byte)49)]
        public void UpdaterDoesNotUpdateStatusWhenHalfMoveClockIsLessThanFifty(byte halfMoveCount)
        {
            // Arrange
            var game = new Game();
            var status = game.Status;
            game.Position.HalfMoveClock = halfMoveCount;

            // Act
            _updater.UpdateStatus(game);

            // Assert
            Assert.Equal(status, game.Status);
        }

        [Theory]
        [InlineData((byte)5)]
        [InlineData((byte)15)]
        [InlineData((byte)25)]
        [InlineData((byte)49)]
        public void UpdaterDoesNotUpdateStatusReasonWhenHalfMoveClockIsLessThanFifty(byte halfMoveCount)
        {
            // Arrange
            var game = new Game();
            var statusReason = game.StatusReason;
            game.Position.HalfMoveClock = halfMoveCount;

            // Act
            _updater.UpdateStatus(game);

            // Assert
            Assert.Equal(statusReason, game.StatusReason);
        }

        [Theory]
        [InlineData((byte)51)]
        [InlineData((byte)50)]
        public void UpdaterUpdatesStatusToDrawnWhenHalfMoveClockIsGreaterThanOrEqualToFifty(byte halfMoveCount)
        {
            // Arrange
            var game = new Game();
            game.Position.HalfMoveClock = halfMoveCount;

            // Act
            _updater.UpdateStatus(game);

            // Assert
            Assert.Equal(Status.Drawn, game.Status);
        }

        [Theory]
        [InlineData((byte)50)]
        [InlineData((byte)51)]
        public void UpdaterUpdatesStatusReasonToFiftyMoveRuleWhenHalfMoveClockIsGreaterThanOrEqualToFifty(byte halfMoveCount)
        {
            // Arrange
            var game = new Game();
            game.Position.HalfMoveClock = halfMoveCount;

            // Act
            _updater.UpdateStatus(game);

            // Assert
            Assert.Equal(StatusReason.FiftyMoveRule, game.StatusReason);
        }
    }
}