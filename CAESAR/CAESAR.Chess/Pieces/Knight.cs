using System.Collections.Generic;

namespace CAESAR.Chess.Pieces
{
    public class Knight : Piece
    {
        public Knight(bool isWhite, ISquare square = null) : base(isWhite, "Knight", 'N', square)
        {
        }

        protected override IEnumerable<IMove> GetMovesImplementation()
        {
            throw new System.NotImplementedException();
        }
    }
}