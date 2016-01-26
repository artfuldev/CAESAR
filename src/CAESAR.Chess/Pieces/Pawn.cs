using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.Moves.Generation;

namespace CAESAR.Chess.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Side side) : base(side, "Pawn", 'P', new PawnMovesGenerator())
        {
        }
    }
}