using System.Collections.Generic;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Players
{
    public interface IPlayer
    {
        Side Side { get; set; }
        string Name { get; }
        IEnumerable<IMove> GetAllMoves(IBoard board);
        IMove GetBestMove(IBoard board);
        IBoard MakeMove(IMove move);
        IBoard UnMakeMove(IMove move);
    }
}