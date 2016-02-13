using System;
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
            var board = position.Board;
            var squares = board.Squares;
            var thisKingSquare =
                squares.FirstOrDefault(
                    square => square.HasPiece && square.Piece.PieceType == PieceType.King && square.Piece.Side == side);
            if (thisKingSquare == null)
                throw new InvalidOperationException("King of this side cannot be found on the board");

            var squaresThreatenedByOpponent =
                squares.Where(square => square.HasPiece && square.Piece.Side == opposingSide)
                    .Select(square => square.Piece)
                    .SelectMany(piece => piece.ThreatenedSquareNames)
                    .Select(squareName => board.GetSquare(squareName))
                    .Where(square => square != null);
            return squaresThreatenedByOpponent.Contains(thisKingSquare);
        }
    }
}