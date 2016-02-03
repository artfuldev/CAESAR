using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Pieces;
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
            return GetAllMoves(board).FirstOrDefault();
        }

        public IBoard MakeMove(IMove move)
        {
            if(Side != move.Side)
                throw new CannotMakeMoveException(MoveOperationFailureReason.PlayerNotOnCorrectSide);
            return move.Make();
        }

        public IBoard UnMakeMove(IMove move)
        {
            if (Side != move.Side)
                throw new CannotUndoMoveException(MoveOperationFailureReason.PlayerNotOnCorrectSide);
            return move.Undo();
        }
    }
}