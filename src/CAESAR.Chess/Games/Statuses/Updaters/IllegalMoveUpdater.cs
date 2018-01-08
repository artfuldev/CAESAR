using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves;
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
            var playedSide = sideToMove == Side.White ? Side.Black : Side.White;

            // If check was ignored, illegal move
            var checkedNow = currentPosition.IsInCheck(playedSide);
            if (checkedNow)
            {
                game.Status = currentPosition.SideToMove == Side.White ? Status.WhiteWon : Status.BlackWon;
                game.StatusReason = StatusReason.IllegalMove;
                return;
            }

            // If a castle was made when not allowed
            var lastMove = game.Moves.Last();
            if (lastMove is CastlingMove move && !HasCastlingRights(move.Position, playedSide, move.CastleSide))
            {
                game.Status = currentPosition.SideToMove == Side.White ? Status.WhiteWon : Status.BlackWon;
                game.StatusReason = StatusReason.IllegalMove;
                return;
            }
        }

        private static bool HasCastlingRights(IPosition position, Side side, CastleSide castleSide)
        {
            var castlingRights = position.CastlingRights;
            switch (castleSide)
            {
                case CastleSide.King:
                    switch (side)
                    {
                        case Side.Black:
                            return castlingRights.HasFlag(CastlingRights.BlackShort);
                        case Side.White:
                            return castlingRights.HasFlag(CastlingRights.WhiteShort);
                        default:
                            return false;
                    }
                case CastleSide.Queen:
                    switch(side)
                    {
                        case Side.Black:
                            return castlingRights.HasFlag(CastlingRights.BlackLong);
                        case Side.White:
                            return castlingRights.HasFlag(CastlingRights.WhiteLong);
                        default:
                            return false;
                    }
                default:
                    return false;
            }
        }
    }
}