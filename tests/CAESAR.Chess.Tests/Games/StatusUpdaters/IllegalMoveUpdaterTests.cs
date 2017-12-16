using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Games;
using CAESAR.Chess.Games.Statuses;
using CAESAR.Chess.Games.Statuses.Updaters;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.Positions;
using Xunit;

namespace CAESAR.Chess.Tests.Games.StatusUpdaters
{
    public class IllegalMoveUpdaterTests
    {
        private readonly IStatusUpdater _updater = new IllegalMoveUpdater();

        [Fact]
        public void UpdaterDoesNotUpdateStatusWhenNumberOfKingsIsEqualToTwoAndOtherSideIsNotInCheck()
        {
            // Arrange
            var game = new Game();
            var status = game.Status;

            // Act
            _updater.UpdateStatus(game);

            // Assert
            Assert.Equal(status, game.Status);
        }

        [Fact]
        public void UpdaterDoesNotUpdateStatusReasonWhenNumberOfKingsIsEqualToTwoAndOtherSideIsNotInCheck()
        {
            // Arrange
            var game = new Game();
            var statusReason = game.StatusReason;

            // Act
            _updater.UpdateStatus(game);

            // Assert
            Assert.Equal(statusReason, game.StatusReason);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public void UpdaterSetsStatusWhenNumberOfKingsIsNotEqualToTwo(int kingsCount)
        {
            // Arrange
            var game = new Game();
            for(var i=0;i<kingsCount;i++)
                game.Position.Board.Squares.ElementAt(i).Piece = new King(Side.White);

            // Act
            _updater.UpdateStatus(game);

            // Assert
            Assert.Equal(Status.WhiteWon, game.Status);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public void UpdaterSetsStatusReasonWhenNumberOfKingsIsNotEqualToTwo(int kingsCount)
        {
            // Arrange
            var game = new Game();
            for (var i = 0; i < kingsCount; i++)
                game.Position.Board.Squares.ElementAt(i).Piece = new King(Side.White);

            // Act
            _updater.UpdateStatus(game);

            // Assert
            Assert.Equal(StatusReason.IllegalMove, game.StatusReason);
        }

        [Theory]
        [InlineData("8/8/8/8/8/4K3/8/R3k3 w - - 0 1")]
        [InlineData("8/8/8/8/1Q6/4K3/8/4k3 w - - 0 1 ")]
        public void UpdaterSetsStatusWhenOtherSideIsInCheck(string fen)
        {
            // Arrange
            var game = new Game();
            game.Position.SetPosition(fen);

            // Act
            _updater.UpdateStatus(game);

            // Assert
            Assert.Equal(Status.WhiteWon, game.Status);
        }

        [Theory]
        [InlineData("8/8/8/8/8/4K3/8/R3k3 w - - 0 1")]
        [InlineData("8/8/8/8/1Q6/4K3/8/4k3 w - - 0 1 ")]
        public void UpdaterSetsStatusReasonWhenOtherSideIsInCheck(string fen)
        {
            // Arrange
            var game = new Game();
            game.Position.SetPosition(fen);

            // Act
            _updater.UpdateStatus(game);

            // Assert
            Assert.Equal(StatusReason.IllegalMove, game.StatusReason);
        }
    }
}