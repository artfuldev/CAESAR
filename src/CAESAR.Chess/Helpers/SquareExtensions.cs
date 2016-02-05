using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Helpers
{
    /// <summary>
    ///     Useful extensions for an <seealso cref="ISquare" />.
    /// </summary>
    public static class SquareExtensions
    {
        /// <summary>
        ///     Gets a single <seealso cref="ISquare" /> adjacent to a particular <seealso cref="ISquare" /> in a particular
        ///     <seealso cref="Direction" />.
        /// </summary>
        /// <param name="square">The <seealso cref="ISquare" /> around which to look for the adjacent <seealso cref="ISquare" />.</param>
        /// <param name="direction">The <seealso cref="Direction" /> in which to look for the adjacent <seealso cref="ISquare" />.</param>
        /// <returns>
        ///     The <seealso cref="ISquare" /> adjacent to the <seealso cref="square" /> in the specified
        ///     <seealso cref="Direction" /> if available, null otherwise.
        /// </returns>
        public static ISquare GetAdjacentSquareInDirection(this ISquare square, Direction direction)
        {
            return square.GetAdjacentSquaresInDirection(direction).FirstOrDefault();
        }

        /// <summary>
        ///     Gets an <seealso cref="IEnumerable{ISquare}" /> adjacent to a particular <seealso cref="ISquare" /> with in a
        ///     particular <seealso cref="Direction" />.
        /// </summary>
        /// <param name="square">The <seealso cref="ISquare" /> around which to look for the adjacent <seealso cref="ISquare" />s.</param>
        /// <param name="direction">The <seealso cref="Direction" /> in which to look for the adjacent <seealso cref="ISquare" />s.</param>
        /// <returns>
        ///     The <seealso cref="ISquare" />s adjacent to the <seealso cref="square" /> in the specified
        ///     <seealso cref="Direction" /> if available, as an <seealso cref="IEnumerable{ISquare}" />.
        /// </returns>
        public static IEnumerable<ISquare> GetAdjacentSquaresInDirection(this ISquare square, Direction direction)
        {
            if (ReferenceEquals(null, square) || direction == Direction.None)
                yield break;

            var rankIndex = square.File.Squares.ToList().IndexOf(square);
            var fileIndex = square.Rank.Squares.ToList().IndexOf(square);

            switch (direction)
            {
                case Direction.Up:
                    while (rankIndex < 7)
                        yield return square.File.Squares.ElementAt(++rankIndex);
                    break;
                case Direction.Right:
                    while (fileIndex < 7)
                        yield return square.Rank.Squares.ElementAt(++fileIndex);
                    break;
                case Direction.Down:
                    while (rankIndex > 0)
                        yield return square.File.Squares.ElementAt(--rankIndex);
                    break;
                case Direction.Left:
                    while (fileIndex > 0)
                        yield return square.Rank.Squares.ElementAt(--fileIndex);
                    break;
                case Direction.UpRight:
                    while (rankIndex < 7 && fileIndex < 7)
                        yield return square.Board.Files.ElementAt(++fileIndex).Squares.ElementAt(++rankIndex);
                    break;
                case Direction.DownRight:
                    while (rankIndex > 0 && fileIndex < 7)
                        yield return square.Board.Files.ElementAt(++fileIndex).Squares.ElementAt(--rankIndex);
                    break;
                case Direction.DownLeft:
                    while (rankIndex > 0 && fileIndex > 0)
                        yield return square.Board.Files.ElementAt(--fileIndex).Squares.ElementAt(--rankIndex);
                    break;
                case Direction.UpLeft:
                    while (rankIndex < 7 && fileIndex > 0)
                        yield return square.Board.Files.ElementAt(--fileIndex).Squares.ElementAt(++rankIndex);
                    break;
            }
        }
    }
}