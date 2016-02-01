using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Moves.Generation
{
    public class PawnMovesGenerator : MovesGenerator
    {
        private const Direction WhitePawnMovementDirection = Direction.Up;
        private const Direction BlackPawnMovementDirection = Direction.Down;

        private static readonly IEnumerable<Direction> WhitePawnCaptureDirections = new[]
        {Direction.UpRight, Direction.UpLeft};

        private static readonly IEnumerable<Direction> BlackPawnCaptureDirections = new[]
        {Direction.DownRight, Direction.DownLeft};

        // TODO: Add En Passant
        protected override IEnumerable<IMove> SpecialMoves => GetSpecialMoves(Square, Piece.Side);
        // NOTE: Safe to use "Piece" here, code only gets called when Piece != null in "IEnumerable<IMove> Moves" in base class
        protected override IEnumerable<ISquare> MovementSquares => GetPawnMovementSquares(Square, Piece.Side);
        protected override IEnumerable<ISquare> CaptureSquares => GetPawnCaptureSquares(Square, Piece.Side);

        private static IEnumerable<IMove> GetSpecialMoves(ISquare square, Side side)
        {
            return GetPawnPromotionMoves(square, side)
                // En Passant Move
                .Concat(Enumerable.Empty<IMove>());
        } 

        private static IEnumerable<ISquare> GetPawnMovementSquares(ISquare square, Side side)
        {
            var promotionRankNumber = GetPromotionRankNumber(side);
            if (square.Rank.Number == promotionRankNumber)
                yield break;
            var direction = GetPawnMovementDirection(side);
            var movementSquare = square.GetAdjacentSquareInDirection(direction);
            yield return movementSquare;
            if (IsStartingRank(square, side) && movementSquare.Piece == null)
                yield return movementSquare.GetAdjacentSquareInDirection(direction);
        }

        private static Direction GetPawnMovementDirection(Side side)
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
            return direction;
        }

        private static bool IsStartingRank(ISquare square, Side side)
        {
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
            return isStartingRank;
        }


        private static IEnumerable<ISquare> GetPawnCaptureSquares(ISquare square, Side side)
        {
            return square.Rank.Number == GetPromotionRankNumber(side)
                ? Enumerable.Empty<ISquare>()
                : GetPawnCaptureDirections(side).Select(square.GetAdjacentSquareInDirection);
        }

        private static IEnumerable<Direction> GetPawnCaptureDirections(Side side)
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
            return directions;
        }

        private static IEnumerable<IMove> GetPawnPromotionMoves(ISquare square, Side side)
        {
            var promotionRankNumber = GetPromotionRankNumber(side);
            if (square.Rank.Number != promotionRankNumber)
                return Enumerable.Empty<IMove>();
            var eligibleSquares =
                // Capture Promotion
                GetPawnCaptureDirections(side)
                    .Select(square.GetAdjacentSquareInDirection)
                    .Where(x => x.HasPiece && x.Piece.Side != side).ToList();
            // Movement Promotion
            var movementSquare = square.GetAdjacentSquareInDirection(GetPawnMovementDirection(side));
            if (!movementSquare.HasPiece)
                eligibleSquares.Add(movementSquare);
            return eligibleSquares.SelectMany(destination => GetPromotionMoves(square, destination));
        }

        private static IEnumerable<IMove> GetPromotionMoves(ISquare square, ISquare destination)
        {
            var piece = square.Piece;
            var side = piece.Side;
            var promotionPieces = new List<IPiece>()
            {
                new Queen(side),
                new Rook(side),
                new Bishop(side),
                new Knight(side)
            };
            return promotionPieces.Select(promotionPiece => new Move(piece, destination, promotionPiece));
        } 

        private static int GetPromotionRankNumber(Side side)
        {
            var promotionRankNumber = 0;
            switch (side)
            {
                case Side.White:
                    promotionRankNumber = 7;
                    break;
                case Side.Black:
                    promotionRankNumber = 2;
                    break;
            }
            return promotionRankNumber;
        }
    }
}