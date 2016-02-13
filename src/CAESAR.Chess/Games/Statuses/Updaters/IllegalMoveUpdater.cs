using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
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
            var currentPosition = game.Position;

            // If the number of kings is incorrect
            if (game.Position.Board.Squares.Count(x => x.HasPiece && x.Piece.PieceType == PieceType.King) != 2)
            {
                game.Status = currentPosition.SideToMove == Side.White ? Status.WhiteWon : Status.BlackWon;
                game.StatusReason = StatusReason.IllegalMove;
            }

            // If less than 2 moves played
            if (game.Moves.Count <= 2)
                return;

            var lastPosition = game.Moves.Last().Position;
            var sideThatJustPlayed = lastPosition.SideToMove;

            // If check was ignored, illegal move
            var checkedNow = currentPosition.IsInCheck(sideThatJustPlayed);
            if (checkedNow)
            {
                game.Status = currentPosition.SideToMove == Side.White ? Status.WhiteWon : Status.BlackWon;
                game.StatusReason = StatusReason.IllegalMove;
            }
        }
    }
}