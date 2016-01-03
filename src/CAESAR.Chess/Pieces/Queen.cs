using CAESAR.Chess.Moves.Generation;

namespace CAESAR.Chess.Pieces
{
    public class Queen : Piece
    {
        public Queen(bool isWhite) : base(isWhite, "Queen", 'Q', new QueenMovesGenenerator())
        {
        }
    }
}