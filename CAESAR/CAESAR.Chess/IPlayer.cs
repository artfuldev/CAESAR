namespace CAESAR.Chess
{
    public interface IPlayer
    {
        bool IsWhite { get; }
        bool IsBlack { get; }
        IBoard MakeMove(IMove move, IBoard board);
        IBoard UnMakeMove(IMove move, IBoard board);
    }
}