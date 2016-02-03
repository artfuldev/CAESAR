using System;
using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Games.Exceptions;
using CAESAR.Chess.Games.Statuses;
using CAESAR.Chess.Games.Statuses.Updaters;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Players;

namespace CAESAR.Chess.Games
{
    /// <summary>
    /// Represents a game of chess
    /// </summary>
    public class Game : IGame
    {
        private static readonly ICollection<IStatusUpdater> DefaultStatusUpdaters = new List<IStatusUpdater>()
        {
            new InProgressUpdater(),
            new InCheckUpdater(),
            new WinByCheckmateUpdater(),
            new ThreefoldRepetitionUpdater()
        }; 
        public Game(IBoard board, IPlayer white, IPlayer black, ICollection<IMove> moves, ICollection<IStatusUpdater> statusUpdaters = null)
        {
            StatusUpdaters = statusUpdaters;
            Board = board ?? new Board();
            White = white ?? new Player("White");
            White.Side = Side.White;
            Black = black ?? new Player("Black");
            Black.Side = Side.Black;
            Moves = moves ?? new List<IMove>();
            StatusUpdaters = statusUpdaters ?? DefaultStatusUpdaters;
            if (board == null)
                SetupBoard();
        }

        public IBoard Board { get; private set; }
        public IPlayer White { get; }
        public IPlayer Black { get; }
        public ICollection<IMove> Moves { get; }
        public IPlayer CurrentPlayer => (Moves?.Count ?? 0) % 2 == 0 ? White : Black;
        public IPlayer CurrentOpponent => CurrentPlayer == White ? Black : White;
        public bool CurrentSideInCheck { get; set; }
        public Side SideToPlay => (Moves?.Count ?? 0) % 2 == 0 ? Side.White : Side.Black;

        public void Play()
        {
            switch (Status)
            {
                case Status.YetToBegin:
                case Status.InProgress:
                    Play(CurrentPlayer.GetBestMove(Board));
                    break;
                default:
                    throw new CannotPlayGameException(Status, StatusReason);
            }
        }

        public void Play(IMove move)
        {
            Board = CurrentPlayer.MakeMove(move) ?? Board;
            Moves.Add(move);
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            foreach (var updater in StatusUpdaters)
                updater.UpdateStatus(this);
        }

        public ICollection<IStatusUpdater> StatusUpdaters { get; }
        public Status Status { get; set; } = Status.YetToBegin;
        public StatusReason StatusReason { get; set; } = StatusReason.GameJustBegan;

        private void SetupBoard()
        {
            var piecePlacements = new Dictionary<string, IPiece>();

            // Pawns
            for (var i = 0; i < 8; i++)
            {
                piecePlacements.Add((char) (97 + i) + "2", new Pawn(Side.White));
                piecePlacements.Add((char) (97 + i) + "7", new Pawn(Side.Black));
            }

            // Rooks

            for (var i = 0; i < 2; i++)
            {
                piecePlacements.Add((char) (97 + i*7) + "1", new Rook(Side.White));
                piecePlacements.Add((char) (97 + i*7) + "8", new Rook(Side.Black));
            }

            // Knights
            for (var i = 0; i < 2; i++)
            {
                piecePlacements.Add((char) (98 + i*5) + "1", new Knight(Side.White));
                piecePlacements.Add((char) (98 + i*5) + "8", new Knight(Side.Black));
            }

            // Bishops
            for (var i = 0; i < 2; i++)
            {
                piecePlacements.Add((char) (99 + i*3) + "1", new Bishop(Side.White));
                piecePlacements.Add((char) (99 + i*3) + "8", new Bishop(Side.Black));
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
    }
}