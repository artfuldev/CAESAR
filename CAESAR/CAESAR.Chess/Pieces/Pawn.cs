using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Helpers;

namespace CAESAR.Chess.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(bool isWhite) : base(isWhite, "Pawn", 'P')
        {
        }

        protected override IEnumerable<ISquare> MovementSquares => Square.GetPawnMovementSquares(IsWhite);
        protected override IEnumerable<ISquare> CaptureSquares => Square.GetPawnCaptureSquares(IsWhite);
    }
}