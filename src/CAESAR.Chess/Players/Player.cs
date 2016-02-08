using System;
using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Games;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Players
{
    /// <summary>
    ///     An <seealso cref="IPlayer" /> of the <seealso cref="IGame" /> of chess, belonging to one
    ///     <seealso cref="Core.Side" />. A player can have a <seealso cref="Name" />, can make and undo
    ///     <seealso cref="IMove" />s, and can get all or the best <seealso cref="IMove" /> in a particular
    ///     <seealso cref="IPosition" />.
    /// </summary>
    public class Player : IPlayer
    {
        private readonly Random _random = new Random();

        /// <summary>
        ///     Instantiates a <seealso cref="Player" /> with the given <seealso cref="name" />.
        /// </summary>
        /// <param name="name">The optional <seealso cref="Name" /> for the <seealso cref="Player" />.</param>
        public Player(string name = null)
        {
            Name = name;
        }

        /// <summary>
        ///     The <seealso cref="Core.Side" /> to which this <seealso cref="IPlayer" /> belongs.
        /// </summary>
        public Side Side { get; set; }

        /// <summary>
        ///     The name of this <seealso cref="IPlayer" />.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Gets all the <seealso cref="IMove" />s in an <seealso cref="IPosition" /> that this <seealso cref="IPlayer" /> can
        ///     play.
        /// </summary>
        /// <param name="position">The <seealso cref="IPosition" /> in which to look for <seealso cref="IMove" />s.</param>
        /// <returns>
        ///     All the <seealso cref="IMove" />s in the <seealso cref="position" /> that this <seealso cref="IPlayer" /> can
        ///     play.
        /// </returns>
        public IEnumerable<IMove> GetAllMoves(IPosition position)
        {
            return position.Board.Squares.Where(square => square.HasPiece && square.Piece.Side == Side)
                .Select(square => square.Piece).SelectMany(piece => piece.Moves);
        }

        /// <summary>
        ///     Gets the best <seealso cref="IMove" /> in an <seealso cref="IPosition" /> that this <seealso cref="IPlayer" /> can
        ///     play.
        /// </summary>
        /// <param name="position">The <seealso cref="IPosition" /> in which to look for the best <seealso cref="IMove" />.</param>
        /// <returns>
        ///     The best <seealso cref="IMove" /> in the <seealso cref="position" /> that this <seealso cref="IPlayer" /> can
        ///     play.
        /// </returns>
        public IMove GetBestMove(IPosition position)
        {
            var allMoves = GetAllMoves(position).ToList();
            var capture = allMoves.RandomOrDefault(x => x is CapturingMove || x is CapturingPromotionMove);
            var move = allMoves.RandomOrDefault();
            return capture ?? move;
        }

        /// <summary>
        ///     Makes an <seealso cref="IMove" /> on the <seealso cref="IPosition" /> and returns a new instance of
        ///     <seealso cref="IPosition" />.
        /// </summary>
        /// <param name="move">The <seealso cref="IMove" /> that is to be played.</param>
        /// <returns>An <seealso cref="IPosition" /> with the <seealso cref="move" /> already made on it.</returns>
        public IPosition MakeMove(IMove move)
        {
            return move?.Make(this);
        }

        /// <summary>
        ///     Undoes the <seealso cref="IMove" /> on the <seealso cref="IPosition" /> and returns a new instance of
        ///     <seealso cref="IPosition" />.
        /// </summary>
        /// <param name="move">The <seealso cref="IMove" /> that is to be undone.</param>
        /// <returns>An <seealso cref="IPosition" /> with this <seealso cref="IMove" /> undone on it.</returns>
        public IPosition UnMakeMove(IMove move)
        {
            return move?.Undo(this);
        }
    }
}