namespace CAESAR.Chess.Games.Statuses
{
    /// <summary>
    ///     The current status of the <seealso cref="IGame" />.
    /// </summary>
    public enum Status
    {
        /// <summary>
        ///     Unknown.
        /// </summary>
        Unknown,

        /// <summary>
        ///     The <seealso cref="IGame" /> is yet to begin
        /// </summary>
        YetToBegin,

        /// <summary>
        ///     The <seealso cref="IGame" /> is in progress.
        /// </summary>
        InProgress,

        /// <summary>
        ///     The <seealso cref="IGame" /> is drawn, neither player is the winner.
        /// </summary>
        Drawn,

        /// <summary>
        ///     The <seealso cref="IGame.White" /> player has won the game.
        /// </summary>
        WhiteWon,

        /// <summary>
        ///     The <seealso cref="IGame.Black" /> player has won the game.
        /// </summary>
        BlackWon
    }
}