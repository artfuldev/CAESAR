namespace CAESAR.Chess.Games.Statuses
{
    /// <summary>
    ///     The reason for the current <seealso cref="Status" /> of the <seealso cref="IGame" />.
    /// </summary>
    public enum StatusReason
    {
        /// <summary>
        ///     Uknown.
        /// </summary>
        Unknown,

        /// <summary>
        ///     An illegal move was played by one side.
        /// </summary>
        IllegalMove,

        /// <summary>
        ///     The <seealso cref="IGame" /> just began.
        /// </summary>
        GameJustBegan,

        /// <summary>
        ///     Play is in progress.
        /// </summary>
        PlayInProgress,

        /// <summary>
        ///     The opponent's king has been checkmated.
        /// </summary>
        Checkmate,

        /// <summary>
        ///     The opponent's king has nowhere to move but is not in check.
        /// </summary>
        Stalemate,

        /// <summary>
        ///     Fifty moves have progressed without a pawn move or a capture.
        /// </summary>
        FiftyMovesRule,

        /// <summary>
        ///     The position has repeated itself three times on the board, no progress is being made.
        /// </summary>
        ThreefoldRepetition,
    }
}