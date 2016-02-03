using System.Collections.Generic;
using CAESAR.Chess.Core;
using CAESAR.Chess.Games.Statuses;
using CAESAR.Chess.Games.Statuses.Updaters;
using CAESAR.Chess.Moves;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Players;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Games
{
    /// <summary>
    /// Represents a game of chess
    /// </summary>
    public interface IGame
    {
        IPlayer Black { get; }
        IPosition Position { get; }
        ICollection<IMove> Moves { get; }
        IPlayer White { get; }
        IPlayer CurrentPlayer { get; }
        IPlayer CurrentOpponent { get; }
        void Play();
        void Play(IMove move);
        ICollection<IStatusUpdater> StatusUpdaters { get; }
        Status Status { get; set; }
        StatusReason StatusReason { get; set; }
        bool CurrentSideInCheck { get; set; }
    }
}