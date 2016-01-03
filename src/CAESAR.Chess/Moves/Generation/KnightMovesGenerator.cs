using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Helpers;

namespace CAESAR.Chess.Moves.Generation
{
    public class KnightMovesGenerator : MovesGenerator
    {
        protected override IEnumerable<IMove> SpecialMoves => Enumerable.Empty<IMove>();
        protected override IEnumerable<ISquare> MovementSquares => Square.GetKnightSquares();
        protected override IEnumerable<ISquare> CaptureSquares => MovementSquares;
    }
}