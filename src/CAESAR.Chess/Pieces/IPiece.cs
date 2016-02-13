using System.Collections.Generic;
using CAESAR.Chess.Core;
using CAESAR.Chess.Games;
using CAESAR.Chess.Moves;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Pieces
{
    /// <summary>
    ///     Represents a piece in the <seealso cref="IGame" />. It belongs to a <seealso cref="Core.Side" />, occupies an
    ///     <seealso cref="ISquare" />, and can have <seealso cref="IMove" />s available. Every <seealso cref="IPiece" /> has a
    ///     name, notation and is of a certain <seealso cref="Pieces.PieceType" />.
    /// </summary>
    public interface IPiece : ICloneable
    {
        /// <summary>
        ///     The <seealso cref="Core.Side" /> to which this <seealso cref="IPiece" /> belongs.
        /// </summary>
        Side Side { get; }

        /// <summary>
        ///     The <seealso cref="ISquare" /> occupied by this <seealso cref="IPiece" />, if any.
        /// </summary>
        ISquare Square { get; set; }

        /// <summary>
        ///     The names of the <seealso cref="ISquare" />s which this <seealso cref="IPiece" /> threatens to capture, if any.
        /// </summary>
        IEnumerable<string> ThreatenedSquareNames { get; }

        /// <summary>
        ///     The <seealso cref="IMove" />s that can be made by this <seealso cref="IPiece" />.
        /// </summary>
        IEnumerable<IMove> Moves { get; }

        /// <summary>
        ///     The name of this <seealso cref="IPiece" />, used purely for identification.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     The notation of this <seealso cref="IPiece" />.
        /// </summary>
        char Notation { get; }

        /// <summary>
        ///     The <seealso cref="Pieces.PieceType" /> of this <seealso cref="IPiece" />.
        /// </summary>
        PieceType PieceType { get; }
    }
}