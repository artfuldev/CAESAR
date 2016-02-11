namespace CAESAR.Chess.Core
{
    /// <summary>
    ///     Represents a side of play in the game.
    /// </summary>
    public enum Side : sbyte
    {
        /// <summary>
        /// No side.
        /// </summary>
        None,

        /// <summary>
        ///     Represents the white side of play in the game.
        /// </summary>
        White = 1,

        /// <summary>
        ///     Represents the black side of play in the game.
        /// </summary>
        Black = -1
    }
}