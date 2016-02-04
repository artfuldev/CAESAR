namespace CAESAR.Chess.Games.Statuses.Updaters
{
    /// <summary>
    ///     Updates the <seealso cref="IGame.Status" /> and <seealso cref="IGame.StatusReason" /> of an
    ///     <seealso cref="IGame" />, based on the Fifty Move Rule (https://en.wikipedia.org/wiki/Fifty-move_rule)
    /// </summary>
    public class FiftyMoveRuleUpdater : IStatusUpdater
    {
        /// <summary>
    ///     Updates the <seealso cref="IGame.Status" /> and <seealso cref="IGame.StatusReason" /> of an
    ///     <seealso cref="IGame" />, based on the Fifty Move Rule (https://en.wikipedia.org/wiki/Fifty-move_rule)
    /// </summary>
        /// <param name="game">The <seealso cref="IGame" /> for which the status is to be updated.</param>
        public void UpdateStatus(IGame game)
        {
            var position = game.Position;
            if (position.HalfMoveClock < 50)
                return;
            game.Status = Status.Drawn;
            game.StatusReason = StatusReason.FiftyMovesRule;
        }
    }
}