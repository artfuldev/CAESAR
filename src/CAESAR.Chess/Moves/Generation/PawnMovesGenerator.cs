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
        private static readonly IEnumerable<Direction> WhitePawnCaptureDirections = new[] {Direction.UpRight, Direction.UpLeft};

        private static readonly IEnumerable<Direction> BlackPawnCaptureDirections = new[] {Direction.DownRight, Direction.DownLeft};

        private static readonly char[] PromotionPieces = "QRBN".ToCharArray();

        // TODO: Add En Passant
        protected override IEnumerable<IMove> SpecialMoves
            => PromotionMoves().Concat(Enumerable.Empty<IMove>());
        protected override IEnumerable<ISquare> MovementSquares => PawnMovementSquares();
        protected override IEnumerable<ISquare> CaptureSquares => Square.Rank.Number == PromotionRankNumber
            ? Enumerable.Empty<ISquare>()
            : PawnCaptureDirections.Select(Square.GetAdjacentSquareInDirection);

        private IEnumerable<ISquare> PawnMovementSquares()
        {
            var promotionRankNumber = PromotionRankNumber;
            if (Square.Rank.Number == promotionRankNumber)
                yield break;
            var direction = PawnMovementDirection;
            var movementSquare = Square.GetAdjacentSquareInDirection(direction);
            yield return movementSquare;
            if (IsStartingRank && movementSquare.Piece == null)
                yield return movementSquare.GetAdjacentSquareInDirection(direction);
        }

        private Direction PawnMovementDirection
            => Side == Side.White ? Direction.Up : Side == Side.Black ? Direction.Down : Direction.None;

        private bool IsStartingRank => Side == Side.White? Square.Rank.Number == 7 : Side == Side.Black && Square.Rank.Number == 2;

        private IEnumerable<Direction> PawnCaptureDirections
            =>
                Side == Side.White
                    ? WhitePawnCaptureDirections
                    : Side == Side.Black ? BlackPawnCaptureDirections : Enumerable.Empty<Direction>();

        private IEnumerable<PromotionMove> PromotionMoves()
        {
            var promotionRankNumber = PromotionRankNumber;
            if (Square.Rank.Number != promotionRankNumber)
                return Enumerable.Empty<PromotionMove>();
            var eligibleSquares =
                // Capture Promotion
                PawnCaptureDirections
                    .Select(Square.GetAdjacentSquareInDirection)
                    .Where(x => x.HasPiece && x.Piece.Side != Side).ToList();
            // Movement Promotion
            var movementSquare = Square.GetAdjacentSquareInDirection(PawnMovementDirection);
            if (!movementSquare.HasPiece)
                eligibleSquares.Add(movementSquare);
            return eligibleSquares.SelectMany(GetPromotionMoves);
        }

        private IEnumerable<PromotionMove> GetPromotionMoves(ISquare destination)
        {
            return
                PromotionPieces.Select(
                    promotionPiece =>
                        destination.HasPiece
                            ? new CapturingPromotionMove(Piece.Side, Square.Name, destination.Name,
                                promotionPiece)
                            : new PromotionMove(Piece.Side, Square.Name, destination.Name,
                                promotionPiece));
        }

        private int PromotionRankNumber => Side == Side.White ? 7 : Side == Side.Black ? 2 : 0;
    }
}