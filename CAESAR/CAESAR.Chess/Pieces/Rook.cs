using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Helpers;

namespace CAESAR.Chess.Pieces
{
    public class Rook : Piece
    {
        public Rook(bool isWhite, ISquare square = null) : base(isWhite, "Rook", 'R', square)
        {
        }

        private static readonly IEnumerable<Direction> Directions = new[]
        {
            Direction.Up,
            Direction.Right,
            Direction.Down,
            Direction.Left
        };

        protected override IEnumerable<ISquare> EligibleSquares
            => Directions.SelectMany(direction => Square.GetAdjacentSquaresInDirectionTillNonEmptySquare(direction));
    }
}