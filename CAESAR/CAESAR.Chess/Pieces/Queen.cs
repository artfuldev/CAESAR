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
            var eligibleSquares = Directions
                .SelectMany(direction =>
                    Square.GetAdjacentSquaresInDirection(direction)
                        .Where(square => square != null)
                        .TakeWhile(square => square.Piece == null)
                        .Concat(Square.GetAdjacentSquaresInDirection(direction)
                            .SkipWhile(square => square != null)
                            .Take(1).Where(square => square.Piece.IsWhite != IsWhite)));
            return eligibleSquares.Select(square => new Move(this, square));
        }
    }
}