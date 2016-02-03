using System;

namespace CAESAR.Chess.Core
{
    [Flags]
    public enum CastlingRights : byte
    {
        None = 0x00,
        WhiteShort = 0x01,
        WhiteLong = 0x02,
        BlackShort = 0x04,
        BlackLong = 0x08
    }
}