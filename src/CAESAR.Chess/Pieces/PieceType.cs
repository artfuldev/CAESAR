using CAESAR.Chess.Games;

namespace CAESAR.Chess.Pieces
{
    /// <summary>
    ///     The type of piece in an <seealso cref="IGame" />.
    /// </summary>
    public enum PieceType
    {
        /// <summary>
        ///     No specific piece type.
        /// </summary>
        None,

        /// <summary>
        ///     The pawn.
        /// </summary>
        Pawn,

        /// <summary>
        ///     The rook.
        /// </summary>
        Rook,

        /// <summary>
        ///     The knight.
        /// </summary>
        Knight,

        /// <summary>
        ///     The bishop.
        /// </summary>
        Bishop,

        /// <summary>
        ///     The queen.
        /// </summary>
        Queen,

        /// <summary>
        ///     The king.
        /// </summary>
        King
    }
}