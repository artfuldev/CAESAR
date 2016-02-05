using CAESAR.Chess.Core;
using CAESAR.Chess.Moves.Exceptions;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Moves
{
    public class NormalMove : Move
    {
        public string SourceSquareName => Source.Name;
        public string DestinationSquareName { get; }
        public ISquare Source { get;}
        public IPiece Piece { get; }
        public NormalMove(ISquare source, string destinationSquareName) : base(source.Board.Position, source.Piece.Side, source.Name + destinationSquareName)
        {
            Source = Position.Board.GetSquare(source.Name);
            Piece = source.Piece;
            DestinationSquareName = destinationSquareName;
        }
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
                  (DestinationSquareName == (source.File.Name.ToString() + 4))) ||
                  // or from rank 7 to rank 5 if black
                 (SourceSquareName.EndsWith("7") && Side == Side.Black &&
                  (DestinationSquareName == (source.File.Name.ToString() + 5)))))
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
                    if (Source.File.Name == 'h')
                        position.CastlingRights &= ~CastlingRights.WhiteShort;
                    if (Source.File.Name == 'a')
                        position.CastlingRights &= ~CastlingRights.WhiteLong;
                }
                if (Side == Side.Black)
                {
                    if (Source.File.Name == 'h')
                        position.CastlingRights &= ~CastlingRights.BlackShort;
                    if (Source.File.Name == 'a')
                        position.CastlingRights &= ~CastlingRights.BlackLong;
                }
            }

            position.SideToMove = Position.SideToMove == Side.White ? Side.Black : Side.White;

            return position;
        }
    }
}