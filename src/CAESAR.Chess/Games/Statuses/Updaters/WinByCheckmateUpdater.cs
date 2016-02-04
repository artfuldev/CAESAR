using System.Linq;
using CAESAR.Chess.Core;

namespace CAESAR.Chess.Games.Statuses.Updaters
{
    public class WinByCheckmateUpdater : IStatusUpdater
    {
        public void UpdateStatus(IGame game)
        {
            if (!game.CurrentSideInCheck || game.CurrentPlayer.GetAllMoves(game.Position).Any()) return;
            game.Status = game.Position.SideToMove == Side.White ? Status.BlackWon : Status.WhiteWon;
            game.StatusReason = StatusReason.Checkmate;
        }
    }
}