using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Moves.Generation
{
    public abstract class MovesGenerator : IMovesGenerator
    {
        private IEnumerable<IMove> MovementMoves => MovementSquares.Distinct()
            .Where(square => square != null && square.Piece == null)
            .Select(square => new Move(Piece, square));

        private IEnumerable<IMove> Captures => CaptureSquares.Distinct()
            .Where(square => square?.Piece != null && square.Piece.Side != Piece.Side)
            .Select(square => new Move(Piece, square));

        protected abstract IEnumerable<IMove> SpecialMoves { get; }
        protected abstract IEnumerable<ISquare> MovementSquares { get; }
        protected abstract IEnumerable<ISquare> CaptureSquares { get; }

        protected IPiece Piece => Square?.Piece;

        public IEnumerable<IMove> Moves
            => Piece != null ? MovementMoves.Concat(Captures).Concat(SpecialMoves) : Enumerable.Empty<IMove>();

        public ISquare Square { protected get; set; }
    }
}