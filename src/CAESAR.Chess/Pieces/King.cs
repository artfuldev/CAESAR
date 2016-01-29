using CAESAR.Chess.Core;
using CAESAR.Chess.Moves.Generation;

namespace CAESAR.Chess.Pieces
{
    public class King : Piece
    {
        public King(Side side) : base(side, "King", 'K', new KingMovesGenerator())
        {
        }
    }
}