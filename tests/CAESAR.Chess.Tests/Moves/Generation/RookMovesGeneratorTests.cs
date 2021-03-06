﻿using System;
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
    public class RookMovesGeneratorTests
    {
        private readonly IBoard _board = Position.EmptyPosition.Board;
        private readonly IMovesGenerator _movesGenerator = new RookMovesGenerator();
        private readonly IPiece _piece = new Rook(Side.White);

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
        [InlineData("d1", "d1d2,d1d3,d1d4,d1d5,d1d6,d1d7,d1d8,d1e1,d1f1,d1g1,d1h1,d1c1,d1b1,d1a1")]
        [InlineData("f3", "f3f4,f3f5,f3f6,f3f7,f3f8,f3g3,f3h3,f3f2,f3f1,f3e3,f3d3,f3c3,f3b3,f3a3")]
        public void RookAtXGeneratesYMoves(string x, string y)
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
        [InlineData("d1", "d2,d3,d4,d5,d6,d7,d8,e2,e1,f1,g1,h1,c1,b1,a1", "")]
        [InlineData("f3", "f4,g3,e3,f2,", "")]
        [InlineData("f3", "f6,h5,g3,d5", "f3f4,f3f5,f3f2,f3f1,f3e3,f3d3,f3c3,f3b3,f3a3")]
        public void RookAtXWithOwnPiecesAtYGeneratesZMoves(string x, string y, string z)
        {
            var square = _board.GetSquare(x);
            var squares =
                y.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(sq => _board.GetSquare(sq));
            foreach (var pieceSquare in squares)
            {
                pieceSquare.Piece = new Queen(Side.White);
            }
            square.Piece = _piece;
            _movesGenerator.Square = square;
            var moves = _movesGenerator.Moves;
            var moveStrings = moves.Select(move => move.ToString());
            var expectedMoveStrings = z.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).ToHashSet();
            Assert.True(expectedMoveStrings.SetEquals(moveStrings));
        }

        [Theory]
        [InlineData("d1", "d2,e1,c1", "d1d2,d1e1,d1c1")]
        [InlineData("f3", "f4,g3,f2,e3", "f3f4,f3g3,f3f2,f3e3")]
        [InlineData("f3", "f6,g3,b3", "f3f4,f3f5,f3f6,f3g3,f3f2,f3f1,f3e3,f3d3,f3c3,f3b3")]
        public void RookAtXWithEnemyPiecesAtYGeneratesZMoves(string x, string y, string z)
        {
            var square = _board.GetSquare(x);
            var squares =
                y.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(sq => _board.GetSquare(sq));
            foreach (var pieceSquare in squares)
            {
                pieceSquare.Piece = new Queen(Side.Black);
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