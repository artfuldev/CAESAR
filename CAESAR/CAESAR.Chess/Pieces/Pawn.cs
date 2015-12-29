using System.Collections.Generic;

namespace CAESAR.Chess.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(bool isWhite, ISquare square = null) : base(isWhite, "Pawn", 'P', square)
        {
        }

        public override IEnumerable<IMove> GetMoves()
        {
            throw new System.NotImplementedException();
        }
    }
}