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
            var availability = Square.Board.Position.CastlingRights;
            if (availability == CastlingRights.None)
                yield break;
            if (Side == Side.White)
            {
                if(availability.HasFlag(CastlingRights.WhiteShort))
                    yield return new CastlingMove(Square, CastlingType.Kingside);
                if (availability.HasFlag(CastlingRights.WhiteLong))
                    yield return new CastlingMove(Square, CastlingType.Queenside);
                yield break;
            }
            if (Side == Side.Black)
            {
                if (availability.HasFlag(CastlingRights.BlackShort))
                    yield return new CastlingMove(Square, CastlingType.Kingside);
                if (availability.HasFlag(CastlingRights.BlackLong))
                    yield return new CastlingMove(Square, CastlingType.Queenside);
            }
        } 

        protected override IEnumerable<ISquare> MovementSquares
            => Directions.Select(Square.GetAdjacentSquareInDirection);

        protected override IEnumerable<ISquare> CaptureSquares
            => Directions.Select(Square.GetAdjacentSquareInDirection);
    }
}