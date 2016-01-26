using System.Collections.Generic;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Players
{
    public interface IPlayer
    {
        string Name { get; }
        IEnumerable<IMove> GetAllMoves(IBoard board, Side sideToPlay);
        IMove GetBestMove(IBoard board, Side sideToPlay);
        void Place(IBoard board, IPiece piece, string squareName);
        void Place(ISquare square, IPiece piece);
        void MakeMove(IMove move);
        void UnMakeMove(IMove move);
    }
}