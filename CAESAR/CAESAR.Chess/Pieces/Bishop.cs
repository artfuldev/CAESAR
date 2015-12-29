using System.Collections.Generic;

namespace CAESAR.Chess.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(bool isWhite, ISquare square = null) : base(isWhite, "Bishop", 'B', square)
        {
        }

        protected override IEnumerable<IMove> GetMovesImplementation()
        {
            throw new System.NotImplementedException();
        }
    }
}