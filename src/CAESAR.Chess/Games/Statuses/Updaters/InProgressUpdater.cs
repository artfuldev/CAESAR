namespace CAESAR.Chess.Games.Statuses.Updaters
{
    /// <summary>
    ///     Updates the <seealso cref="IGame.Status" /> and <seealso cref="IGame.StatusReason" /> of an
    ///     <seealso cref="IGame" />, when a game has been started and is in progress.
    /// </summary>
    public class InProgressUpdater : IStatusUpdater
    {
        /// <summary>
        ///     Updates the <seealso cref="IGame.Status" /> and <seealso cref="IGame.StatusReason" /> of an
        ///     <seealso cref="IGame" />, when a game has been started and is in progress.
        /// </summary>
        /// <param name="game">The <seealso cref="IGame" /> for which the status is to be updated.</param>
        public void UpdateStatus(IGame game)
        {
            if (game.Status != Status.Unknown && (game.Status != Status.YetToBegin || game.Moves.Count <= 0))
                return;
            game.Status = Status.InProgress;
            game.StatusReason = StatusReason.PlayInProgress;
        }
    }
}