using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Moves.Generation
{
    public abstract class MovesGenerator : IMovesGenerator
    {
        private IEnumerable<NormalMove> MovementMoves => MovementSquares.Distinct()
            .Where(square => square != null && square.Piece == null)
            .Select(square => new NormalMove(Square, square.Name));

        private IEnumerable<CapturingMove> Captures => CaptureSquares.Distinct()
            .Where(square => square?.Piece != null && square.Piece.Side != Piece.Side)
            .Select(square => new CapturingMove(Square, square.Name));

        protected abstract IEnumerable<IMove> SpecialMoves { get; }
        protected abstract IEnumerable<ISquare> MovementSquares { get; }
        protected abstract IEnumerable<ISquare> CaptureSquares { get; }

        protected IPiece Piece => Square?.Piece;
        protected Side Side => Piece.Side;

        public IEnumerable<IMove> Moves
            => Piece != null ? MovementMoves.Concat(Captures).Concat(SpecialMoves) : Enumerable.Empty<IMove>();

        public ISquare Square { get; set; }
    }
}