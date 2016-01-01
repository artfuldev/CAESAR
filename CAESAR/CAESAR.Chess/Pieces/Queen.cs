using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.Implementation;

namespace CAESAR.Chess.Pieces
{
    public class Queen : Piece
    {
        public Queen(bool isWhite, ISquare square = null) : base(isWhite, "Queen", 'Q', square)
        {
        }

        private static readonly IEnumerable<Direction> Directions = new[]
        {
            Direction.Up,
            Direction.UpRight,
            Direction.Right,
            Direction.DownRight,
            Direction.Down,
            Direction.DownLeft,
            Direction.Left,
            Direction.UpLeft
        };

        protected override IEnumerable<ISquare> EligibleSquares
            => Directions.SelectMany(direction => Square.GetAdjacentSquaresInDirectionTillNonEmptySquare(direction));
    }
}