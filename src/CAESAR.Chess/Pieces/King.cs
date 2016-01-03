using CAESAR.Chess.Moves.Generation;

namespace CAESAR.Chess.Pieces
{
    public class King : Piece
    {
        public King(bool isWhite) : base(isWhite, "King", 'K', new KingMovesGenerator())
        {
        }
    }
}