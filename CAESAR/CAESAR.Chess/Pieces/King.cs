using System.Collections.Generic;

namespace CAESAR.Chess.Pieces
{
    public class King : Piece
    {
        public King(bool isWhite, ISquare square = null) : base(isWhite, "King", 'K', square)
        {
        }

        protected override IEnumerable<IMove> GetMovesImplementation()
        {
            throw new System.NotImplementedException();
        }
    }
}