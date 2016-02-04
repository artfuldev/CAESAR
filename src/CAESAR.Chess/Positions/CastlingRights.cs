using System;
using CAESAR.Chess.Core;

namespace CAESAR.Chess.Positions
{
    /// <summary>
    ///     The rights to castle in a <seealso cref="IPosition" />
    /// </summary>
    [Flags]
    public enum CastlingRights : byte
    {
        /// <summary>
        ///     No side can castle
        /// </summary>
        None = 0x00,
        /// <summary>
        ///     <seealso cref="Side.White"/> can castle short, on the kingside
        /// </summary>
        WhiteShort = 0x01,
        /// <summary>
        ///     <seealso cref="Side.White"/> can castle long, on the queenside
        /// </summary>
        WhiteLong = 0x02,
        /// <summary>
        ///     <seealso cref="Side.Black"/> can castle short, on the kingside
        /// </summary>
        BlackShort = 0x04,
        /// <summary>
        ///     <seealso cref="Side.Black"/> can castle long, on the queenside
        /// </summary>
        BlackLong = 0x08
    }
}