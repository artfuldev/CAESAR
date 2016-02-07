using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Moves
{
    /// <summary>
    ///     A special <seealso cref="PromotionMove" /> where the promotion is also a capture.
    /// </summary>
    public class CapturingPromotionMove : PromotionMove
    {
        /// <summary>
        ///     Instantiates a <seealso cref="CapturingPromotionMove" /> with a source <seealso cref="ISquare" />, a destination
        ///     square
        ///     name, and the <seealso cref="PieceType" /> to which the <seealso cref="Pawn" /> must be promoted.
        /// </summary>
        /// <param name="source">The <seealso cref="ISquare" /> in which the move originates.</param>
        /// <param name="destinationSquareName">The name of the destination square.</param>
        /// <param name="promotionPieceType">The <seealso cref="PieceType" /> to which the <seealso cref="Pawn" /> is promoted.</param>
        public CapturingPromotionMove(ISquare source, string destinationSquareName,
            PieceType promotionPieceType) : base(source, destinationSquareName, promotionPieceType)
        {
        }

        /// <summary>
        ///     Makes this <seealso cref="PromotionMove" /> on its <seealso cref="Move.Position" />.
        ///     <para>
        ///         It moves the <seealso cref="Pawn" /> from the source to the destination, sets castling rights, en passant
        ///         square, half move clock, etc. on the new position, and then it swaps the moved <seealso cref="Pawn" /> with a
        ///         new <seealso cref="IPiece" /> of the <seealso cref="PromotionMove.PromotionPieceType" />.
        ///     </para>
        /// </summary>
        /// <param name="position">The <seealso cref="IPosition" /> on which this <seealso cref="NormalMove" /> is to be made.</param>
        /// <returns>A <seealso cref="IPosition" /> in which the current <seealso cref="NormalMove" /> is already made.</returns>
        protected override IPosition MakeImplementation(IPosition position)
        {
            position = base.MakeImplementation(position);
            position.HalfMoveClock = 0;
            var square = Source.Board.GetSquare(DestinationSquareName);
            var destinationRank = Side == Side.White ? 1 : 8;
            var destinationSquares = new[] {"a" + destinationRank, "h" + destinationRank};
            var destinationSquare = Source.Board.GetSquare(DestinationSquareName);
            if (square.Piece.PieceType == PieceType.Rook && destinationSquares.Contains(DestinationSquareName))
            {
                if (Side == Side.White)
                {
                    if (destinationSquare.File.Name == 'a')
                        position.CastlingRights &= ~CastlingRights.WhiteLong;
                    if (destinationSquare.File.Name == 'h')
                        position.CastlingRights &= ~CastlingRights.WhiteShort;
                }
                if (Side == Side.Black)
                {
                    if (destinationSquare.File.Name == 'a')
                        position.CastlingRights &= ~CastlingRights.BlackLong;
                    if (destinationSquare.File.Name == 'h')
                        position.CastlingRights &= ~CastlingRights.BlackShort;
                }
            }
            return position;
        }
    }
}