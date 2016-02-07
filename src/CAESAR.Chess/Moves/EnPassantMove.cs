using System;
using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Moves
{
    /// <summary>
    ///     A special <seealso cref="CapturingMove" /> played by the <seealso cref="Pawn" />, that can only occur immediately
    ///     after a <seealso cref="Pawn" /> of the opposing <seealso cref="Side" /> moves two <seealso cref="IRank" />s forward
    ///     from its starting position and this <seealso cref="Pawn" /> could have captured it had the enemy
    ///     <seealso cref="Pawn" /> moved only one <seealso cref="ISquare" /> forward. The opponent captures the just-moved
    ///     pawn "as it passes" through the first square. The resulting position is the same as if the enemy
    ///     <seealso cref="Pawn" /> had moved only one <seealso cref="ISquare" /> forward and this <seealso cref="Pawn" /> had
    ///     captured it normally.
    /// </summary>
    public class EnPassantMove : CapturingMove
    {
        /// <summary>
        ///     Instantiates an <seealso cref="EnPassantMove" /> with a source <seealso cref="ISquare" /> and a destination square
        ///     name.
        /// </summary>
        /// <param name="source">The <seealso cref="ISquare" /> in which the move originates.</param>
        /// <param name="destinationSquareName">The name of the destination square.</param>
        public EnPassantMove(ISquare source, string destinationSquareName) : base(source, destinationSquareName)
        {
            var destinationFile = destinationSquareName[0];
            var destinationRank = char.MinValue;
            switch (destinationSquareName[1])
            {
                case '3':
                    destinationRank = '4';
                    break;
                case '6':
                    destinationRank = '5';
                    break;
            }
            if (destinationRank != '4' && destinationRank != '5')
                throw new ArgumentOutOfRangeException(nameof(destinationSquareName), destinationSquareName);
            EnPassantPawnSquareName = destinationFile.ToString() + destinationRank;
        }

        /// <summary>
        ///     The name of the <seealso cref="ISquare" /> in which the enemy <seealso cref="Pawn" /> now resides.
        /// </summary>
        public string EnPassantPawnSquareName { get; }

        /// <summary>
        ///     Makes this <seealso cref="EnPassantMove" /> on its <seealso cref="Move.Position" />.
        ///     <para>
        ///         It plays a <seealso cref="CapturingMove" /> on the enemy en passant <seealso cref="Pawn" />.
        ///     </para>
        /// </summary>
        /// <param name="position">The <seealso cref="IPosition" /> on which this <seealso cref="CapturingMove" /> is to be made.</param>
        /// <returns>A <seealso cref="IPosition" /> in which the current <seealso cref="CapturingMove" /> is already made.</returns>
        protected override IPosition MakeImplementation(IPosition position)
        {
            position = base.MakeImplementation(position);
            position.Board.GetSquare(EnPassantPawnSquareName).Piece = null;
            return position;
        }
    }
}