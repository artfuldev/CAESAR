using System;
using CAESAR.Chess.Core;
using CAESAR.Chess.Helpers;

namespace CAESAR.Chess.Pieces
{
    /// <summary>
    ///     Provides useful extensions to the <seealso cref="PieceType" /> enumeration.
    /// </summary>
    public static class PieceTypeExtensions
    {
        /// <summary>
        ///     Gets the notation corresponding to a particular <seealso cref="PieceType" />.
        /// </summary>
        /// <param name="pieceType">The <seealso cref="PieceType" /> for which to get the notation.</param>
        /// <returns>The notation corresponding to a particular <seealso cref="pieceType" /> as a <seealso cref="char" />.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the specififed <seealso cref="pieceType" /> does not have a
        ///     matching notation.
        /// </exception>
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

        /// <summary>
        ///     Gets the <seealso cref="PieceType" /> corresponding to a <seealso cref="char" /> notation.
        /// </summary>
        /// <param name="notation">The notation of the piece as a <seealso cref="char" />.</param>
        /// <returns>The <seealso cref="PieceType" /> corresponding to its <seealso cref="notation" />.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the specififed <seealso cref="notation" /> does not have a
        ///     matching <seealso cref="PieceType" />.
        /// </exception>
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

        /// <summary>
        ///     Gets a new instance of an <seealso cref="IPiece" /> of a particular <seealso cref="PieceType" /> belonging to a
        ///     given <seealso cref="Side" />.
        /// </summary>
        /// <param name="type">The <seealso cref="PieceType" /> of the new <seealso cref="IPiece" /> instance.</param>
        /// <param name="side">The <seealso cref="Side" /> to which the new <seealso cref="IPiece" /> instance must belong.</param>
        /// <returns>
        ///     A new instance of an <seealso cref="IPiece" /> of a particular <seealso cref="type" /> belonging to a given
        ///     <seealso cref="side" />.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the specififed <seealso cref="type" /> does not have a
        ///     matching <seealso cref="IPiece" /> instance.
        /// </exception>
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

        /// <summary>
        ///     Gets a new instance of an <seealso cref="IPiece" /> corresponding to its <seealso cref="char" /> notation.
        /// </summary>
        /// <param name="notation">The notaiton of the <seealso cref="IPiece" /> as a <seealso cref="char" />.</param>
        /// <returns>A new instance of an <seealso cref="IPiece" /> corresponding to its <seealso cref="notation" />.</returns>
        public static IPiece GetPiece(this char notation)
        {
            return GetPiece(notation.GetPieceType(), notation.GetPieceSide());
        }
    }
}