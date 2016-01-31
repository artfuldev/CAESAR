using CAESAR.Chess.Core;
using CAESAR.Chess.Moves.Generation;

namespace CAESAR.Chess.Pieces
{
    public class Queen : Piece
    {
        public Queen(Side side) : base(side, PieceType.Queen, new QueenMovesGenerator())
        {
        }
    }
}