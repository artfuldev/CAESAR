using CAESAR.Chess.Core;
using CAESAR.Chess.Moves.Generation;

namespace CAESAR.Chess.Pieces
{
    public class Rook : Piece
    {
        public Rook(Side side) : base(side, PieceType.Rook, new RookMovesGenerator())
        {
        }
        public override object Clone() => new Rook(Side);
    }
}