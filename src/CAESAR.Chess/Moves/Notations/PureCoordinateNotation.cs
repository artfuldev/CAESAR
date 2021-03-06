﻿using CAESAR.Chess.Pieces;

namespace CAESAR.Chess.Moves.Notations
{
    /// <summary>
    ///     Pure Coordinate Notation (PCN) is a straight-forward chess notation to use only algebraic From- and To-coordinates.
    ///     This notation omits any machine redundant piece letters for the moving and/or capturing pieces, and only has to
    ///     specify the promoted piece as trailing letter in case of promotions.
    /// </summary>
    /// <example>e2e4, f7f8Q</example>
    /// <remarks>https://chessprogramming.wikispaces.com/Algebraic+Chess+Notation#Pure%20coordinate%20notation</remarks>
    public class PureCoordinateNotation : INotation
    {
        /// <summary>
        ///     Gets the string representation of the <seealso cref="IMove" /> in <seealso cref="PureCoordinateNotation" />.
        /// </summary>
        /// <param name="move">The <seealso cref="IMove" /> for which the notation is required.</param>
        /// <returns>The string representation of the <seealso cref="IMove" /> in <seealso cref="PureCoordinateNotation" />.</returns>
        public string ToString(IMove move)
        {
            var normalMove = move as NormalMove;
            if (normalMove == null)
                return null;
            var promotionMove = move as PromotionMove;
            return normalMove.SourceSquareName + normalMove.DestinationSquareName +
                   promotionMove?.PromotionPieceType.GetNotation();
        }
    }
}