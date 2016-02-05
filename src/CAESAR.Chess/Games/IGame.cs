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

        /// <summary>
        ///     The collection of <seealso cref="IMove" />s made so far in the <seealso cref="IGame" />.
        /// </summary>
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

        /// <summary>
        ///     A collection of <seealso cref="IStatusUpdater" />s with which to update the <seealso cref="IGame" /> after every
        ///     <seealso cref="IMove" />.
        /// </summary>
        ICollection<IStatusUpdater> StatusUpdaters { get; }

        /// <summary>
        ///     The current <seealso cref="Statuses.Status" /> of the <seealso cref="IGame" />.
        /// </summary>
        Status Status { get; set; }

        /// <summary>
        ///     The current <seealso cref="Statuses.StatusReason" /> of the <seealso cref="IGame" />.
        /// </summary>
        StatusReason StatusReason { get; set; }

        /// <summary>
        ///     Indicates if the current <seealso cref="Side" /> is in check.
        /// </summary>
        bool CurrentSideInCheck { get; set; }

        /// <summary>
        ///     Plays the best <seealso cref="IMove" /> of the <seealso cref="CurrentPlayer" />.
        /// </summary>
        void Play();

        /// <summary>
        ///     Plays the specified <seealso cref="IMove" /> using the <seealso cref="CurrentPlayer" />.
        /// </summary>
        /// <param name="move">The <seealso cref="IMove" /> to be played.</param>
        void Play(IMove move);
    }
}