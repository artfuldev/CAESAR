﻿using System.Linq;

namespace CAESAR.Chess.Games.Statuses.Updaters
{
    public class ThreefoldRepetitionUpdater : IStatusUpdater
    {
        public void UpdateStatus(IGame game)
        {
            var lastBoard = game.Board.ToString();
            var boards = game.Moves.Select(move => move.Board.ToString()).ToArray();
            if (!boards.Contains(lastBoard) || boards.Count(b => b == lastBoard) != 3)
                return;
            game.Status = Status.Drawn;
            game.StatusReason = StatusReason.ThreefoldRepetition;
        }
    }
}