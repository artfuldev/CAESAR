namespace CAESAR.Chess.Games.Statuses
{
    public enum StatusReason
    {
        Unknown,
        GameJustBegan,
        PlayInProgress,
        Checkmate,
        Stalemate,
        FiftyMovesRule,
        ThreefoldRepetition
    }
}