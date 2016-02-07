using CAESAR.Chess.Core;
using CAESAR.Chess.Moves.Exceptions;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Moves
{
    /// <summary>
    ///     A normal <seealso cref="Move" /> where an <seealso cref="IPiece" /> is moved from a source
    ///     <seealso cref="ISquare" /> to a destination <seealso cref="ISquare" />. It has additional rules whereby some
    ///     properties of the <seealso cref="IMove.Position" /> may be set.
    /// </summary>
    public class NormalMove : Move
    {
        /// <summary>
        ///     Instantiates a <seealso cref="NormalMove" /> with a source <seealso cref="ISquare" /> and a destination square
        ///     name.
        /// </summary>
        /// <param name="source">The <seealso cref="ISquare" /> in which the move originates.</param>
        /// <param name="destinationSquareName">The name of the destination square.</param>
        public NormalMove(ISquare source, string destinationSquareName)
            : base(source.Board.Position, source.Piece.Side, source.Name + destinationSquareName)
        {
            Source = Position.Board.GetSquare(source.Name);
            SourceSquareName = source.Name;
            Piece = source.Piece;
            DestinationSquareName = destinationSquareName;
        }

        /// <summary>
        ///     The name of the source <seealso cref="ISquare" />.
        /// </summary>
        public string SourceSquareName { get; }

        /// <summary>
        ///     The name of the destination <seealso cref="ISquare" />.
        /// </summary>
        public string DestinationSquareName { get; }

        /// <summary>
        ///     The source <seealso cref="ISquare" />.
        /// </summary>
        public ISquare Source { get; }

        /// <summary>
        ///     The <seealso cref="IPiece" /> in the <seealso cref="Source" />.
        /// </summary>
        public IPiece Piece { get; }

        /// <summary>
        ///     Makes this <seealso cref="NormalMove" /> on its <seealso cref="Move.Position" />.
        ///     <para>
        ///         It moves the piece from the source to the destination, sets castling rights, en passant square, half move
        ///         clock, etc. on the new position.
        ///     </para>
        /// </summary>
        /// <param name="position">The <seealso cref="IPosition" /> on which this <seealso cref="NormalMove" /> is to be made.</param>
        /// <returns>A <seealso cref="IPosition" /> in which the current <seealso cref="NormalMove" /> is already made.</returns>
        protected override IPosition MakeImplementation(IPosition position)
        {
            var source = position.Board.GetSquare(SourceSquareName);
            if (source.IsEmpty)
                throw new CannotMakeMoveException(MoveOperationFailureReason.SourceSquareIsEmpty);
            var destination = position.Board.GetSquare(DestinationSquareName);
            source.Piece = null;
            destination.Piece = Piece;

            // 50 Move Rule
            if (Piece.PieceType == PieceType.Pawn)
                position.HalfMoveClock = 0;
            else
                position.HalfMoveClock++;

            // Set En-Passant Square
            // If piece is pawn
            if (Piece.PieceType == PieceType.Pawn &&
                // and pawn moves from rank 2 to rank 4 if white
                ((SourceSquareName.EndsWith("2") && Side == Side.White &&
                  (DestinationSquareName == source.File.Name.ToString() + 4)) ||
                 // or from rank 7 to rank 5 if black
                 (SourceSquareName.EndsWith("7") && Side == Side.Black &&
                  (DestinationSquareName == source.File.Name.ToString() + 5))))
                // set rank 3/6 square of the file as En Passant Square
                position.EnPassantSquare = position.Board.GetSquare(SourceSquareName.Replace('2', '3').Replace('7', '6'));

            // Set castling rights
            if (Piece.PieceType == PieceType.King)
            {
                if (Side == Side.White)
                {
                    position.CastlingRights &= ~CastlingRights.WhiteShort;
                    position.CastlingRights &= ~CastlingRights.WhiteLong;
                }
                if (Side == Side.Black)
                {
                    position.CastlingRights &= ~CastlingRights.BlackShort;
                    position.CastlingRights &= ~CastlingRights.BlackLong;
                }
            }
            if (Piece.PieceType == PieceType.Rook)
            {
                if (Side == Side.White)
                {
                    if (source.File.Name == 'h')
                        position.CastlingRights &= ~CastlingRights.WhiteShort;
                    if (source.File.Name == 'a')
                        position.CastlingRights &= ~CastlingRights.WhiteLong;
                }
                if (Side == Side.Black)
                {
                    if (source.File.Name == 'h')
                        position.CastlingRights &= ~CastlingRights.BlackShort;
                    if (source.File.Name == 'a')
                        position.CastlingRights &= ~CastlingRights.BlackLong;
                }
            }

            position.SideToMove = Position.SideToMove == Side.White ? Side.Black : Side.White;

            return position;
        }
    }
}