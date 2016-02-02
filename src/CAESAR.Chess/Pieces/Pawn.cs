using CAESAR.Chess.Core;
using CAESAR.Chess.Moves.Generation;

namespace CAESAR.Chess.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Side side) : base(side, PieceType.Pawn, new PawnMovesGenerator())
        {
        }
        public override object Clone() => new Pawn(Side);
    }
}