using System.Collections.Generic;

namespace CAESAR.Chess.Pieces
{
    public class Rook : Piece
    {
        public Rook(bool isWhite, ISquare square = null) : base(isWhite, "Rook", 'R', square)
        {
        }

        protected override IEnumerable<IMove> GetMovesImplementation()
        {
            throw new System.NotImplementedException();
        }
    }
}