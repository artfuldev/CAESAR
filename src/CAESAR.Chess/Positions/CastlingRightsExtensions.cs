using System;
using System.Linq;

namespace CAESAR.Chess.Positions
{
    public static class CastlingRightsExtensions
    {
        public static CastlingRights ToCastlingRights(this string castlingRights)
        {
            if (string.IsNullOrWhiteSpace(castlingRights) || castlingRights == "-")
                return CastlingRights.None;
            return castlingRights.Aggregate(CastlingRights.None, (current, castlingRight) => current | castlingRight.ToCastlingRights());
        }

        private static CastlingRights ToCastlingRights(this char castlingRights)
        {
            switch (castlingRights)
            {
                case 'K':
                    return CastlingRights.WhiteShort;
                case 'Q':
                    return CastlingRights.WhiteLong;
                case 'k':
                    return CastlingRights.BlackShort;
                case 'q':
                    return CastlingRights.BlackLong;
                case '-':
                    return CastlingRights.None;
                default:
                    throw new ArgumentOutOfRangeException(nameof(castlingRights), castlingRights, null);
            }
        }

        public static string ToCastlingAvailability(this CastlingRights castlingRights)
        {
            if (castlingRights == CastlingRights.None)
                return "-";
            var returnable = "";
            if (castlingRights.HasFlag(CastlingRights.WhiteShort))
                returnable += 'K';
            if (castlingRights.HasFlag(CastlingRights.WhiteLong))
                returnable += 'Q';
            if (castlingRights.HasFlag(CastlingRights.BlackShort))
                returnable += 'k';
            if (castlingRights.HasFlag(CastlingRights.BlackLong))
                returnable += 'q';
            return returnable;
        }
    }
}