using CAESAR.Chess.Core;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Positions
{
    public interface IPosition : ICloneable
    {
        IBoard Board { get; set; }
        Side SideToMove { get; set; }
        CastlingRights CastlingRights { get; set; }
        ISquare EnPassantSquare { get; set; }
        byte HalfMoveClock { get; set; }
        ushort FullMoveNumber { get; set; }
    }
}