using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.Implementation;

namespace CAESAR.Chess.Pieces
{
    public class King : Piece
    {
        public King(bool isWhite, ISquare square = null) : base(isWhite, "King", 'K', square)
        {
        }
        private static readonly IEnumerable<Direction> Directions = new Direction[]
        {
            Direction.Up,
            Direction.Right,
            Direction.Down, 
            Direction.Left,
            Direction.UpRight,
            Direction.DownRight,
            Direction.DownLeft,
            Direction.UpLeft
        };
        protected override IEnumerable<IMove> GetMovesImplementation()
        {
            var allSquares = Directions.Select(direction => Square.GetAdjacentSquareInDirection(direction)).Where(square => square != null);
            var eligibleSquares = allSquares.Where(x => x.Piece == null || x.Piece.IsWhite != IsWhite);
            return eligibleSquares.Select(square => new Move(this, square));
        }
    }
}