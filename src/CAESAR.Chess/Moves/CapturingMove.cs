using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Moves
{
    /// <summary>
    ///     A capturing <seealso cref="NormalMove" /> where an <seealso cref="IPiece" /> is moved from a source
    ///     <seealso cref="ISquare" /> to a destination <seealso cref="ISquare" />, capturing the <seealso cref="IPiece" /> in
    ///     the destination <seealso cref="ISquare" />. It has additional rules whereby the
    ///     <seealso cref="IPosition.HalfMoveClock" /> and <seealso cref="IPosition.CastlingRights" /> may be set.
    /// </summary>
    public class CapturingMove : NormalMove
    {
        /// <summary>
        ///     Instantiates a <seealso cref="CapturingMove" /> with a source <seealso cref="ISquare" /> and a destination square
        ///     name.
        /// </summary>
        /// <param name="source">The <seealso cref="ISquare" /> in which the move originates.</param>
        /// <param name="destinationSquareName">The name of the destination square.</param>
        public CapturingMove(ISquare source, string destinationSquareName)
            : base(source, destinationSquareName)
        {
        }

        /// <summary>
        ///     Makes this <seealso cref="CapturingMove" /> on its <seealso cref="Move.Position" />.
        ///     <para>
        ///         It moves the piece from the source to the destination, removes the piece in the destination, and sets castling
        ///         rights and half move clock in the new position.
        ///     </para>
        /// </summary>
        /// <param name="position">The <seealso cref="IPosition" /> on which this <seealso cref="CapturingMove" /> is to be made.</param>
        /// <returns>A <seealso cref="IPosition" /> in which the current <seealso cref="CapturingMove" /> is already made.</returns>
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