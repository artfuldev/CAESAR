using CAESAR.Chess.Core;
using CAESAR.Chess.Moves.Generation;

namespace CAESAR.Chess.Pieces
{
    public class Knight : Piece
    {
        public Knight(Side side) : base(side, PieceType.Knight, new KnightMovesGenerator())
        {
        }
        public override object Clone() => new Knight(Side);
    }
}