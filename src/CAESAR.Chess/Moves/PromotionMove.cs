using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Moves
{
    /// <summary>
    ///     A special <seealso cref="NormalMove" /> where a <seealso cref="Pawn" /> is moved from a source
    ///     <seealso cref="ISquare" /> to a destination promotion <seealso cref="ISquare" /> at the end of the board, promoting
    ///     to a specified <seealso cref="PieceType" />.
    /// </summary>
    public class PromotionMove : NormalMove
    {
        /// <summary>
        ///     Instantiates a <seealso cref="PromotionMove" /> with a source <seealso cref="ISquare" />, a destination square
        ///     name, and the <seealso cref="PieceType" /> to which the <seealso cref="Pawn" /> must be promoted.
        /// </summary>
        /// <param name="source">The <seealso cref="ISquare" /> in which the move originates.</param>
        /// <param name="destinationSquareName">The name of the destination square.</param>
        /// <param name="promotionPieceType">The <seealso cref="PieceType" /> to which the <seealso cref="Pawn" /> is promoted.</param>
        public PromotionMove(ISquare source, string destinationSquareName, PieceType promotionPieceType)
            : base(source, destinationSquareName)
        {
            PromotionPieceType = promotionPieceType;
            MoveString = SourceSquareName + DestinationSquareName + PromotionPieceType.GetNotation();
        }

        /// <summary>
        ///     The <seealso cref="PieceType" /> to which the <seealso cref="Pawn" /> is to be promoted upon playing this
        ///     <seealso cref="PromotionMove" />.
        /// </summary>
        public PieceType PromotionPieceType { get; }

        /// <summary>
        ///     Makes this <seealso cref="PromotionMove" /> on its <seealso cref="Move.Position" />.
        ///     <para>
        ///         It moves the <seealso cref="Pawn" /> from the source to the destination, sets castling rights, en passant
        ///         square, half move clock, etc. on the new position, and then it swaps the moved <seealso cref="Pawn" /> with a
        ///         new <seealso cref="IPiece" /> of the <seealso cref="PromotionPieceType" />.
        ///     </para>
        /// </summary>
        /// <param name="position">The <seealso cref="IPosition" /> on which this <seealso cref="PromotionMove" /> is to be made.</param>
        /// <returns>A <seealso cref="IPosition" /> in which the current <seealso cref="PromotionMove" /> is already made.</returns>
        protected override IPosition MakeImplementation(IPosition position)
        {
            position = base.MakeImplementation(position);
            var destinationSquare = position.Board.GetSquare(DestinationSquareName);
            destinationSquare.Piece = PromotionPieceType.GetPiece(Side);
            return position;
        }
    }
}