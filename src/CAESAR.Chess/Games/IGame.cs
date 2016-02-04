using System.Collections.Generic;
using CAESAR.Chess.Core;
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
    public interface IGame
    {
        /// <summary>
        ///     The <seealso cref="IPlayer" /> who plays for <seealso cref="Side.Black" />.
        /// </summary>
        IPlayer Black { get; }

        /// <summary>
        ///     The current <seealso cref="IPosition" /> of the <seealso cref="IGame" />.
        /// </summary>
        IPosition Position { get; }

        ICollection<IMove> Moves { get; }

        /// <summary>
        ///     The <seealso cref="IPlayer" /> who plays for <seealso cref="Side.White" />.
        /// </summary>
        IPlayer White { get; }

        /// <summary>
        ///     The current <seealso cref="IPlayer" /> of the <seealso cref="IGame" />.
        /// </summary>
        IPlayer CurrentPlayer { get; }

        /// <summary>
        ///     The current opposing <seealso cref="IPlayer" /> of the <seealso cref="IGame" />.
        /// </summary>
        IPlayer CurrentOpponent { get; }

        ICollection<IStatusUpdater> StatusUpdaters { get; }
        Status Status { get; set; }
        StatusReason StatusReason { get; set; }
        bool CurrentSideInCheck { get; set; }
        void Play();
        void Play(IMove move);
    }
}