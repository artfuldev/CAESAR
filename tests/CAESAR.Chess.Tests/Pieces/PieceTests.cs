using System;
using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Implementation;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Moves.Generation;
using CAESAR.Chess.Pieces;
using Xunit;

namespace CAESAR.Chess.Tests.Pieces
{
    public class PieceTests
    {
        private static readonly IEnumerable<IMove> MovesInstance = Enumerable.Empty<Move>();
        private static readonly ISquare SomeSquareInstance = new Board().GetSquare("a1");

        private static readonly IMovesGenerator _generator = new MovesGeneratorTestClass();

        private readonly IPiece _piece = new PieceTestClass("SS", 's', _generator);

        [Fact]
        public void PieceCannotBeConstructedWithoutName()
        {
            Assert.Throws<ArgumentNullException>(() => new PieceTestClass(null, 'a', _generator));
            Assert.Throws<ArgumentNullException>(() => new PieceTestClass("", 'a', _generator));
            Assert.Throws<ArgumentNullException>(() => new PieceTestClass(" ", 'a', _generator));
        }

        [Fact]
        public void PieceCannotBeConstructedWithoutMovesGenerator()
        {
            Assert.Throws<ArgumentNullException>(() => new PieceTestClass("SS", 'a', null));
        }

        [Fact]
        public void PieceReturnsMovesOfMovesGenerator()
        {
            Assert.Equal(MovesInstance, _piece.Moves);
        }

        [Fact]
        public void PieceSetsSquareOfMoveGenerator()
        {
            _piece.Square = SomeSquareInstance;
            Assert.Equal(SomeSquareInstance, _generator.Square);
        }

        private class PieceTestClass : Piece
        {
            public PieceTestClass(string name, char notation, IMovesGenerator movesGenerator)
                : base(true, name, notation, movesGenerator)
            {
            }
        }

        private class MovesGeneratorTestClass : IMovesGenerator
        {
            public IEnumerable<IMove> Moves => MovesInstance;
            public ISquare Square { get; set; }
        }
    }
}