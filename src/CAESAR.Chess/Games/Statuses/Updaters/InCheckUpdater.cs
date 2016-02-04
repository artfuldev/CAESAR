using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Pieces;

namespace CAESAR.Chess.Games.Statuses.Updaters
{
    public class InCheckUpdater : IStatusUpdater
    {
        public void UpdateStatus(IGame game)
        {
            // If king can be captured by opponent, current side is in check
            game.CurrentSideInCheck = game.CurrentOpponent.GetAllMoves(game.Position).FirstOrDefault(x =>
            {
                var normalMove = x as NormalMove;
                if (normalMove == null)
                    return false;
                var square = x.Position.Board.GetSquare(normalMove.DestinationSquareName);
                if (square == null)
                    return false;
                return square.HasPiece && square.Piece.PieceType == PieceType.King;
            }) != null;
        }
    }
}