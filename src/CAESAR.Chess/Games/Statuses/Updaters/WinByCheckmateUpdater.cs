using System.Linq;
using CAESAR.Chess.Core;

namespace CAESAR.Chess.Games.Statuses.Updaters
{
    /// <summary>
    ///     Updates the <seealso cref="IGame.Status" /> and <seealso cref="IGame.StatusReason" /> of an
    ///     <seealso cref="IGame" />, if the current player has been checkmated.
    /// </summary>
    public class WinByCheckmateUpdater : IStatusUpdater
    {
        /// <summary>
        ///     Updates the <seealso cref="IGame.Status" /> and <seealso cref="IGame.StatusReason" /> of an
        ///     <seealso cref="IGame" />, if the current player has been checkmated.
        /// </summary>
        /// <param name="game">The <seealso cref="IGame" /> for which the status is to be updated.</param>
        public void UpdateStatus(IGame game)
        {
            if (!game.CurrentSideInCheck || game.CurrentPlayer.GetAllMoves(game.Position).Any()) return;
            game.Status = game.Position.SideToMove == Side.White ? Status.BlackWon : Status.WhiteWon;
            game.StatusReason = StatusReason.Checkmate;
        }
    }
}