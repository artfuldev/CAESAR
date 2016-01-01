using System.Collections.Generic;
using CAESAR.Chess.Helpers;

namespace CAESAR.Chess.Pieces
{
    public class Knight : Piece
    {
        public Knight(bool isWhite, ISquare square = null) : base(isWhite, "Knight", 'N', square)
        {
        }
        protected override IEnumerable<ISquare> EligibleSquares => Square.GetKnightSquares();
    }
}