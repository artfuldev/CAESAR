using CAESAR.Chess.Core;
using CAESAR.Chess.Moves.Exceptions;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Moves
{
    public class NormalMove : Move
    {
        public string SourceSquareName => Source.Name;
        public string DestinationSquareName { get; }
        public ISquare Source { get;}
        public IPiece Piece { get; }
        public NormalMove(ISquare source, string destinationSquareName) : base(source.Board, source.Piece.Side, source.Name + destinationSquareName)
        {
            Source = Board.GetSquare(source.Name);
            Piece = source.Piece;
            DestinationSquareName = destinationSquareName;
        }

        protected override IBoard MakeImplementation(IBoard board)
        {
            if (Source.IsEmpty)
                throw new CannotMakeMoveException(MoveOperationFailureReason.SourceSquareIsEmpty);
            var destination = board.GetSquare(DestinationSquareName);
            Source.Piece = null;
            destination.Piece = Piece;
            return board;
        }
    }
}