using System.Collections.Generic;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Players;

namespace CAESAR.Chess
{
    public interface IGame
    {
        IPlayer Black { get; }
        IBoard Board { get; }
        ICollection<IMove> Moves { get; }
        IPlayer White { get; }
        IPlayer CurrentPlayer { get; }
        Side SideToPlay { get; }
    }
}