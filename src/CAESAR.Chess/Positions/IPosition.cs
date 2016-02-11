using CAESAR.Chess.Core;
using CAESAR.Chess.Games;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Positions
{
    /// <summary>
    ///     Represents a chess position in a game of chess (in an <seealso cref="IGame" />). It is also an
    ///     <seealso cref="ICloneable" />, and holds the <seealso cref="IBoard" />, the <seealso cref="Side" /> to move, the
    ///     <seealso cref="Positions.CastlingRights" />, the en passant <seealso cref="ISquare" />, the half move clock for the
    ///     fifty-move rule, and also the number of full moves. It can be set up in a <seealso cref="FenString" /> and also be
    ///     converted to a <seealso cref="FenString" />.
    /// </summary>
    public interface IPosition : ICloneable
    {
        /// <summary>
        ///     The <seealso cref="IBoard" /> that belongs to this <seealso cref="IPosition" />.
        /// </summary>
        IBoard Board { get; set; }

        /// <summary>
        ///     The <seealso cref="Side" /> that is to move next in this <seealso cref="IPosition" />.
        /// </summary>
        Side SideToMove { get; set; }

        /// <summary>
        ///     The <seealso cref="Positions.CastlingRights" /> of this <seealso cref="IPosition" />.
        /// </summary>
        CastlingRights CastlingRights { get; set; }

        /// <summary>
        ///     The en passant target <seealso cref="ISquare" /> of this <seealso cref="IPosition" />, if any.
        /// </summary>
        ISquare EnPassantSquare { get; set; }

        /// <summary>
        ///     The number of half moves made without a capture or a pawn move, with respect to the fifty-move rule, to reach this
        ///     <seealso cref="IPosition" />.
        /// </summary>
        byte HalfMoveClock { get; set; }

        /// <summary>
        ///     The number of full moves made in this <seealso cref="IPosition" />.
        /// </summary>
        ushort FullMoveNumber { get; set; }

        /// <summary>
        ///     Sets up this <seealso cref="IPosition" /> as indicated by a specific <seealso cref="FenString" />.
        /// </summary>
        /// <param name="fenString">
        ///     The <seealso cref="FenString" /> according to which this <seealso cref="IPosition" /> must be
        ///     set up.
        /// </param>
        void SetPosition(FenString fenString);

        /// <summary>
        ///     Converts this <seealso cref="IPosition" /> to a <seealso cref="FenString" />.
        /// </summary>
        /// <returns>A <seealso cref="FenString" /> instance representing this <seealso cref="IPosition" />.</returns>
        FenString ToFenString();
    }
}