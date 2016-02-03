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
    public class KnightMovesGeneratorTests
    {
        private readonly IBoard _board = new Board();
        private readonly IMovesGenerator _movesGenerator = new KnightMovesGenerator();
        private readonly IPiece _piece = new Knight(Side.White);

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
        [InlineData("d1", "d1b2,d1c3,d1e3,d1f2")]
        [InlineData("f3", "f3g5,f3h4,f3h2,f3g1,f3e1,f3d2,f3d4,f3e5")]
        [InlineData("b8", "b8d7,b8c6,b8a6")]
        public void KnightAtXGeneratesYMoves(string x, string y)
        {
            var square = _board.GetSquare(x);
            square.Piece = _piece;
            _movesGenerator.Square = square;
            var moves = _movesGenerator.Moves;
            var moveStrings = moves.Select(move => move.ToString());
            var expectedMoveStrings = y.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).ToHashSet();
            Assert.True(expectedMoveStrings.SetEquals(moveStrings));
        }

        [Theory]
        [InlineData("d1", "b2,c3,e3,f2", "")]
        [InlineData("f3", "g5,h4,h2,g1,e1,d2,d4,e5", "")]
        [InlineData("f3", "g5,d4", "f3h4,f3h2,f3g1,f3e1,f3d2,f3e5")]
        public void KnightAtXWithOwnPiecesAtYGeneratesZMoves(string x, string y, string z)
        {
            var square = _board.GetSquare(x);
            var squares =
                y.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(sq => _board.GetSquare(sq));
            foreach (var pieceSquare in squares)
            {
                pieceSquare.Piece = new Pawn(Side.White);
            }
            square.Piece = _piece;
            _movesGenerator.Square = square;
            var moves = _movesGenerator.Moves;
            var moveStrings = moves.Select(move => move.ToString());
            var expectedMoveStrings = z.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).ToHashSet();
            Assert.True(expectedMoveStrings.SetEquals(moveStrings));
        }

        [Theory]
        [InlineData("d1", "b2,c3,e3,f2", "d1b2,d1c3,d1e3,d1f2")]
        [InlineData("f3", "g5,h4,h2,g1,e1,d2,d4,e5", "f3g5,f3h4,f3h2,f3g1,f3e1,f3d2,f3d4,f3e5")]
        [InlineData("f3", "g5,d4", "f3g5,f3h4,f3h2,f3g1,f3e1,f3d2,f3d4,f3e5")]
        public void KnightAtXWithEnemyPiecesAtYGeneratesZMoves(string x, string y, string z)
        {
            var square = _board.GetSquare(x);
            var squares =
                y.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(sq => _board.GetSquare(sq));
            foreach (var pieceSquare in squares)
            {
                pieceSquare.Piece = new Pawn(Side.Black);
            }
            square.Piece = _piece;
            _movesGenerator.Square = square;
            var moves = _movesGenerator.Moves;
            var moveStrings = moves.Select(move => move.ToString());
            var expectedMoveStrings = z.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).ToHashSet();
            Assert.True(expectedMoveStrings.SetEquals(moveStrings));
        }
    }
}