using CAESAR.Chess.Core;

namespace CAESAR.Chess.Moves
{
    public class CapturingMove : NormalMove
    {
        public CapturingMove(Side side, string sourceSquareName, string destinationSquareName)
            : base(side, sourceSquareName, destinationSquareName)
        {
        }
    }
}