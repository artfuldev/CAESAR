using System;
using System.Collections.Generic;
using System.Linq;
using CAESAR.Chess.Core;
using CAESAR.Chess.Moves;
using CAESAR.Chess.Moves.Generation;
using CAESAR.Chess.Pieces;
using CAESAR.Chess.PlayArea;
using Xunit;

namespace CAESAR.Chess.Tests.Pieces
{
    public class PieceTests
    {
        private static readonly IEnumerable<IMove> MovesInstance = Enumerable.Empty<Move>();
        private static readonly ISquare SomeSquareInstance = new Board().GetSquare("a1");

        private static readonly IMovesGenerator Generator = new MovesGeneratorTestClass();

        private readonly IPiece _piece = new PieceTestClass(Generator);

        [Fact]
        public void PieceCannotBeConstructedWithoutMovesGenerator()
        {
            Assert.Throws<ArgumentNullException>(() => new PieceTestClass(null));
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
            Assert.Equal(SomeSquareInstance, (Generator as MovesGeneratorTestClass)?.Square);
        }

        private class PieceTestClass : Piece
        {
            public PieceTestClass(IMovesGenerator movesGenerator)
                : base(Side.White, PieceType.Pawn, movesGenerator)
            {
            }

            public override object Clone()
            {
                throw new NotImplementedException();
            }
        }

        private class MovesGeneratorTestClass : IMovesGenerator
        {
            public IEnumerable<IMove> Moves => MovesInstance;
            public ISquare Square { get; set; }
        }
    }
}