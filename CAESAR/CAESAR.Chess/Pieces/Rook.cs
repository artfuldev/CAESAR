using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Helpers;

namespace CAESAR.Chess.Pieces
{
    public class Rook : Piece
    {
        public Rook(bool isWhite) : base(isWhite, "Rook", 'R')
        {
        }

        private static readonly IEnumerable<Direction> Directions = new[]
        {
            Direction.Up,
            Direction.Right,
            Direction.Down,
            Direction.Left
        };

        protected override IEnumerable<ISquare> MovementSquares
            => Directions.SelectMany(direction => Square.GetAdjacentSquaresInDirectionTillNonEmptySquare(direction));

        protected override IEnumerable<ISquare> CaptureSquares => MovementSquares;
    }
}