using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.Moves.Generation;

namespace CAESAR.Chess.Pieces
{
    public class Rook : Piece
    {
        public Rook(Side side) : base(side, "Rook", 'R', new RookMovesGenerator())
        {
        }
    }
}