using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.Moves.Generation;

namespace CAESAR.Chess.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(bool isWhite) : base(isWhite, "Pawn", 'P', new PawnMovesGenerator())
        {
        }
    }
}