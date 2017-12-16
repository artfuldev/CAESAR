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
                return;
            }

            var sideToMove = currentPosition.SideToMove;
            var otherSide = sideToMove == Side.White ? Side.Black : Side.White;

            // If check was ignored, illegal move
            var checkedNow = currentPosition.IsInCheck(otherSide);
            if (checkedNow)
            {
                game.Status = currentPosition.SideToMove == Side.White ? Status.WhiteWon : Status.BlackWon;
                game.StatusReason = StatusReason.IllegalMove;
            }
        }
    }
}