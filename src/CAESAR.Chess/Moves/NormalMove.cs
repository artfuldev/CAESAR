using CAESAR.Chess.Core;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Moves
{
    public class NormalMove : Move
    {
        public string SourceSquareName { get; }
        public string DestinationSquareName { get; }
        public NormalMove(Side side, string sourceSquareName, string destinationSquareName) : base(side, sourceSquareName + destinationSquareName)
        {
            SourceSquareName = sourceSquareName;
            DestinationSquareName = destinationSquareName;
        }

        protected override IBoard MakeImplementation()
        {
            throw new System.NotImplementedException();
        }
    }
}