using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Pieces;

namespace CAESAR.Chess.Positions
{
    /// <summary>
    ///     Useful extensions for an <seealso cref="IPosition" />.
    /// </summary>
    public static class PositionExtensions
    {
        /// <summary>
        ///     Calculates whether a given <seealso cref="Side" /> is in check, in a given <seealso cref="IPosition" />.
        /// </summary>
        /// <param name="position">The <seealso cref="IPosition" /> in which to calculate.</param>
        /// <param name="side">The <seealso cref="Side" /> for which to calculate.</param>
        /// <returns>
        ///     True if the given <seealso cref="side" /> is in check in the given <seealso cref="position" />, false
        ///     otherwise.
        /// </returns>
        public static bool IsInCheck(this IPosition position, Side side)
        {
            var opposingSide = side == Side.White ? Side.Black : Side.White;
            var opponentMoves =
                position.Board.Squares.Where(
                    square =>
                        square.HasPiece && square.Piece.Side == opposingSide && square.Piece.PieceType != PieceType.King)
                    .Select(square => square.Piece)
                    .SelectMany(piece => piece.Moves);

            // If king can be captured by opponent, current side is in check
            return opponentMoves.FirstOrDefault(x =>
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