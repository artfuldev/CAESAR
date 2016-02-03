using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Moves.Notations
{
    /// <summary>
    ///     Denotes a system to record either the moves made in a game of chess or the position of pieces on a chessboard.
    /// </summary>
    public interface INotation
    {
        string ToString(IMove move);
    }
}