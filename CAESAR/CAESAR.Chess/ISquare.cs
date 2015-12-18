namespace CAESAR.Chess
{
    public interface ISquare
    {
        IFile File { get; }
        IRank Rank { get; }
        string Name { get; }
        bool IsLight { get; }
        bool IsDark { get; }
        IBoard Board { get; }
    }
}
