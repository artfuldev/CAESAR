using CAESAR.Chess.Core;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.Players;
using System.Linq;

namespace CAESAR.Chess.Positions
{
    public static class PositionExtensions
    {
        public static bool IsInCheck(this IPosition position, Side side)
        {
            var player = new Player() {Side = side == Side.White ? Side.Black : Side.White};

            // If king can be captured by opponent, current side is in check
            return player.GetAllMoves(position).FirstOrDefault(x =>
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