using System.Collections.Generic;
using CAESAR.Chess.Core;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Positions
{
    public class Position : IPosition
    {
        public Position(IBoard board = null, Side sideToMove = Side.White, CastlingRights castlingRights = CastlingRights.WhiteLong|CastlingRights.WhiteShort|CastlingRights.BlackLong|CastlingRights.BlackShort, ISquare enPassantSquare = null, byte halfMoveClock = 0, ushort fullMoveNumber = 1)
        {
            Board = board ?? new Board(this);
            if (board == null)
                SetupBoard();
            SideToMove = sideToMove;
            CastlingRights = castlingRights;
            EnPassantSquare = enPassantSquare;
            HalfMoveClock = halfMoveClock;
            FullMoveNumber = fullMoveNumber;
        }

        public IPosition ClearBoard()
        {
            var position = new Position()
            {
                Board = (IBoard)Board.Clone(),
                SideToMove = Side.White,
                CastlingRights = CastlingRights.WhiteLong | CastlingRights.WhiteShort | CastlingRights.BlackLong | CastlingRights.BlackShort,
                HalfMoveClock = 0,
                FullMoveNumber = 1
            };
            foreach (var square in position.Board.Squares)
                square.Piece = null;
            return position;
        }

        private void SetupBoard()
        {
            var piecePlacements = new Dictionary<string, IPiece>();

            // Pawns
            for (var i = 0; i < 8; i++)
            {
                piecePlacements.Add((char)(97 + i) + "2", new Pawn(Side.White));
                piecePlacements.Add((char)(97 + i) + "7", new Pawn(Side.Black));
            }

            // Rooks

            for (var i = 0; i < 2; i++)
            {
                piecePlacements.Add((char)(97 + i * 7) + "1", new Rook(Side.White));
                piecePlacements.Add((char)(97 + i * 7) + "8", new Rook(Side.Black));
            }

            // Knights
            for (var i = 0; i < 2; i++)
            {
                piecePlacements.Add((char)(98 + i * 5) + "1", new Knight(Side.White));
                piecePlacements.Add((char)(98 + i * 5) + "8", new Knight(Side.Black));
            }

            // Bishops
            for (var i = 0; i < 2; i++)
            {
                piecePlacements.Add((char)(99 + i * 3) + "1", new Bishop(Side.White));
                piecePlacements.Add((char)(99 + i * 3) + "8", new Bishop(Side.Black));
            }

            // Queens
            piecePlacements.Add("d1", new Queen(Side.White));
            piecePlacements.Add("d8", new Queen(Side.Black));

            // Kings
            piecePlacements.Add("e1", new King(Side.White));
            piecePlacements.Add("e8", new King(Side.Black));

            foreach (var piecePlacement in piecePlacements)
            {
                Board.GetSquare(piecePlacement.Key).Piece = piecePlacement.Value;
            }
        }
        public object Clone()
        {
            return new Position()
            {
                Board = (IBoard)Board.Clone(),
                SideToMove = SideToMove,
                CastlingRights = CastlingRights,
                HalfMoveClock = HalfMoveClock,
                FullMoveNumber = FullMoveNumber
            };
        }

        public IBoard Board { get; set; }
        public Side SideToMove { get; set; }
        public CastlingRights CastlingRights { get; set; }
        public ISquare EnPassantSquare { get; set; }
        public byte HalfMoveClock { get; set; }
        public ushort FullMoveNumber { get; set; }
    }
}