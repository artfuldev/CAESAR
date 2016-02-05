using System;
using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Positions
{
    public class Position : IPosition
    {
        private static readonly FenString StartingPositionFenString =
            "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        private static readonly FenString EmptyPositionFenString =
            "8/8/8/8/8/8/8/8 w - - 0 1";


        public Position(FenString fenString = null)
        {
            Board = new Board(this);
            fenString = fenString ?? StartingPositionFenString;
            SetPosition(fenString);
        }

        public static IPosition EmptyPosition => new Position(EmptyPositionFenString);

        public void ClearBoard()
        {
            foreach (var square in Board.Squares)
                square.Piece = null;
        }

        private void ResetPosition()
        {
            ClearBoard();
            SideToMove = Side.White;
            CastlingRights = CastlingRights.WhiteLong | CastlingRights.WhiteShort | CastlingRights.BlackLong |
                             CastlingRights.BlackShort;
            HalfMoveClock = 0;
            FullMoveNumber = 1;
        }
        public object Clone()
        {
            return new Position(ToFenString());
        }

        public IBoard Board { get; set; }
        public Side SideToMove { get; set; }
        public CastlingRights CastlingRights { get; set; }
        public ISquare EnPassantSquare { get; set; }
        public byte HalfMoveClock { get; set; }
        public ushort FullMoveNumber { get; set; }
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

        public FenString ToFenString()
        {
            var piecePlacement = "";
            var rows = Board.Ranks.Reverse().ToArray();
            for (var i = 0; i < rows.Length; i++)
            {
                var squares = rows[i].Squares.ToArray();
                var emptySquareCount = 0;
                for(var j=0;j<squares.Length;j++)
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
    }
}