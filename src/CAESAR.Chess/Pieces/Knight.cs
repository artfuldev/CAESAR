using System.Collections.Generic;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.Moves.Generation;

namespace CAESAR.Chess.Pieces
{
    public class Knight : Piece
    {
        public Knight(bool isWhite) : base(isWhite, "Knight", 'N', new KnightMovesGenerator())
        {
        }
    }
}