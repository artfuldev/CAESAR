using System;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves.Exceptions;
using CAESAR.Chess.Moves.Notations;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Players;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Moves
{
    /// <summary>
    ///     Represents a move that is made on the chessboard. <seealso cref="Move" />s can be made and unmade on
    ///     <seealso cref="IPosition" />s, and can be written as a <seealso cref="string" /> in various
    ///     <seealso cref="INotation" />s.
    /// </summary>
    public abstract class Move : IMove
    {
        public string MoveString { get; protected set; }

        /// <summary>
        ///     The <seealso cref="IPosition" /> to which the <seealso cref="Move" /> belongs.
        /// </summary>
        public IPosition Position { get; }
        /// <summary>
        /// The <seealso cref="IPosition"/> that is arrived at after playing the <seealso cref="Move"/>.
        /// </summary>
        private IPosition NextPosition { get; set; }
        /// <summary>
        /// Instantiates a <seealso cref="Move"/> with the specified <seealso cref="IPosition"/>, <seealso cref="Core.Side"/>, and <seealso cref="string"/> representation of the move.
        /// </summary>
        /// <param name="position">The <seealso cref="IPosition"/> to which this <seealso cref="Move"/> belongs.</param>
        /// <param name="side">The <seealso cref="Core.Side"/> to which this <seealso cref="Move"/> belongs.</param>
        /// <param name="move">The <seealso cref="string"/> representation of this <seealso cref="Move"/>.</param>
        protected Move(IPosition position, Side side, string move)
        {
            Position = (IPosition)position.Clone();
            Side = side;
            if (string.IsNullOrWhiteSpace(move))
                throw new ArgumentNullException(nameof(move), "Move String cannot be null or empty");
            MoveString = move;
        }

        /// <summary>
        /// Returns a string that represents the current <seealso cref="Move"/>.
        /// </summary>
        /// <returns>
        /// A string that represents the current <seealso cref="Move"/>.
        /// </returns>
        public override string ToString() => MoveString;

        /// <summary>
        ///     The <seealso cref="Core.Side" /> to which the <seealso cref="Move" /> belongs.
        /// </summary>
        public Side Side { get; }

        /// <summary>
        ///     Makes the <seealso cref="Move" /> on the <seealso cref="IPosition" /> and returns a new instance of
        ///     <seealso cref="IPosition" />.
        /// </summary>
        /// <returns>An <seealso cref="IPosition" /> with this <seealso cref="Move" /> already made on it.</returns>
        public IPosition Make(IPlayer player)
        {
            if(player.Side != Side)
                throw new CannotMakeMoveException(MoveOperationFailureReason.PlayerNotOnCorrectSide);
            return NextPosition ?? (NextPosition = MakeImplementation((IPosition)Position.Clone()));
        }
        /// <summary>
        /// Makes this <seealso cref="Move"/> on its <seealso cref="Position"/> and sets the <seealso cref="NextPosition"/> on this <seealso cref="Move"/>. Its implementation varies.
        /// </summary>
        /// <param name="position">The <seealso cref="IPosition"/> on which this <seealso cref="Move"/> is to be made.</param>
        /// <returns>A <seealso cref="IPosition"/> in which the current <seealso cref="Move"/> is already made.</returns>
        protected abstract IPosition MakeImplementation(IPosition position);

        /// <summary>
        ///     Undoes the <seealso cref="Move" /> on the <seealso cref="IPosition" /> and returns a new instance of
        ///     <seealso cref="IPosition" />.
        /// </summary>
        /// <returns>An <seealso cref="IPosition" /> with this <seealso cref="Move" /> undone on it.</returns>
        public IPosition Undo(IPlayer player)
        {
            if (player.Side != Side)
                throw new CannotUndoMoveException(MoveOperationFailureReason.PlayerNotOnCorrectSide);
            return Position;
        }

        /// <summary>
        ///     Returns a string representation of the <seealso cref="Move" /> in the specified <seealso cref="INotation" />.
        /// </summary>
        /// <param name="notation">The <seealso cref="INotation" /> to be used to represent the <seealso cref="Move" />.</param>
        /// <returns>
        ///     A <seealso cref="string" /> representation of the <seealso cref="IMove" /> in the specified
        ///     <seealso cref="notation" />.
        /// </returns>
        public string ToString(INotation notation) => notation?.ToString(this);
    }
}