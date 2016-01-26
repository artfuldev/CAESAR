using System;
using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Moves.Generation;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Players;
using Xunit;

namespace CAESAR.Chess.Tests.Moves.Generation
{
    public class KingMovesGeneratorTests
    {
        private readonly IBoard _board = new Board();
        private readonly IMovesGenerator _movesGenerator = new KingMovesGenerator();
        private readonly IPiece _piece = new King(Side.White);
        private readonly IPlayer _player = new Player();

        [Fact]
        public void MoveGeneratorWithoutSquareGeneratesEmptyMoves()
        {
            Assert.Equal(Enumerable.Empty<IMove>(), _movesGenerator.Moves);
        }

        [Fact]
        public void MoveGeneratorWithoutPieceGeneratesEmptyMoves()
        {
            _movesGenerator.Square = _board.GetSquare("a1");
            Assert.Equal(Enumerable.Empty<IMove>(), _movesGenerator.Moves);
        }

        [Theory]
        [InlineData("e1", "e1d1,e1d2,e1e2,e1f2,e1f1")]
        [InlineData("e2", "e2e3,e2f3,e2f2,e2f1,e2e1,e2d1,e2d2,e2d3")]
        public void KingAtXGeneratesYMoves(string x, string y)
        {
            var square = _board.GetSquare(x);
            _player.Place(square, _piece);
            _movesGenerator.Square = square;
            var moves = _movesGenerator.Moves;
            var moveStrings = moves.Select(move => move.ToString());
            var expectedMoveStrings = y.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).ToHashSet();
            Assert.True(expectedMoveStrings.SetEquals(moveStrings));
        }

        [Theory]
        [InlineData("e1", "d1,d2,e2,f2,f1", "")]
        [InlineData("e2", "e3,f3,f2,f1,e1,d1,d2,d3", "")]
        [InlineData("e2", "e3,d3", "e2f3,e2f2,e2f1,e2e1,e2d1,e2d2")]
        public void KingAtXWithOwnPiecesAtYGeneratesZMoves(string x, string y, string z)
        {
            var square = _board.GetSquare(x);
            var ownPieceSquares =
                y.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(sq => _board.GetSquare(sq));
            foreach (var ownPieceSquare in ownPieceSquares)
            {
                _player.Place(ownPieceSquare, new Pawn(Side.White));
            }
            _player.Place(square, _piece);
            _movesGenerator.Square = square;
            var moves = _movesGenerator.Moves;
            var moveStrings = moves.Select(move => move.ToString());
            var expectedMoveStrings = z.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).ToHashSet();
            Assert.True(expectedMoveStrings.SetEquals(moveStrings));
        }
    }
}