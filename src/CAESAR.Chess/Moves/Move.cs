using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves.Notations;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Moves
{
    public class Move : IMove
    {
        private static readonly INotation DefaultNotation = new PureCoordinateNotation();
        public Move(IPiece piece, ISquare destination, IPiece promotionPiece = null)
        {
            Piece = piece;
            Destination = destination;
            Source = piece.Square;
            PromotionPiece = promotionPiece;
            CapturedPiece = Destination.Piece;
        }

        public ISquare Source { get; }
        public ISquare Destination { get; }
        public IPiece Piece { get; }
        public IPiece PromotionPiece { get; }
        public IPiece CapturedPiece { get; }

        public override string ToString()
        {
            return ToString(DefaultNotation);
        }

        public string ToString(INotation notation)
        {
            return notation?.ToString(this);
        }
    }
}