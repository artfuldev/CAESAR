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
            White.Side = Side.White;
            Black = black ?? new Player("Black");
            Black.Side = Side.Black;
            Moves = moves ?? new List<IMove>();
            if (board == null)
                SetupBoard();
        }

        public IBoard Board { get; set; }
        public IPlayer White { get; }
        public IPlayer Black { get; }
        public ICollection<IMove> Moves { get; }
        public IPlayer CurrentPlayer => (Moves?.Count ?? 0) % 2 == 0 ? White : Black;
        public Side SideToPlay => (Moves?.Count ?? 0) % 2 == 0 ? Side.White : Side.Black;

        public void PlayNextMove()
        {
            PlayNextMove(CurrentPlayer.GetBestMove(Board));
        }

        public void PlayNextMove(IMove move)
        {
            var board = CurrentPlayer.MakeMove(move, Board);
            if (board == Board)
                return;
            Board = board;
            Moves.Add(move);
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
                piecePlacements.Add((char)(97 + i * 7) + "1",new Rook(Side.White));
                piecePlacements.Add((char)(97 + i * 7) + "8", new Rook(Side.Black));
            }

            // Knights
            for (var i = 0; i < 2; i++)
            {
                piecePlacements.Add((char)(98 + i * 5) + "1",new Knight(Side.White));
                piecePlacements.Add((char)(98 + i * 5) + "8", new Knight(Side.Black));
            }

            // Bishops
            for (var i = 0; i < 2; i++)
            {
                piecePlacements.Add((char)(99 + i * 3) + "1",new Bishop(Side.White));
                piecePlacements.Add((char)(99 + i * 3) + "8", new Bishop(Side.Black));
            }

            // Queens
            piecePlacements.Add("d1",new Queen(Side.White));
            piecePlacements.Add("d8", new Queen(Side.Black));

            // Kings
            piecePlacements.Add("e1", new King(Side.White));
            piecePlacements.Add("e8", new King(Side.Black));

            foreach (var piecePlacement in piecePlacements)
            {
                Board.GetSquare(piecePlacement.Key).Piece = piecePlacement.Value;
            }
        }
    }
}