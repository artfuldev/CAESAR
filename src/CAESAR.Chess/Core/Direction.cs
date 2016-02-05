namespace CAESAR.Chess.Core
{
    /// <summary>
    ///     A direction of navigation/reference for the board
    /// </summary>
    public enum Direction : byte
    {
        /// <summary>
        ///     No direction.
        /// </summary>
        None,

        /// <summary>
        ///     The upward direction.
        /// </summary>
        Up,

        /// <summary>
        ///     The right direction.
        /// </summary>
        Right,

        /// <summary>
        ///     The downward direction.
        /// </summary>
        Down,

        /// <summary>
        ///     The left direction.
        /// </summary>
        Left,

        /// <summary>
        ///     The up-right direction.
        /// </summary>
        UpRight,

        /// <summary>
        ///     The down-right direction.
        /// </summary>
        DownRight,

        /// <summary>
        ///     The down-left direction.
        /// </summary>
        DownLeft,

        /// <summary>
        ///     The up-left direction.
        /// </summary>
        UpLeft
    }
}