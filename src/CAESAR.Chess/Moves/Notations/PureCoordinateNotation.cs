using System.Linq;

namespace CAESAR.Chess.Moves.Notations
{
    /// <summary>
    ///     Pure Coordinate Notation (PCN) is a straight-forward chess notation to use only algebraic From- and To-coordinates.
    ///     This notation omits any machine redundant piece letters for the moving and/or capturing pieces, and only has to
    ///     specify the promoted piece as trailing letter in case of promotions.
    /// </summary>
    /// <example>e2e4, f7f8q</example>
    /// <remarks>https://chessprogramming.wikispaces.com/Algebraic+Chess+Notation#Pure%20coordinate%20notation</remarks>
    public class PureCoordinateNotation : INotation
    {
        public string ToString(IMove move)
        {
            return move.Source.Name + move.Destination.Name +
                   (move.MoveType == MoveType.Promotion
                       ? move.PromotionPiece.Notation.ToString().ToLowerInvariant().ToCharArray().First().ToString()
                       : "");
        }
    }
}