using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Implementation;
using CAESAR.Chess.Pieces;

namespace CAESAR.Chess.Moves.Generation
{
    public abstract class MovesGenerator : IMovesGenerator
    {
        private IEnumerable<IMove> MovementMoves => MovementSquares.Distinct()
            .Where(square => square != null && square.Piece == null)
            .Select(square => new Move(Piece, square));

        private IEnumerable<IMove> Captures => CaptureSquares.Distinct()
            .Where(square => square?.Piece != null && square.Piece.IsWhite != Piece.IsWhite)
            .Select(square => new Move(Piece, square, MoveType.Capture));

        protected abstract IEnumerable<IMove> SpecialMoves { get; }
        protected abstract IEnumerable<ISquare> MovementSquares { get; }
        protected abstract IEnumerable<ISquare> CaptureSquares { get; }

        public IEnumerable<IMove> Moves
            => Piece != null ? MovementMoves.Concat(Captures).Concat(SpecialMoves) : Enumerable.Empty<IMove>();

        public ISquare Square { get; set; }

        public IPiece Piece => Square?.Piece;
    }
}