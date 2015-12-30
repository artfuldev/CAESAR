using CAESAR.Chess.Pieces;

namespace CAESAR.Chess.Implementation
{
    public class Player : IPlayer
    {
        public Player(bool isWhite = true)
        {
            IsWhite = isWhite;
        }

        public bool IsWhite { get; }
        public bool IsBlack => !IsWhite;
        public void Place(IBoard board, IPiece piece, string squareName)
        {
            var square = board.GetSquare(squareName);
            piece.Square = square;
            square.Piece = piece;
        }

        public void MakeMove(IMove move)
        {
            switch (move.MoveType)
            {
                case MoveType.Normal:
                    var piece = move.Piece;
                    move.Source.Piece = null;
                    move.Destination.Piece = piece;
                    piece.Square = move.Destination;
                    return;
                case MoveType.None:
                case MoveType.Illegal:
                default:
                    return;
            }
        }

        public void UnMakeMove(IMove move)
        {
            switch (move.MoveType)
            {
                case MoveType.Normal:
                    var piece = move.Piece;
                    move.Destination.Piece = null;
                    move.Source.Piece = piece;
                    piece.Square = move.Source;
                    return;
                case MoveType.None:
                case MoveType.Illegal:
                default:
                    return;
            }
        }
    }
}