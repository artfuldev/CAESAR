namespace CAESAR.Chess.Games.Statuses.Updaters
{
    public class InProgressUpdater : IStatusUpdater
    {
        public void UpdateStatus(IGame game)
        {
            if (game.Status != Status.Unknown && (game.Status != Status.YetToBegin || game.Moves.Count <= 0))
                return;
            game.Status = Status.InProgress;
            game.StatusReason = StatusReason.PlayInProgress;
        }
    }
}