using System;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Moves
{
    public class CastlingMove : NormalMove
    {
        public CastlingMove(ISquare source, CastlingType castlingType)
            : base(source, GetDestinationSquareName(castlingType))
        {
        }

        static string GetDestinationSquareName(CastlingType type)
        {
            switch (type)
            {
                case CastlingType.WhiteShort:
                    return "g1";
                case CastlingType.WhiteLong:
                    return "c1";
                case CastlingType.BlackShort:
                    return "g8";
                case CastlingType.BlackLong:
                    return "c8";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid castling type");
            }
        }
    }

    public enum CastlingType
    {
        WhiteShort,
        WhiteLong,
        BlackShort,
        BlackLong
    }
}