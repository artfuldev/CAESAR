using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Helpers;

namespace CAESAR.Chess.Moves.Generation
{
    public class PawnMovesGenerator : MovesGenerator
    {
        // TODO: Add Promotion, En Passant
        protected override IEnumerable<IMove> SpecialMoves => Enumerable.Empty<IMove>();

        // Safe to use "Piece" here, code only gets called when Piece != null in "IEnumerable<IMove> Moves" in base class
        protected override IEnumerable<ISquare> MovementSquares => Square.GetPawnMovementSquares(Piece.IsWhite);
        protected override IEnumerable<ISquare> CaptureSquares => Square.GetPawnCaptureSquares(Piece.IsWhite);
    }
}