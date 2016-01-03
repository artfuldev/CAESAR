using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.Moves.Generation;

namespace CAESAR.Chess.Pieces
{
    public class Rook : Piece
    {
        public Rook(bool isWhite) : base(isWhite, "Rook", 'R', new RookMovesGenerator())
        {
        }
    }
}