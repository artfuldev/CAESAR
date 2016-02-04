using System;
using CAESAR.Chess.Core;

namespace CAESAR.Chess.Helpers
{
    public static class SideExtensions
    {
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