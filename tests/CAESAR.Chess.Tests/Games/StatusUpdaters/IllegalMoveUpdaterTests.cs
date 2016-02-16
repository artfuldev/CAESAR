using CAESAR.Chess.Games.Statuses.Updaters;

namespace CAESAR.Chess.Tests.Games.StatusUpdaters
{
    public class IllegalMoveUpdaterTests
    {
        private readonly IStatusUpdater _updater = new IllegalMoveUpdater();
    }
}