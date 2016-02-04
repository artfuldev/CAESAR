using System.Linq;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Games.Statuses.Updaters
{
    public class ThreefoldRepetitionUpdater : IStatusUpdater
    {
        public void UpdateStatus(IGame game)
        {
            var lastPosition = game.Position.ToFenString();
            var previousPositions = game.Moves.Select(move => move.Position.ToFenString()).ToArray();
            if (previousPositions.Count(position => IsRepeatPosition(lastPosition, position)) != 3)
                return;
            game.Status = Status.Drawn;
            game.StatusReason = StatusReason.ThreefoldRepetition;
        }

        private static bool IsRepeatPosition(FenString left, FenString right)
        {
            return left.EnPassantTargetSquare == right.EnPassantTargetSquare &&
                   left.CastlingAvailablity == right.CastlingAvailablity &&
                   left.PiecePlacement == right.PiecePlacement;
        }
    }
}