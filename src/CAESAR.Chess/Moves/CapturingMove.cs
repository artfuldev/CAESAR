using CAESAR.Chess.Core;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Moves
{
    public class CapturingMove : NormalMove
    {
        public CapturingMove(ISquare source, string destinationSquareName)
            : base(source, destinationSquareName)
        {
        }
    }
}