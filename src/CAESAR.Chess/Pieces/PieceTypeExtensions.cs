using System;

namespace CAESAR.Chess.Pieces
{
    public static class PieceTypeExtensions
    {
        public static char GetNotation(this PieceType pieceType)
        {
            switch (pieceType)
            {
                case PieceType.Pawn:
                    return 'P';
                case PieceType.Rook:
                    return 'R';
                case PieceType.Knight:
                    return 'N';
                case PieceType.Bishop:
                    return 'B';
                case PieceType.Queen:
                    return 'Q';
                case PieceType.King:
                    return 'K';
                default:
                    throw new ArgumentOutOfRangeException(nameof(pieceType), pieceType, null);
            }
        }
    }
}