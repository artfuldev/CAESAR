using CAESAR.Chess.Core;
using CAESAR.Chess.Moves.Generation;

namespace CAESAR.Chess.Pieces
{
    public class Knight : Piece
    {
        public Knight(Side side) : base(side, "Knight", 'N', new KnightMovesGenerator())
        {
        }
    }
}