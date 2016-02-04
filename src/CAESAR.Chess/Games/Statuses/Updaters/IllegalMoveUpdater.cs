using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Games.Statuses.Updaters
{
    /// <summary>
    ///     Updates the <seealso cref="IGame.Status" /> and <seealso cref="IGame.StatusReason" /> of an
    ///     <seealso cref="IGame" />, when the move just played is illegal.
    /// </summary>
    public class IllegalMoveUpdater : IStatusUpdater
    {
        /// <summary>
        ///     Updates the <seealso cref="IGame.Status" /> and <seealso cref="IGame.StatusReason" /> of an
        ///     <seealso cref="IGame" />, when the move just played is illegal.
        /// </summary>
        /// <param name="game">The <seealso cref="IGame" /> for which the status is to be updated.</param>
        public void UpdateStatus(IGame game)
        {
            // If less than 2 moves played
            if (game.Moves.Count <= 2)
                return;

            var lastPosition = game.Moves.Last().Position;
            var currentPosition = game.Position;

            // If check was ignored, illegal move
            var sideThatJustPlayed = lastPosition.SideToMove;
            var checkedNow = currentPosition.IsInCheck(sideThatJustPlayed);
            if (checkedNow)
            {
                game.Status = game.Position.SideToMove == Side.White ? Status.WhiteWon : Status.BlackWon;
                game.StatusReason = StatusReason.IllegalMove;
            }
        }
    }
}