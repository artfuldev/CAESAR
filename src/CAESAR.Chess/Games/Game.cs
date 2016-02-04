using System;
using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Games.Exceptions;
using CAESAR.Chess.Games.Statuses;
using CAESAR.Chess.Games.Statuses.Updaters;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Players;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Games
{
    /// <summary>
    /// Represents a game of chess
    /// </summary>
    public class Game : IGame
    {
        private static readonly ICollection<IStatusUpdater> DefaultStatusUpdaters = new List<IStatusUpdater>()
        {
            new InProgressUpdater(),
            new InCheckUpdater(),
            new WinByCheckmateUpdater(),
            new ThreefoldRepetitionUpdater(),
            new FiftyMoveRuleUpdater()
        }; 
        public Game(IPosition position, IPlayer white, IPlayer black, ICollection<IMove> moves, ICollection<IStatusUpdater> statusUpdaters = null)
        {
            StatusUpdaters = statusUpdaters;
            Position = position ?? new Position();
            White = white ?? new Player("White");
            White.Side = Side.White;
            Black = black ?? new Player("Black");
            Black.Side = Side.Black;
            Moves = moves ?? new List<IMove>();
            StatusUpdaters = statusUpdaters ?? DefaultStatusUpdaters;
        }
        /// <summary>
        ///     The current <seealso cref="IPosition" /> of the <seealso cref="IGame" />.
        /// </summary>
        public IPosition Position { get; private set; }
        /// <summary>
        ///     The <seealso cref="IPlayer" /> who plays for <seealso cref="Side.White" />.
        /// </summary>
        public IPlayer White { get; }
        /// <summary>
        ///     The <seealso cref="IPlayer" /> who plays for <seealso cref="Side.Black" />.
        /// </summary>
        public IPlayer Black { get; }
        public ICollection<IMove> Moves { get; }
        /// <summary>
        ///     The current <seealso cref="IPlayer" /> of the <seealso cref="IGame" />.
        /// </summary>
        public IPlayer CurrentPlayer => (Moves?.Count ?? 0) % 2 == 0 ? White : Black;
        /// <summary>
        ///     The current opposing <seealso cref="IPlayer" /> of the <seealso cref="IGame" />.
        /// </summary>
        public IPlayer CurrentOpponent => CurrentPlayer == White ? Black : White;
        public bool CurrentSideInCheck { get; set; }
        public Side SideToPlay => (Moves?.Count ?? 0) % 2 == 0 ? Side.White : Side.Black;

        public void Play()
        {
            switch (Status)
            {
                case Status.YetToBegin:
                case Status.InProgress:
                    Play(CurrentPlayer.GetBestMove(Position));
                    break;
                default:
                    throw new CannotPlayGameException(Status, StatusReason);
            }
        }

        public void Play(IMove move)
        {
            Position = CurrentPlayer.MakeMove(move) ?? Position;
            Moves.Add(move);
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            foreach (var updater in StatusUpdaters)
                updater.UpdateStatus(this);
        }

        public ICollection<IStatusUpdater> StatusUpdaters { get; }
        public Status Status { get; set; } = Status.YetToBegin;
        public StatusReason StatusReason { get; set; } = StatusReason.GameJustBegan;
    }
}