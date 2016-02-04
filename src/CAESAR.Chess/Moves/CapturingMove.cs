using CAESAR.Chess.Core;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Moves
{
    public class CapturingMove : NormalMove
    {
        public CapturingMove(ISquare source, string destinationSquareName)
            : base(source, destinationSquareName)
        {
        }
        protected override IPosition MakeImplementation(IPosition position)
        {
            position = base.MakeImplementation(position);
            position.HalfMoveClock = 0;
            return position;
        }
    }
}