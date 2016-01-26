using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Moves.Generation
{
    public class PawnMovesGenerator : MovesGenerator
    {
        // TODO: Add Promotion, En Passant
        protected override IEnumerable<IMove> SpecialMoves => Enumerable.Empty<IMove>();

        // Safe to use "Piece" here, code only gets called when Piece != null in "IEnumerable<IMove> Moves" in base class
        protected override IEnumerable<ISquare> MovementSquares => GetPawnMovementSquares(Square, Piece.Side);
        protected override IEnumerable<ISquare> CaptureSquares => GetPawnCaptureSquares(Square, Piece.Side);
        private static IEnumerable<ISquare> GetPawnMovementSquares(ISquare square, Side side)
        {
            var direction = Direction.None;
            switch (side)
            {
                case Side.White:
                    direction = WhitePawnMovementDirection;
                    break;
                case Side.Black:
                    direction = BlackPawnMovementDirection;
                    break;
            }
            var movementSquare = square.GetAdjacentSquareInDirection(direction);
            yield return movementSquare;
            var isStartingRank = false;
            switch (side)
            {
                case Side.White:
                    isStartingRank = square.Rank.Number == 2;
                    break;
                case Side.Black:
                    isStartingRank = square.Rank.Number == 7;
                    break;
            }
            if (isStartingRank && movementSquare.Piece == null)
                yield return movementSquare.GetAdjacentSquareInDirection(direction);

        }

        private const Direction WhitePawnMovementDirection = Direction.Up;
        private const Direction BlackPawnMovementDirection = Direction.Down;

        private static readonly IEnumerable<Direction> WhitePawnCaptureDirections = new[]
        {Direction.UpRight, Direction.UpLeft};

        private static readonly IEnumerable<Direction> BlackPawnCaptureDirections = new[]
        {Direction.DownRight, Direction.DownLeft};


        private static IEnumerable<ISquare> GetPawnCaptureSquares(ISquare square, Side side)
        {
            var directions = Enumerable.Empty<Direction>();
            switch (side)
            {
                case Side.White:
                    directions = WhitePawnCaptureDirections;
                    break;
                case Side.Black:
                    directions = BlackPawnCaptureDirections;
                    break;
            }
            return directions.Select(square.GetAdjacentSquareInDirection);
        }
    }
}