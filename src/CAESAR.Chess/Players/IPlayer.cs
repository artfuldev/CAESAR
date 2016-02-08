using System.Collections.Generic;
using CAESAR.Chess.Core;
using CAESAR.Chess.Games;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Players
{
    /// <summary>
    ///     A player of the <seealso cref="IGame" /> of chess, belonging to one <seealso cref="Core.Side" />. A player can have
    ///     a <seealso cref="Name" />, can make and undo <seealso cref="IMove" />s, and can get all or the best
    ///     <seealso cref="IMove" /> in a particular <seealso cref="IPosition" />.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        ///     The <seealso cref="Core.Side" /> to which this <seealso cref="IPlayer" /> belongs.
        /// </summary>
        Side Side { get; set; }

        /// <summary>
        ///     The name of this <seealso cref="IPlayer" />.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Gets all the <seealso cref="IMove" />s in an <seealso cref="IPosition" /> that this <seealso cref="IPlayer" /> can
        ///     play.
        /// </summary>
        /// <param name="position">The <seealso cref="IPosition" /> in which to look for <seealso cref="IMove" />s.</param>
        /// <returns>
        ///     All the <seealso cref="IMove" />s in the <seealso cref="position" /> that this <seealso cref="IPlayer" /> can
        ///     play.
        /// </returns>
        IEnumerable<IMove> GetAllMoves(IPosition position);

        /// <summary>
        ///     Gets the best <seealso cref="IMove" /> in an <seealso cref="IPosition" /> that this <seealso cref="IPlayer" /> can
        ///     play.
        /// </summary>
        /// <param name="position">The <seealso cref="IPosition" /> in which to look for the best <seealso cref="IMove" />.</param>
        /// <returns>
        ///     The best <seealso cref="IMove" /> in the <seealso cref="position" /> that this <seealso cref="IPlayer" /> can
        ///     play.
        /// </returns>
        IMove GetBestMove(IPosition position);

        /// <summary>
        ///     Makes an <seealso cref="IMove" /> on the <seealso cref="IPosition" /> and returns a new instance of
        ///     <seealso cref="IPosition" />.
        /// </summary>
        /// <param name="move">The <seealso cref="IMove" /> that is to be played.</param>
        /// <returns>An <seealso cref="IPosition" /> with the <seealso cref="move" /> already made on it.</returns>
        IPosition MakeMove(IMove move);

        /// <summary>
        ///     Undoes the <seealso cref="IMove" /> on the <seealso cref="IPosition" /> and returns a new instance of
        ///     <seealso cref="IPosition" />.
        /// </summary>
        /// <param name="move">The <seealso cref="IMove" /> that is to be undone.</param>
        /// <returns>An <seealso cref="IPosition" /> with this <seealso cref="IMove" /> undone on it.</returns>
        IPosition UnMakeMove(IMove move);
    }
}