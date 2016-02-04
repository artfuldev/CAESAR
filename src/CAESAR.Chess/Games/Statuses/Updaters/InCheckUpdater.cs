using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Games.Statuses.Updaters
{
    /// <summary>
    ///     Updates the <seealso cref="IGame.Status" /> and <seealso cref="IGame.StatusReason" /> of an
    ///     <seealso cref="IGame" />, when the current player is in check.
    /// </summary>
    public class InCheckUpdater : IStatusUpdater
    {
        /// <summary>
        ///     Updates the <seealso cref="IGame.Status" /> and <seealso cref="IGame.StatusReason" /> of an
        ///     <seealso cref="IGame" />, when the current player is in check.
        /// </summary>
        /// <param name="game">The <seealso cref="IGame" /> for which the status is to be updated.</param>
        public void UpdateStatus(IGame game)
        {
            game.CurrentSideInCheck = game.Position.IsInCheck(game.Position.SideToMove);
        }
    }
}