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
            if (Source.IsEmpty)
                throw new CannotMakeMoveException(MoveOperationFailureReason.SourceSquareIsEmpty);
            var destination = position.Board.GetSquare(DestinationSquareName);
            Source.Piece = null;
            destination.Piece = Piece;
            
            // 50 Move Rule
            if (Piece.PieceType == PieceType.Pawn)
                position.HalfMoveClock = 0;
            else
                position.HalfMoveClock++;

            // En-Passant
            if(Piece.PieceType == PieceType.Pawn)
                if((Source.Rank.Number == 2 && Side == Side.White && (DestinationSquareName == (Source.File.Name.ToString()+4)))||
                    (Source.Rank.Number==7 && Side==Side.Black && (DestinationSquareName == (Source.File.Name.ToString() + 5))))
                    position.EnPassantSquare = position.Board.GetSquare(Side==Side.White)


            return position;
        }
    }
}