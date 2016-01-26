using System.Collections.Generic;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Players;

namespace CAESAR.Chess
{
    public class Game : IGame
    {
        public Game(IBoard board, IPlayer white, IPlayer black, ICollection<IMove> moves)
        {
            Board = board;
            White = white;
            Black = black;
            Moves = moves;
        }

        public IBoard Board { get; }
        public IPlayer White { get; }
        public IPlayer Black { get; }
        public ICollection<IMove> Moves { get; }
        public IPlayer CurrentPlayer => (Moves?.Count ?? 0)%2 == 0 ? White : Black;
        public Side SideToPlay => (Moves?.Count ?? 0)%2 == 0 ? Side.White : Side.Black;
    }
}