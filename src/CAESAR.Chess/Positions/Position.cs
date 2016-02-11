using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Games;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Positions
{
    /// <summary>
    ///     Represents a chess position in a game of chess (in an <seealso cref="IGame" />). It is also an
    ///     <seealso cref="ICloneable" />, and holds the <seealso cref="IBoard" />, the <seealso cref="Side" /> to move, the
    ///     <seealso cref="Positions.CastlingRights" />, the en passant <seealso cref="ISquare" />, the half move clock for the
    ///     fifty-move rule, and also the number of full moves. It can be set up in a <seealso cref="FenString" /> and also be
    ///     converted to a <seealso cref="FenString" />.
    /// </summary>
    public class Position : IPosition
    {
        /// <summary>
        ///     A <seealso cref="FenString" /> for the starting <seealso cref="Position" /> in chess.
        /// </summary>
        private static readonly FenString StartingPositionFenString =
            "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

        /// <summary>
        ///     A <seealso cref="FenString" /> for an empty <seealso cref="Position" />.
        /// </summary>
        private static readonly FenString EmptyPositionFenString =
            "8/8/8/8/8/8/8/8 w - - 0 1";

        /// <summary>
        ///     Instantiates a <seealso cref="Position" /> with the given <seealso cref="FenString" />.
        /// </summary>
        /// <param name="fenString">The <seealso cref="FenString" /> to set up the <seealso cref="Position" /> with.</param>
        public Position(FenString fenString = null)
        {
            Board = new Board(this);
            fenString = fenString ?? StartingPositionFenString;
            SetPosition(fenString);
        }

        /// <summary>
        ///     An empty position, with a clear board and no castling availability. Perfect to set up your own board, piece by
        ///     piece. Mainly used for testing.
        /// </summary>
        public static IPosition EmptyPosition => new Position(EmptyPositionFenString);

        /// <summary>
        ///     Return a clone of the current <seealso cref="Position" />.
        /// </summary>
        /// <returns>An <seealso cref="Position" /> that is the clone of the current <seealso cref="Position" />.</returns>
        public object Clone()
        {
            return new Position(ToFenString());
        }

        /// <summary>
        ///     The <seealso cref="IBoard" /> that belongs to this <seealso cref="Position" />.
        /// </summary>
        public IBoard Board { get; set; }

        /// <summary>
        ///     The <seealso cref="Side" /> that is to move next in this <seealso cref="Position" />.
        /// </summary>
        public Side SideToMove { get; set; }

        /// <summary>
        ///     The <seealso cref="Positions.CastlingRights" /> of this <seealso cref="Position" />.
        /// </summary>
        public CastlingRights CastlingRights { get; set; }

        /// <summary>
        ///     The en passant target <seealso cref="ISquare" /> of this <seealso cref="Position" />, if any.
        /// </summary>
        public ISquare EnPassantSquare { get; set; }

        /// <summary>
        ///     The number of half moves made without a capture or a pawn move, with respect to the fifty-move rule, to reach this
        ///     <seealso cref="Position" />.
        /// </summary>
        public byte HalfMoveClock { get; set; }

        /// <summary>
        ///     The number of full moves made in this <seealso cref="Position" />.
        /// </summary>
        public ushort FullMoveNumber { get; set; }

        /// <summary>
        ///     Sets up this <seealso cref="Position" /> as indicated by a specific <seealso cref="FenString" />.
        /// </summary>
        /// <param name="fenString">
        ///     The <seealso cref="FenString" /> according to which this <seealso cref="Position" /> must be
        ///     set up.
        /// </param>
        public void SetPosition(FenString fenString)
        {
            ResetPosition();

            // Piece Placement
            var rows = fenString.PiecePlacement.Split('/');
            var boardRows = Board.Ranks.Reverse().ToArray();
            for (var i = 0; i < boardRows.Length; i++)
            {
                var row = rows[i];
                var boardRow = boardRows[i].Squares.ToArray();
                var j = 0;
                foreach (var character in row)
                {
                    if (char.IsDigit(character))
                    {
                        var digit = byte.Parse(character.ToString());
                        for (var k = 0; k < digit; k++)
                            boardRow[j++].Piece = null;
                    }
                    else
                        boardRow[j++].Piece = character.GetPiece();
                }
            }

            SideToMove = fenString.ActiveColor.ToSide();
            CastlingRights = fenString.CastlingAvailablity.ToCastlingRights();
            EnPassantSquare = Board.GetSquare(fenString.EnPassantTargetSquare);
            HalfMoveClock = fenString.HalfMoveClock;
            FullMoveNumber = fenString.FullMoveNumber;
        }

        /// <summary>
        ///     Converts this <seealso cref="Position" /> to a <seealso cref="FenString" />.
        /// </summary>
        /// <returns>A <seealso cref="FenString" /> instance representing this <seealso cref="Position" />.</returns>
        public FenString ToFenString()
        {
            var piecePlacement = "";
            var rows = Board.Ranks.Reverse().ToArray();
            for (var i = 0; i < rows.Length; i++)
            {
                var squares = rows[i].Squares.ToArray();
                var emptySquareCount = 0;
                for (var j = 0; j < squares.Length; j++)
                {
                    var square = squares[j];
                    if (square.IsEmpty)
                    {
                        emptySquareCount++;
                        if (j == squares.Length - 1)
                            piecePlacement += emptySquareCount;
                    }
                    else
                    {
                        if (emptySquareCount != 0)
                            piecePlacement += emptySquareCount;
                        emptySquareCount = 0;
                        piecePlacement += square.Piece.Notation;
                    }
                }
                if (i != rows.Length - 1)
                    piecePlacement += "/";
            }

            var activeColor = SideToMove.GetActiveColor();
            var castlingAvailability = CastlingRights.ToCastlingAvailability();
            var enPassantSquare = EnPassantSquare?.Name ?? "-";
            return
                $"{piecePlacement} {activeColor} {castlingAvailability} {enPassantSquare} {HalfMoveClock} {FullMoveNumber}";
        }

        /// <summary>
        ///     Clears the <seealso cref="Board" /> of all <seealso cref="IPiece" />s.
        /// </summary>
        private void ClearBoard()
        {
            foreach (var square in Board.Squares)
                square.Piece = null;
        }

        /// <summary>
        ///     Resets the position to a blank <seealso cref="Board" />, <seealso cref="Side.White" /> set to move, 0 half moves,
        ///     full move number set to one, and all castling rights available.
        /// </summary>
        private void ResetPosition()
        {
            ClearBoard();
            SideToMove = Side.White;
            CastlingRights = CastlingRights.WhiteLong | CastlingRights.WhiteShort | CastlingRights.BlackLong |
                             CastlingRights.BlackShort;
            HalfMoveClock = 0;
            FullMoveNumber = 1;
        }
    }
}