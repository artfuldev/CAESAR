using System.Collections.Generic;

namespace CAESAR.Chess.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(bool isWhite, ISquare square = null) : base(isWhite, "Pawn", 'P', square)
        {
        }

        protected override IEnumerable<IMove> GetMovesImplementation()
        {
            throw new System.NotImplementedException();
        }
    }
}