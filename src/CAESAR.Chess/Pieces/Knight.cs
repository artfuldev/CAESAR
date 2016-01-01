using System.Collections.Generic;
using CAESAR.Chess.Helpers;

namespace CAESAR.Chess.Pieces
{
    public class Knight : Piece
    {
        public Knight(bool isWhite) : base(isWhite, "Knight", 'N')
        {
        }
        protected override IEnumerable<ISquare> MovementSquares => Square.GetKnightSquares();
        protected override IEnumerable<ISquare> CaptureSquares => MovementSquares;
    }
}