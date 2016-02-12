using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;

namespace CAESAR.Chess.Games.Statuses.Updaters
{
    public class InsufficientMatingMaterialUpdater : IStatusUpdater
    {
        /// <summary>
        ///     Updates the <seealso cref="IGame.Status" /> and <seealso cref="IGame.StatusReason" /> of an
        ///     <seealso cref="IGame" />, following the Insufficient Mating Material Rule (IMMR). This rule says the game is drawn
        ///     immediately if there is no way to end the game in <seealso cref="StatusReason.Checkmate" />.
        /// </summary>
        /// <param name="game">The <seealso cref="IGame" /> for which the status is to be updated.</param>
        public void UpdateStatus(IGame game)
        {
            // Refer http://www.e4ec.org/immr.html for cases
            var pieces = game.Position.Board.Squares.Where(x => x.HasPiece).Select(x => x.Piece).ToList();
            var whitePieces = pieces.Where(x => x.Side == Side.White).ToList();
            var blackPieces = pieces.Where(x => x.Side == Side.Black).ToList();

            // For cases 1-3
            var sideWithOnlyKing = whitePieces.Count == 1 && whitePieces.First().PieceType == PieceType.King
                ? Side.White
                : blackPieces.Count == 1 && blackPieces.First().PieceType == PieceType.King ? Side.Black : Side.None;

            if (sideWithOnlyKing != Side.None)
            {
                var otherSidePieces = sideWithOnlyKing == Side.White ? blackPieces : whitePieces;
                // Case 1 K vs K
                if (otherSidePieces.Count == 1 && otherSidePieces.First().PieceType == PieceType.King)
                {
                    SetGameDrawnByInsufficientMaterial(game);
                    return;
                }

                // Case 2 K vs KnB
                var otherSidePiecesExceptKing = otherSidePieces.Where(x => x.PieceType != PieceType.King).ToList();
                if (otherSidePiecesExceptKing.All(x => x.PieceType == PieceType.Bishop) &&
                    otherSidePiecesExceptKing.Select(x => x.Square.IsLight).Distinct().Count() == 1)
                {
                    SetGameDrawnByInsufficientMaterial(game);
                    return;
                }

                // Case 3 K vs KN
                if (otherSidePiecesExceptKing.Count == 1 &&
                    otherSidePiecesExceptKing.First().PieceType == PieceType.Knight)
                {
                    SetGameDrawnByInsufficientMaterial(game);
                    return;
                }
            }

            // Case 4
            var blackPiecesExceptKing = blackPieces.Where(x => x.PieceType != PieceType.King).ToList();
            var whitePiecesExceptKing = whitePieces.Where(x => x.PieceType != PieceType.King).ToList();

            if (blackPiecesExceptKing.All(x => x.PieceType == PieceType.Bishop) &&
                blackPiecesExceptKing.Select(x => x.Square.IsLight).Distinct().Count() == 1 &&
                whitePiecesExceptKing.All(x => x.PieceType == PieceType.Bishop) &&
                whitePiecesExceptKing.Select(x => x.Square.IsLight).Distinct().Count() == 1
                && blackPiecesExceptKing.First().Square.IsLight == whitePiecesExceptKing.First().Square.IsLight)
            {
                SetGameDrawnByInsufficientMaterial(game);
                return;
            }


            // TODO: Cases 5-7
        }

        /// <summary>
        ///     Sets the status of the specified <seealso cref="IGame" /> to <seealso cref="Status.Drawn" /> and the Status Reason
        ///     to <seealso cref="StatusReason.InsufficientMaterial" />.
        /// </summary>
        /// <param name="game">The <seealso cref="IGame" /> to update.</param>
        private static void SetGameDrawnByInsufficientMaterial(IGame game)
        {
            game.Status = Status.Drawn;
            game.StatusReason = StatusReason.InsufficientMaterial;
        }
    }
}