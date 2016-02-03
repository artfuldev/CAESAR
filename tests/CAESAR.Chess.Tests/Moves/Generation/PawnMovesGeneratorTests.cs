using System;
using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Moves.Generation;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Players;
using CAESAR.Chess.Positions;
using Xunit;

namespace CAESAR.Chess.Tests.Moves.Generation
{
    public class PawnMovesGeneratorTests
    {
        private readonly IPiece _blackPiece = new Pawn(Side.Black);
        private readonly IBoard _board = new Position().ClearBoard().Board;
        private readonly IMovesGenerator _movesGenerator = new PawnMovesGenerator();
        private readonly IPiece _piece = new Pawn(Side.White);

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
        [InlineData("d2", "d2d3,d2d4")]
        [InlineData("f3", "f3f4")]
        [InlineData("f7", "f7f8Q,f7f8R,f7f8B,f7f8N")]
        public void PawnAtXGeneratesYMoves(string x, string y)
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
        [InlineData("d7", "d7d6,d7d5")]
        [InlineData("f3", "f3f2")]
        [InlineData("d6", "d6d5")]
        [InlineData("f2", "f2f1Q,f2f1R,f2f1B,f2f1N")]
        public void BlackPawnAtXGeneratesYMoves(string x, string y)
        {
            var square = _board.GetSquare(x);
            square.Piece = _blackPiece;
            _movesGenerator.Square = square;
            var moves = _movesGenerator.Moves;
            var moveStrings = moves.Select(move => move.ToString());
            var expectedMoveStrings = y.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).ToHashSet();
            Assert.True(expectedMoveStrings.SetEquals(moveStrings));
        }

        [Theory]
        [InlineData("d2", "d3", "")]
        [InlineData("f3", "f4", "")]
        [InlineData("d2", "d4", "d2d3")]
        [InlineData("d7", "d8", "")]
        public void PawnAtXWithOwnPiecesAtYGeneratesZMoves(string x, string y, string z)
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
        [InlineData("d2", "", "d2d3,d2d4")]
        [InlineData("d2", "c3,d3,e3,c2,e2", "d2c3,d2e3")]
        [InlineData("f3", "e3,e4,f4,g4,g3", "f3e4,f3g4")]
        [InlineData("f3", "e4", "f3e4,f3f4")]
        [InlineData("f7", "g8", "f7f8Q,f7f8R,f7f8B,f7f8N,f7g8Q,f7g8R,f7g8B,f7g8N")]
        public void PawnAtXWithEnemyPiecesAtYGeneratesZMoves(string x, string y, string z)
        {
            var square = _board.GetSquare(x);
            var squares =
                y.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(sq => _board.GetSquare(sq));
            foreach (var pieceSquare in squares)
            {
                pieceSquare.Piece = new Pawn(Side.Black);
            }
            square.Piece =  _piece;
            _movesGenerator.Square = square;
            var moves = _movesGenerator.Moves;
            var moveStrings = moves.Select(move => move.ToString());
            var expectedMoveStrings = z.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).ToHashSet();
            Assert.True(expectedMoveStrings.SetEquals(moveStrings));
        }
    }
}