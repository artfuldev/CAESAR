using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
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
            var square = Source.Board.GetSquare(DestinationSquareName);
            var destinationRank = Side == Side.White ? 1 : 8;
            var destinationSquares = new [] {"a"+destinationRank,"h"+destinationRank};
            var destinationSquare = Source.Board.GetSquare(DestinationSquareName);
            if (square.Piece.PieceType == PieceType.Rook && destinationSquares.Contains(DestinationSquareName))
            {
                if (Side == Side.White)
                {
                    if (destinationSquare.File.Name == 'a')
                        position.CastlingRights &= ~CastlingRights.WhiteLong;
                    if (destinationSquare.File.Name == 'h')
                        position.CastlingRights &= ~CastlingRights.WhiteShort;
                }
                if (Side == Side.Black)
                {
                    if (destinationSquare.File.Name == 'a')
                        position.CastlingRights &= ~CastlingRights.BlackLong;
                    if (destinationSquare.File.Name == 'h')
                        position.CastlingRights &= ~CastlingRights.BlackShort;
                }
            }
            return position;
        }
    }
}