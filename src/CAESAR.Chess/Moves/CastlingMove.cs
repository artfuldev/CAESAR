using System;
using CAESAR.Chess.Core;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Moves
{
    public class CastlingMove : NormalMove
    {
        public CastlingMove(ISquare source, CastlingType castlingType)
            : base(source, GetDestinationSquareName(source.Piece.Side, castlingType))
        {
        }

        static string GetDestinationSquareName(Side side, CastlingType type)
        {
            var rankNumber = side == Side.White ? 1 : 8;
            var fileName = type == CastlingType.Kingside ? "g" : "c";
            return fileName + rankNumber;
        }
    }

    public enum CastlingType
    {
        Kingside,
        Queenside
    }
}