using System.Collections.Generic;

namespace CAESAR.Chess.Pieces
{
    public class King : Piece
    {
        public King(bool isWhite, ISquare square = null) : base(isWhite, "King", 'K', square)
        {
        }

        public override IEnumerable<IMove> GetMoves()
        {
            throw new System.NotImplementedException();
        }
    }
}