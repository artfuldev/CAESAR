using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves;
using CAESAR.Chess.PlayArea;

namespace CAESAR.Chess.Players
{
    public class Player : IPlayer
    {
        public Side Side { get; set; }
        public Player(string name = null)
        {
            Name = name;
        }

        public string Name { get; }

        public IEnumerable<IMove> GetAllMoves(IBoard board)
        {
            var pieces =
                board.Squares.Where(square => square.HasPiece && square.Piece.Side == Side)
                    .Select(square => square.Piece);
            return pieces.SelectMany(piece => piece.Moves);
        }

        public IMove GetBestMove(IBoard board)
        {
            // For now
            // Play capturing moves first
            return GetAllMoves(board).FirstOrDefault(x => x is CapturingMove || x is CapturingPromotionMove) ??
                   GetAllMoves(board).FirstOrDefault();
        }

        public IBoard MakeMove(IMove move)
        {
            return move.Make(this);
        }

        public IBoard UnMakeMove(IMove move)
        {
            return move.Undo(this);
        }
    }
}