using System;
using System.Linq;
using CAESAR.Chess.Helpers;
using CAESAR.Chess.Implementation;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Moves.Generation;
using CAESAR.Chess.Pieces;
using Xunit;

namespace CAESAR.Chess.Tests.Moves.Generation
{
    public class QueenMovesGeneratorTests
    {
        private readonly IMovesGenerator _movesGenerator = new QueenMovesGenerator();
        private readonly IBoard _board = new Board();
        private readonly IPiece _piece = new Queen(true);
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
        [InlineData("d1", "d1d2,d1d3,d1d4,d1d5,d1d6,d1d7,d1d8,d1e2,d1f3,d1g4,d1h5,d1e1,d1f1,d1g1,d1h1,d1c1,d1b1,d1a1,d1c2,d1b3,d1a4")]
        [InlineData("f3", "f3f4,f3f5,f3f6,f3f7,f3f8,f3g4,f3h5,f3g3,f3h3,f3g2,f3h1,f3f2,f3f1,f3e2,f3d1,f3e3,f3d3,f3c3,f3b3,f3a3,f3e4,f3d5,f3c6,f3b7,f3a8")]
        public void QueenAtXGeneratesYMoves(string x, string y)
        {
            var square = _board.GetSquare(x);
            _player.Place(square, _piece);
            _movesGenerator.Square = square;
            var moves = _movesGenerator.Moves;
            var moveStrings = moves.Select(move => move.ToString());
            var expectedMoveStrings = y.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToHashSet();
            Assert.True(expectedMoveStrings.SetEquals(moveStrings));
        }

        [Theory]
        [InlineData("d1", "d2,d3,d4,d5,d6,d7,d8,e2,f3,g4,h5,e1,f1,g1,h1,c1,b1,a1,c2,b3,a4","")]
        [InlineData("f3", "f4,f5,f6,f7,f8,g4,h5,g3,h3,g2,h1,f2,f1,e2,d1,e3,d3,c3,b3,a3,e4,d5,c6,b7,a8","")]
        [InlineData("f3", "f6,h5,g3,d5", "f3f4,f3f5,f3g4,f3g2,f3h1,f3f2,f3f1,f3e2,f3d1,f3e3,f3d3,f3c3,f3b3,f3a3,f3e4")]
        public void QueenAtXWithOwnPiecesAtYGeneratesZMoves(string x, string y, string z)
        {
            var square = _board.GetSquare(x);
            var ownPieceSquares =
                y.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(sq => _board.GetSquare(sq));
            foreach (var ownPieceSquare in ownPieceSquares)
            {
                _player.Place(ownPieceSquare, new Pawn(true));
            }
            _player.Place(square, _piece);
            _movesGenerator.Square = square;
            var moves = _movesGenerator.Moves;
            var moveStrings = moves.Select(move => move.ToString());
            var expectedMoveStrings = z.Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries).ToHashSet();
            Assert.True(expectedMoveStrings.SetEquals(moveStrings));
        }

        [Theory]
        [InlineData("d1", "d2,d3,d4,d5,d6,d7,d8,e2,f3,g4,h5,e1,f1,g1,h1,c1,b1,a1,c2,b3,a4", "d1d2,d1e2,d1e1,d1c1,d1c2")]
        [InlineData("f3", "f4,f5,f6,f7,f8,g4,h5,g3,h3,g2,h1,f2,f1,e2,d1,e3,d3,c3,b3,a3,e4,d5,c6,b7,a8", "f3f4,f3g4,f3g3,f3g2,f3f2,f3e2,f3e3,f3e4")]
        [InlineData("f3", "f6,h5,g3,d5", "f3f4,f3f5,f3f6,f3g4,f3h5,f3g3,f3g2,f3h1,f3f2,f3f1,f3e2,f3d1,f3e3,f3d3,f3c3,f3b3,f3a3,f3e4,f3d5")]
        public void QueenAtXWithEnemyPiecesAtYGeneratesZMoves(string x, string y, string z)
        {
            var square = _board.GetSquare(x);
            var ownPieceSquares =
                y.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(sq => _board.GetSquare(sq));
            foreach (var ownPieceSquare in ownPieceSquares)
            {
                _player.Place(ownPieceSquare, new Pawn(false));
            }
            _player.Place(square, _piece);
            _movesGenerator.Square = square;
            var moves = _movesGenerator.Moves;
            var moveStrings = moves.Select(move => move.ToString());
            var expectedMoveStrings = z.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToHashSet();
            Assert.True(expectedMoveStrings.SetEquals(moveStrings));
        }
    }
}