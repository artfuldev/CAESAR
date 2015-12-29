using System.Collections.Generic;

namespace CAESAR.Chess.Pieces
{
    public class Knight : Piece
    {
        public Knight(bool isWhite, ISquare square = null) : base(isWhite, "Knight", 'N', square)
        {
        }

        public override IEnumerable<IMove> GetMoves()
        {
            throw new System.NotImplementedException();
        }
    }
}