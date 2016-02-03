using System.Collections.Generic;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Players
{
    public interface IPlayer
    {
        Side Side { get; set; }
        string Name { get; }
        IEnumerable<IMove> GetAllMoves(IPosition position);
        IMove GetBestMove(IPosition position);
        IPosition MakeMove(IMove move);
        IPosition UnMakeMove(IMove move);
    }
}