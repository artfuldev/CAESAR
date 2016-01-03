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
        [InlineData("d1", "d2,d3,d4,d5,d6,d7,d8,e2,f3,g4,h5,e1,f1,g1,h1,c1,b1,a1,c2,b3,a4")]
        [InlineData("f3", "f4,f5,f6,f7,f8,g4,h5,g3,h3,g2,h1,f2,f1,e2,d1,e3,d3,c3,b3,a3,e4,d5,c6,b7,a8")]
        public void QueenAtXGeneratesYMoves(string x, string y)
        {
            var square = _board.GetSquare(x);
            _player.Place(square, _piece);
            _movesGenerator.Square = square;
            var moves = _movesGenerator.Moves;
            var moveStrings = moves.Select(move => move.Destination.ToString());
            var expectedMoveStrings = y.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToHashSet();
            Assert.True(expectedMoveStrings.SetEquals(moveStrings));
        }

        [Theory]
        [InlineData("d1", "d2,d3,d4,d5,d6,d7,d8,e2,f3,g4,h5,e1,f1,g1,h1,c1,b1,a1,c2,b3,a4","")]
        [InlineData("f3", "f4,f5,f6,f7,f8,g4,h5,g3,h3,g2,h1,f2,f1,e2,d1,e3,d3,c3,b3,a3,e4,d5,c6,b7,a8","")]
        [InlineData("f3", "f6,h5,g3,d5", "f4,f5,g4,g2,h1,f2,f1,e2,d1,e3,d3,c3,b3,a3,e4")]
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
            var moveStrings = moves.Select(move => move.Destination.ToString());
            var expectedMoveStrings = z.Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries).ToHashSet();
            Assert.True(expectedMoveStrings.SetEquals(moveStrings));
        }

        [Theory]
        [InlineData("d1", "d2,d3,d4,d5,d6,d7,d8,e2,f3,g4,h5,e1,f1,g1,h1,c1,b1,a1,c2,b3,a4", "d2,e2,e1,c1,c2")]
        [InlineData("f3", "f4,f5,f6,f7,f8,g4,h5,g3,h3,g2,h1,f2,f1,e2,d1,e3,d3,c3,b3,a3,e4,d5,c6,b7,a8", "f4,g4,g3,g2,f2,e2,e3,e4")]
        [InlineData("f3", "f6,h5,g3,d5", "f4,f5,f6,g4,h5,g3,g2,h1,f2,f1,e2,d1,e3,d3,c3,b3,a3,e4,d5")]
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
            var moveStrings = moves.Select(move => move.Destination.ToString());
            var expectedMoveStrings = z.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToHashSet();
            Assert.True(expectedMoveStrings.SetEquals(moveStrings));
        }
    }
}