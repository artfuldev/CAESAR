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
    public class RookMovesGeneratorTests
    {
        private readonly IMovesGenerator _movesGenerator = new RookMovesGenerator();
        private readonly IBoard _board = new Board();
        private readonly IPiece _piece = new Rook(true);
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
        [InlineData("d1", "d2,d3,d4,d5,d6,d7,d8,e1,f1,g1,h1,c1,b1,a1")]
        [InlineData("f3", "f4,f5,f6,f7,f8,g3,h3,f2,f1,e3,d3,c3,b3,a3")]
        public void RookAtXGeneratesYMoves(string x, string y)
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
        [InlineData("d1", "d2,d3,d4,d5,d6,d7,d8,e2,e1,f1,g1,h1,c1,b1,a1","")]
        [InlineData("f3", "f4,g3,e3,f2,","")]
        [InlineData("f3", "f6,h5,g3,d5", "f4,f5,f2,f1,e3,d3,c3,b3,a3")]
        public void RookAtXWithOwnPiecesAtYGeneratesZMoves(string x, string y, string z)
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
        [InlineData("d1", "d2,e1,c1", "d2,e1,c1")]
        [InlineData("f3", "f4,g3,f2,e3", "f4,g3,f2,e3")]
        [InlineData("f3", "f6,g3,b3", "f4,f5,f6,g3,f2,f1,e3,d3,c3,b3")]
        public void RookAtXWithEnemyPiecesAtYGeneratesZMoves(string x, string y, string z)
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