using System;
using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;

namespace CAESAR.Chess.Helpers
{
    /// <summary>
    ///     Provides useful extensions to the <seealso cref="Side" /> enumeration.
    /// </summary>
    public static class SideExtensions
    {
        /// <summary>
        ///     Converts a <seealso cref="char" /> denoting a side to a <seealso cref="Side" />.
        /// </summary>
        /// <param name="side">The <seealso cref="char" /> denoting the <seealso cref="Side" />.</param>
        /// <returns>The <seealso cref="Side" /> denoted by the <seealso cref="char" />.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     When the <seealso cref="side" /> is not <seealso cref="Side.Black" /> or
        ///     <seealso cref="Side.White" />.
        /// </exception>
        public static Side ToSide(this char side)
        {
            switch (side)
            {
                case 'w':
                case 'W':
                    return Side.White;
                case 'b':
                case 'B':
                    return Side.Black;
                default:
                    throw new ArgumentOutOfRangeException(nameof(side), side, null);
            }
        }

        /// <summary>
        ///     Converts a <seealso cref="Side" /> to its Active Color <seealso cref="char" /> representation.
        /// </summary>
        /// <param name="side">The <seealso cref="Side" /> to convert to Active Color.</param>
        /// <returns>The active color <seealso cref="char" /> representation of the <seealso cref="side" />.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     When the <seealso cref="side" /> is not <seealso cref="Side.Black" /> or
        ///     <seealso cref="Side.White" />.
        /// </exception>
        public static char GetActiveColor(this Side side)
        {
            switch (side)
            {
                case Side.White:
                    return 'w';
                case Side.Black:
                    return 'b';
                default:
                    throw new ArgumentOutOfRangeException(nameof(side), side, null);
            }
        }

        /// <summary>
        ///     Gets the <seealso cref="Side" /> of the <seealso cref="IPiece" /> represented by the <seealso cref="char" />.
        /// </summary>
        /// <param name="notation">The <seealso cref="char" /> notation of an <seealso cref="IPiece" />.</param>
        /// <returns>The <seealso cref="Side" /> of the <seealso cref="IPiece" /> represented by the <seealso cref="notation" />.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     When the <seealso cref="notation" /> does not belong to any recognized
        ///     <seealso cref="IPiece" />.
        /// </exception>
        public static Side GetPieceSide(this char notation)
        {
            switch (notation)
            {
                case 'p':
                case 'r':
                case 'n':
                case 'b':
                case 'q':
                case 'k':
                    return Side.Black;
                case 'P':
                case 'R':
                case 'N':
                case 'B':
                case 'Q':
                case 'K':
                    return Side.White;
                default:
                    throw new ArgumentOutOfRangeException(nameof(notation), notation, null);
            }
        }
    }
}