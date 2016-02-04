using System;
using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Positions;

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

        public IEnumerable<IMove> GetAllMoves(IPosition position)
        {
            return position.Board.Squares.Where(square => square.HasPiece && square.Piece.Side == Side)
                    .Select(square => square.Piece).SelectMany(piece => piece.Moves);
        }

        private readonly Random _random = new Random();

        public IMove GetBestMove(IPosition board)
        {
            var allMoves = GetAllMoves(board).ToList();
            var capture = allMoves.FirstOrDefault(x => x is CapturingMove || x is CapturingPromotionMove);
            var move = allMoves.FirstOrDefault();
            return capture ?? move;
        }

        public IPosition MakeMove(IMove move)
        {
            return move?.Make(this);
        }

        public IPosition UnMakeMove(IMove move)
        {
            return move?.Undo(this);
        }
    }
}