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
            var movesToConsider =
                position.Board.Squares.Where(
                    square => square.HasPiece && square.Piece.Side == side && square.Piece.PieceType != PieceType.King)
                    .Select(square => square.Piece)
                    .SelectMany(piece => piece.Moves);

            // If king can be captured by opponent, current side is in check
            return movesToConsider.FirstOrDefault(x =>
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