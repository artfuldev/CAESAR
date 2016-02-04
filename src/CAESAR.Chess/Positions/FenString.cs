using System;
using System.Text.RegularExpressions;

namespace CAESAR.Chess.Positions
{
    public class FenString
    {
        private static readonly Regex FenRegex =
            new Regex(
                @"\A(?<PiecePlacement>[rnbqkRNBQK1-8]+/(?:[prnbqkPRNBQK1-8]+/){6}[rnbqkRNBQK1-8]+)\s(?<ActiveColor>[wb])\s(?<CastlingAvailability>[KQkq]{1,4}|-)\s(?<EnPassantTargetSquare>[a-h][36]|-)(\s(?<HalfMoveClock>[0-9]+)\s(?<FullMoveNumber>[0-9]+))?$",
                RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);

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
        public string PiecePlacement { get;}
        public char ActiveColor { get; }
        public string CastlingAvailablity { get; }
        public string EnPassantTargetSquare { get; }
        public byte HalfMoveClock { get; }
        public ushort FullMoveNumber { get; }
        public override string ToString()
        {
            return
                $"{PiecePlacement} {ActiveColor} {CastlingAvailablity} {EnPassantTargetSquare} {HalfMoveClock} {FullMoveNumber}";
        }
        public static implicit operator string(FenString fen)
        {
            return fen.ToString();
        }

        public static implicit operator FenString(string fen)
        {
            return new FenString(fen);
        }
    }
}