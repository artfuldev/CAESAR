using System.Linq;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Games.Statuses.Updaters
{
    /// <summary>
    ///     Updates the <seealso cref="IGame.Status" /> and <seealso cref="IGame.StatusReason" /> of an
    ///     <seealso cref="IGame" />, if the game is drawn by threefold repetition
    ///     (https://en.wikipedia.org/wiki/Threefold_repetition).
    /// </summary>
    public class ThreefoldRepetitionUpdater : IStatusUpdater
    {
        /// <summary>
        ///     Updates the <seealso cref="IGame.Status" /> and <seealso cref="IGame.StatusReason" /> of an
        ///     <seealso cref="IGame" />, if the game is drawn by threefold repetition
        ///     (https://en.wikipedia.org/wiki/Threefold_repetition).
        /// </summary>
        /// <param name="game">The <seealso cref="IGame" /> for which the status is to be updated.</param>
        public void UpdateStatus(IGame game)
        {
            var lastPosition = game.Position;
            var previousPositions = game.Moves.Select(move => move.Position).ToArray();
            if (previousPositions.Count(position => IsRepeatPosition(lastPosition, position)) != 3)
                return;
            game.Status = Status.Drawn;
            game.StatusReason = StatusReason.ThreefoldRepetition;
        }

        /// <summary>
        ///     Determines if a position is the repeat of another position by comparing some characteristics of its FEN string
        ///     representation.
        /// </summary>
        /// <param name="basePosition">The <seealso cref="IPosition" /> which is the basis for comparison.</param>
        /// <param name="position">
        ///     The <seealso cref="IPosition" /> which is to be compared to the base
        ///     <seealso cref="IPosition" />.
        /// </param>
        /// <returns></returns>
        private static bool IsRepeatPosition(IPosition basePosition, IPosition position)
        {
            var baseFen = basePosition.ToFenString();
            var fen = position.ToFenString();
            return baseFen.EnPassantTargetSquare == fen.EnPassantTargetSquare &&
                   baseFen.CastlingAvailablity == fen.CastlingAvailablity &&
                   baseFen.PiecePlacement == fen.PiecePlacement;
        }
    }
}