namespace CAESAR.Chess.PlayArea
{
    public interface IDiagonal
    {
        ISquare[] Squares { get; }  
        string Name { get; }
        IBoard Board { get; }
    }
}