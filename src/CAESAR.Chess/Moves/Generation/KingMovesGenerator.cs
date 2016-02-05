using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Moves.Generation
{
    public class KingMovesGenerator : MovesGenerator
    {
        private static readonly IEnumerable<Direction> Directions = new[]
        {
            Direction.Up,
            Direction.UpRight,
            Direction.Right,
            Direction.DownRight,
            Direction.Down,
            Direction.DownLeft,
            Direction.Left,
            Direction.UpLeft
        };

        protected override IEnumerable<IMove> SpecialMoves => GetCastlingMoves();

        private IEnumerable<CastlingMove> GetCastlingMoves()
        {
            var board = Square.Board;
            var position = board.Position;
            var availability = position.CastlingRights;
            if (availability == CastlingRights.None)
                yield break;
            if (position.IsInCheck(Side))
                yield break;
            if (Side == Side.White)
            {
                if (availability.HasFlag(CastlingRights.WhiteShort) && board.GetSquare("f1").IsEmpty &&
                    board.GetSquare("g1").IsEmpty)
                    yield return new CastlingMove(Square, CastlingType.Kingside);
                if (availability.HasFlag(CastlingRights.WhiteLong) && board.GetSquare("b1").IsEmpty &&
                    board.GetSquare("c1").IsEmpty && board.GetSquare("d1").IsEmpty)
                    yield return new CastlingMove(Square, CastlingType.Queenside);
                yield break;
            }
            if (Side == Side.Black)
            {
                if (availability.HasFlag(CastlingRights.BlackShort) && board.GetSquare("f8").IsEmpty &&
                    board.GetSquare("g8").IsEmpty)
                    yield return new CastlingMove(Square, CastlingType.Kingside);
                if (availability.HasFlag(CastlingRights.BlackLong) && board.GetSquare("b8").IsEmpty &&
                    board.GetSquare("c8").IsEmpty && board.GetSquare("d8").IsEmpty)
                    yield return new CastlingMove(Square, CastlingType.Queenside);
                yield break;
            }
        }

        protected override IEnumerable<ISquare> MovementSquares
            => Directions.Select(Square.GetAdjacentSquareInDirection);

        protected override IEnumerable<ISquare> CaptureSquares
            => Directions.Select(Square.GetAdjacentSquareInDirection);
    }
}