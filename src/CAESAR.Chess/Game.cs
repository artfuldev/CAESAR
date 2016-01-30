using System.Collections.Generic;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Players;

namespace CAESAR.Chess
{
    /// <summary>
    /// Represents a game of chess
    /// </summary>
    public class Game : IGame
    {
        public Game(IBoard board, IPlayer white, IPlayer black, ICollection<IMove> moves)
        {
            Board = board ?? new Board();
            White = white ?? new Player("White");
            Black = black ?? new Player("Black");
            Moves = moves ?? new List<IMove>();
            if (board == null)
                SetupBoard();
        }

        public IBoard Board { get; }
        public IPlayer White { get; }
        public IPlayer Black { get; }
        public ICollection<IMove> Moves { get; }
        public IPlayer CurrentPlayer => (Moves?.Count ?? 0)%2 == 0 ? White : Black;
        public Side SideToPlay => (Moves?.Count ?? 0)%2 == 0 ? Side.White : Side.Black;

        public void PlayNextMove()
        {
            PlayNextMove(CurrentPlayer.GetBestMove(Board, SideToPlay));
        }

        public void PlayNextMove(IMove move)
        {
            CurrentPlayer.MakeMove(move);
            Moves.Add(move);
        }

        public void PlayNextMove(string move)
        {
            // TODO: Add promotion, check , enpassant etc
            var source = move.Substring(0, 2);
            var destination = move.Substring(2, 2);
            var moveToPlay = new Move(Board.GetSquare(source).Piece, Board.GetSquare(destination));
            PlayNextMove(moveToPlay);
        }

        private void SetupBoard()
        {
            // Pawns
            for (var i = 0; i < 8; i++)
            {
                var pawn = new Pawn(Side.White);
                White.Place(Board, pawn, (char) (97 + i) + "2");
                pawn = new Pawn(Side.Black);
                Black.Place(Board, pawn, (char) (97 + i) + "7");
            }

            // Rooks

            for (var i = 0; i < 2; i++)
            {
                var rook = new Rook(Side.White);
                White.Place(Board, rook, (char) (97 + i*7) + "1");
                rook = new Rook(Side.Black);
                Black.Place(Board, rook, (char) (97 + i*7) + "8");
            }

            // Knights
            for (var i = 0; i < 2; i++)
            {
                var knight = new Knight(Side.White);
                White.Place(Board, knight, (char) (98 + i*5) + "1");
                knight = new Knight(Side.Black);
                Black.Place(Board, knight, (char) (98 + i*5) + "8");
            }

            // Bishops
            for (var i = 0; i < 2; i++)
            {
                var bishop = new Bishop(Side.White);
                White.Place(Board, bishop, (char) (99 + i*3) + "1");
                bishop = new Bishop(Side.Black);
                Black.Place(Board, bishop, (char) (99 + i*3) + "8");
            }

            // Queens
            var queen = new Queen(Side.White);
            White.Place(Board, queen, "d1");
            queen = new Queen(Side.Black);
            Black.Place(Board, queen, "d8");

            // Kings
            var king = new King(Side.White);
            White.Place(Board, king, "e1");
            king = new King(Side.Black);
            Black.Place(Board, king, "e8");
        }
    }
}