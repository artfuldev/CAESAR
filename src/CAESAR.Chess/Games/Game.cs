using System.Collections.Generic;
using CAESAR.Chess.Core;
using CAESAR.Chess.Games.Exceptions;
using CAESAR.Chess.Games.Statuses;
using CAESAR.Chess.Games.Statuses.Updaters;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Players;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Games
{
    /// <summary>
    ///     Represents a game of chess
    /// </summary>
    public class Game : IGame
    {
        /// <summary>
        ///     The default <seealso cref="IStatusUpdater" />s used to update the <seealso cref="IGame" />.
        /// </summary>
        private static readonly ICollection<IStatusUpdater> DefaultStatusUpdaters = new List<IStatusUpdater>
        {
            new InProgressUpdater(),
            new InCheckUpdater(),
            new WinByCheckmateUpdater(),
            new ThreefoldRepetitionUpdater(),
            new FiftyMoveRuleUpdater(),
            new StalemateUpdater(),
            new IllegalMoveUpdater(),
            new InsufficientMatingMaterialUpdater()
        };

        public Game(IPosition position = null, IPlayer white = null, IPlayer black = null,
            ICollection<IMove> moves = null, ICollection<IStatusUpdater> statusUpdaters = null)
        {
            StatusUpdaters = statusUpdaters;
            Position = position ?? new Position();
            White = white ?? new Player("White");
            White.Side = Side.White;
            Black = black ?? new Player("Black");
            Black.Side = Side.Black;
            Moves = moves ?? new List<IMove>();
            StatusUpdaters = statusUpdaters ?? DefaultStatusUpdaters;
            UpdateStatus();
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

        /// <summary>
        ///     The collection of <seealso cref="IMove" />s made so far in the <seealso cref="IGame" />.
        /// </summary>
        public ICollection<IMove> Moves { get; }

        /// <summary>
        ///     The current <seealso cref="IPlayer" /> of the <seealso cref="IGame" />.
        /// </summary>
        public IPlayer CurrentPlayer => Position.SideToMove == Side.White ? White : Black;

        /// <summary>
        ///     The current opposing <seealso cref="IPlayer" /> of the <seealso cref="IGame" />.
        /// </summary>
        public IPlayer CurrentOpponent => CurrentPlayer == White ? Black : White;

        /// <summary>
        ///     Indicates if the current <seealso cref="Side" /> is in check.
        /// </summary>
        public bool CurrentSideInCheck { get; set; }

        /// <summary>
        ///     Plays the best <seealso cref="IMove" /> of the <seealso cref="IGame.CurrentPlayer" />.
        /// </summary>
        /// <exception cref="CannotPlayGameException">When the current <seealso cref="IGame" /> is not playable.</exception>
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

        /// <summary>
        ///     Plays the specified <seealso cref="IMove" /> using the <seealso cref="IGame.CurrentPlayer" />.
        /// </summary>
        /// <param name="move">The <seealso cref="IMove" /> to be played.</param>
        public void Play(IMove move)
        {
            Position = CurrentPlayer.MakeMove(move) ?? Position;
            Moves.Add(move);
            UpdateStatus();
        }

        /// <summary>
        ///     A collection of <seealso cref="IStatusUpdater" />s with which to update the <seealso cref="IGame" /> after every
        ///     <seealso cref="IMove" />.
        /// </summary>
        public ICollection<IStatusUpdater> StatusUpdaters { get; }

        /// <summary>
        ///     The current <seealso cref="Statuses.Status" /> of the <seealso cref="IGame" />.
        /// </summary>
        public Status Status { get; set; } = Status.YetToBegin;

        /// <summary>
        ///     The current <seealso cref="Statuses.StatusReason" /> of the <seealso cref="IGame" />.
        /// </summary>
        public StatusReason StatusReason { get; set; } = StatusReason.GameJustBegan;

        /// <summary>
        ///     Updates the <seealso cref="IGame.Status" /> and <seealso cref="IGame.StatusReason" /> of the
        ///     <seealso cref="IGame" /> with its <seealso cref="IGame.StatusUpdaters" />.
        /// </summary>
        private void UpdateStatus()
        {
            foreach (var updater in StatusUpdaters)
                updater.UpdateStatus(this);
        }
    }
}