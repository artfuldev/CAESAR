using System.Collections.Generic;
using CAESAR.Chess.Core;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.Moves.Generation;

namespace CAESAR.Chess.Pieces
{
    public class Bishop : Piece
    {
        private static readonly IEnumerable<Direction> Directions = new[]
        {
            Direction.UpRight,
            Direction.DownRight,
            Direction.DownLeft,
            Direction.UpLeft
        };

        public Bishop(Side side) : base(side, "Bishop", 'B', new BishopMovesGenerator())
        {
        }
    }
}