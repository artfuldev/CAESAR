using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Helpers;

namespace CAESAR.Chess.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(bool isWhite) : base(isWhite, "Bishop", 'B')
        {
        }

        private static readonly IEnumerable<Direction> Directions = new[]
        {
            Direction.UpRight,
            Direction.DownRight,
            Direction.DownLeft,
            Direction.UpLeft
        };

        protected override IEnumerable<ISquare> MovementSquares
            => Directions.SelectMany(direction => Square.GetAdjacentSquaresInDirectionTillNonEmptySquare(direction));

        protected override IEnumerable<ISquare> CaptureSquares => MovementSquares;
    }
}