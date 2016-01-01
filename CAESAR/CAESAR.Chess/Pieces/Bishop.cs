using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Helpers;

namespace CAESAR.Chess.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(bool isWhite, ISquare square = null) : base(isWhite, "Bishop", 'B', square)
        {
        }

        private static readonly IEnumerable<Direction> Directions = new[]
        {
            Direction.UpRight,
            Direction.DownRight,
            Direction.DownLeft,
            Direction.UpLeft
        };

        protected override IEnumerable<ISquare> EligibleSquares
            => Directions.SelectMany(direction => Square.GetAdjacentSquaresInDirectionTillNonEmptySquare(direction));
    }
}