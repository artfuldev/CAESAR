using System;
using System.Text.RegularExpressions;

namespace CAESAR.Chess.Positions
{
    /// <summary>
    ///     A string of Forsyth-Edwards Notation (FEN). It is a notation to represent an <seealso cref="IPosition" /> with the
    ///     piece placement, castling availability, en passant square, active color, half move clock for the 50-move rule, and
    ///     the full move number.
    /// </summary>
    /// <remarks>https://en.wikipedia.org/wiki/Forsyth%E2%80%93Edwards_Notation</remarks>
    public class FenString
    {
        /// <summary>
        ///     The <seealso cref="Regex" /> to match a <seealso cref="FenString" />.
        /// </summary>
        private static readonly Regex FenRegex =
            new Regex(
                @"\A(?<PiecePlacement>[rnbqkRNBQK1-8]+/(?:[prnbqkPRNBQK1-8]+/){6}[rnbqkRNBQK1-8]+)\s(?<ActiveColor>[wb])\s(?<CastlingAvailability>[KQkq]{1,4}|-)\s(?<EnPassantTargetSquare>[a-h][36]|-)(\s(?<HalfMoveClock>[0-9]+)\s(?<FullMoveNumber>[0-9]+))?$",
                RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);

        /// <summary>
        ///     Instantiates a <seealso cref="FenString" /> with the given <seealso cref="string" /> representation.
        /// </summary>
        /// <param name="fen">The <seealso cref="string" /> representation of this <seealso cref="FenString" />.</param>
        public FenString(string fen)
        {
            fen = fen.Trim();
            var match = FenRegex.Match(fen);
            if (!match.Success)
                throw new ArgumentException("Incorrect string format", nameof(fen));
            var groups = match.Groups;
            PiecePlacement = groups["PiecePlacement"].ToString();
            CastlingAvailablity = groups["CastlingAvailability"].ToString();
            EnPassantTargetSquare = groups["EnPassantTargetSquare"].ToString();
            ActiveColor = groups["ActiveColor"].ToString()[0];
            byte parser;
            HalfMoveClock = byte.TryParse(groups["HalfMoveClock"]?.ToString(), out parser) ? parser : (byte) 0;
            ushort ushortParser;
            FullMoveNumber = ushort.TryParse(groups["FullMoveNumber"]?.ToString(), out ushortParser)
                ? ushortParser
                : (ushort) 1;
        }

        /// <summary>
        ///     A <seealso cref="string" /> detailing the placement of pieces in an <seealso cref="IPosition" />.
        /// </summary>
        public string PiecePlacement { get; }

        /// <summary>
        ///     A <seealso cref="char" /> representing the current side to play in an <seealso cref="IPosition" />.
        /// </summary>
        public char ActiveColor { get; }

        /// <summary>
        ///     A <seealso cref="string" /> representing the current castling availability in an <seealso cref="IPosition" />.
        /// </summary>
        public string CastlingAvailablity { get; }

        /// <summary>
        ///     The name of the En Passant Target square, if any, in this <seealso cref="IPosition" />.
        /// </summary>
        public string EnPassantTargetSquare { get; }

        /// <summary>
        ///     The number of half moves that have passed without a pawn move or a capture, for the fifty-move rule.
        /// </summary>
        public byte HalfMoveClock { get; }

        /// <summary>
        ///     The number of moves made to reach this <seealso cref="IPosition" />.
        /// </summary>
        public ushort FullMoveNumber { get; }

        /// <summary>
        ///     The <seealso cref="string" /> representation of this <seealso cref="FenString" />.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return
                $"{PiecePlacement} {ActiveColor} {CastlingAvailablity} {EnPassantTargetSquare} {HalfMoveClock} {FullMoveNumber}";
        }

        /// <summary>
        ///     Implicitly casts the <seealso cref="FenString" /> to a <seealso cref="string" />.
        /// </summary>
        /// <param name="fen">The <seealso cref="FenString" /> to cast to <seealso cref="string" />.</param>
        public static implicit operator string(FenString fen)
        {
            return fen.ToString();
        }
        
        /// <summary>
        ///     Implicitly casts a <seealso cref="string" /> to a <seealso cref="FenString" />.
        /// </summary>
        /// <param name="fen">The <seealso cref="string" /> to cast to a <seealso cref="FenString" />.</param>
        public static implicit operator FenString(string fen)
        {
            return new FenString(fen);
        }
    }
}