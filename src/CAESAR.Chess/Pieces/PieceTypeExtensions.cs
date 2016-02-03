using System;
using CAESAR.Chess.Core;

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

        public static PieceType GetPieceType(this char notation)
        {
            switch (notation)
            {
                case 'P':
                case 'p':
                    return PieceType.Pawn;
                case 'R':
                case 'r':
                    return PieceType.Rook;
                case 'N':
                case 'n':
                    return PieceType.Knight;
                case 'B':
                case 'b':
                    return PieceType.Bishop;
                case 'Q':
                case 'q':
                    return PieceType.Queen;
                case 'K':
                case 'k':
                    return PieceType.King;
                default:
                    throw new ArgumentOutOfRangeException(nameof(notation), notation, null);
            }
        }

        public static IPiece GetPiece(this PieceType type, Side side)
        {
            switch (type)
            {
                case PieceType.Pawn:
                    return new Pawn(side);
                case PieceType.Rook:
                    return new Rook(side);
                case PieceType.Knight:
                    return new Knight(side);
                case PieceType.Bishop:
                    return new Bishop(side);
                case PieceType.Queen:
                    return new Queen(side);
                case PieceType.King:
                    return new King(side);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}