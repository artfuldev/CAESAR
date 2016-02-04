using System.Linq;

namespace CAESAR.Chess.Games.Statuses.Updaters
{
    /// <summary>
    ///     Updates the <seealso cref="IGame.Status" /> and <seealso cref="IGame.StatusReason" /> of an
    ///     <seealso cref="IGame" />, when the current player has been stalemated.
    /// </summary>
    public class StalemateUpdater : IStatusUpdater
    {
        /// <summary>
        ///     Updates the <seealso cref="IGame.Status" /> and <seealso cref="IGame.StatusReason" /> of an
        ///     <seealso cref="IGame" />, when the current player has been stalemated.
        /// </summary>
        /// <param name="game">The <seealso cref="IGame" /> for which the status is to be updated.</param>
        public void UpdateStatus(IGame game)
        {
            if (game.CurrentSideInCheck || game.CurrentPlayer.GetAllMoves(game.Position).Any())
                return;
            game.Status = Status.Drawn;
            game.StatusReason = StatusReason.Stalemate;
        }
    }
}