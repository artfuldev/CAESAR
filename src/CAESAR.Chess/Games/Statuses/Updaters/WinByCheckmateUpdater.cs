using System.Linq;
using CAESAR.Chess.Core;

namespace CAESAR.Chess.Games.Statuses.Updaters
{
    public class WinByCheckmateUpdater : IStatusUpdater
    {
        public void UpdateStatus(IGame game)
        {
            if (!game.CurrentSideInCheck || game.CurrentPlayer.GetAllMoves(game.Board).Any()) return;
            game.Status = game.SideToPlay == Side.White ? Status.BlackWon : Status.WhiteWon;
            game.StatusReason = StatusReason.Checkmate;
        }
    }
}