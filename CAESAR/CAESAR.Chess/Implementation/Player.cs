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
        }

        public IBoard MakeMove(IMove move, IBoard board)
        {
            throw new System.NotImplementedException();
        }

        public IBoard UnMakeMove(IMove move, IBoard board)
        {
            throw new System.NotImplementedException();
        }
    }
}