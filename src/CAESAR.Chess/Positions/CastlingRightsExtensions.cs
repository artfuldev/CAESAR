using System;
using System.Linq;

namespace CAESAR.Chess.Positions
{
    /// <summary>
    ///     Useful extensions for the <seealso cref="CastlingRights" /> enumeration.
    /// </summary>
    public static class CastlingRightsExtensions
    {
        /// <summary>
        ///     Converts a <seealso cref="string" /> representing castling rights to <seealso cref="CastlingRights" />.
        /// </summary>
        /// <param name="castlingRights">The castling rights as a <seealso cref="string" />.</param>
        /// <returns>The <seealso cref="CastlingRights" /> represented by the <seealso cref="string" />.</returns>
        public static CastlingRights ToCastlingRights(this string castlingRights)
        {
            if (string.IsNullOrWhiteSpace(castlingRights) || castlingRights == "-")
                return CastlingRights.None;
            return castlingRights.Aggregate(CastlingRights.None,
                (current, castlingRight) => current | castlingRight.ToCastlingRights());
        }

        /// <summary>
        ///     Converts a <seealso cref="char" /> representing castling rights to <seealso cref="CastlingRights" />.
        /// </summary>
        /// <param name="castlingRights">The castling rights as a <seealso cref="char" />.</param>
        /// <returns>The <seealso cref="CastlingRights" /> represented by the <seealso cref="char" />.</returns>
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

        /// <summary>
        ///     Converts a <seealso cref="CastlingRights" /> enumeration to its corresponding <seealso cref="string" />
        ///     representation.
        /// </summary>
        /// <param name="castlingRights">
        ///     The <seealso cref="CastlingRights" /> for which a  <seealso cref="string" />
        ///     representation is needed.
        /// </param>
        /// <returns>The <seealso cref="string" /> representing the given <seealso cref="castlingRights" />.</returns>
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