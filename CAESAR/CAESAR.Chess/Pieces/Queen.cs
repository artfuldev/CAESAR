using System.Collections.Generic;

namespace CAESAR.Chess.Pieces
{
    public class Queen : Piece
    {
        public Queen(bool isWhite, ISquare square = null) : base(isWhite, "Queen", 'Q', square)
        {
        }

        protected override IEnumerable<IMove> GetMovesImplementation()
        {
            throw new System.NotImplementedException();
        }
    }
}