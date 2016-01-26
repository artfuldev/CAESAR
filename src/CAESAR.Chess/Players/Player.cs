using CAESAR.Chess.Moves;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Players
{
    public class Player : IPlayer
    {
        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public void Place(IBoard board, IPiece piece, string squareName)
        {
            Place(board.GetSquare(squareName), piece);
        }

        public void Place(ISquare square, IPiece piece)
        {
            if (!ReferenceEquals(null, piece))
                piece.Square = square;
            square.Piece = piece;
        }

        public void MakeMove(IMove move)
        {
            var piece = move.Piece;
            var destination = move.Destination;
            var source = move.Source;
            switch (move.MoveType)
            {
                case MoveType.Normal:
                case MoveType.Capture:
                    Place(source, null);
                    Place(destination, piece);
                    break;
                case MoveType.None:
                case MoveType.Illegal:
                case MoveType.EnPassant:
                case MoveType.Castle:
                case MoveType.Promotion:
                default:
                    return;
            }
        }

        public void UnMakeMove(IMove move)
        {
            var piece = move.Piece;
            var destination = move.Destination;
            var captured = move.CapturedPiece;
            var source = move.Source;
            switch (move.MoveType)
            {
                case MoveType.Normal:
                case MoveType.Capture:
                    Place(source, piece);
                    Place(destination, captured);
                    break;
                case MoveType.None:
                case MoveType.Illegal:
                case MoveType.EnPassant:
                case MoveType.Castle:
                case MoveType.Promotion:
                default:
                    return;
            }
        }
    }
}