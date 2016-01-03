using System.Collections.Generic;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.Moves.Generation;

namespace CAESAR.Chess.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(bool isWhite) : base(isWhite, "Bishop", 'B', new BishopMovesGenerator())
        {
        }

        private static readonly IEnumerable<Direction> Directions = new[]
        {
            Direction.UpRight,
            Direction.DownRight,
            Direction.DownLeft,
            Direction.UpLeft
        };
    }
}