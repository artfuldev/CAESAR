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
    public class KingMovesGeneratorTests
    {
        private readonly IBoard _board = Position.EmptyPosition.Board;
        private readonly IMovesGenerator _movesGenerator = new KingMovesGenerator();
        private readonly IPiece _piece = new King(Side.White);

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
            square.Piece = _piece;
            _movesGenerator.Square = square;
            var moves = _movesGenerator.Moves;
            var moveStrings = moves.Select(move => move.ToString());
            var expectedMoveStrings = y.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToHashSet();
            Assert.True(expectedMoveStrings.SetEquals(moveStrings));
        }

        [Theory]
        [InlineData("e1", "d1,d2,e2,f2,f1", "")]
        [InlineData("e2", "e3,f3,f2,f1,e1,d1,d2,d3", "")]
        [InlineData("e2", "e3,d3", "e2f3,e2f2,e2f1,e2e1,e2d1,e2d2")]
        public void KingAtXWithOwnPiecesAtYGeneratesZMoves(string x, string y, string z)
        {
            var square = _board.GetSquare(x);
            var squares =
                y.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(sq => _board.GetSquare(sq));
            foreach (var pieceSquare in squares)
            {
                pieceSquare.Piece = new Queen(Side.White);
            }
            square.Piece = _piece;
            _movesGenerator.Square = square;
            var moves = _movesGenerator.Moves;
            var moveStrings = moves.Select(move => move.ToString());
            var expectedMoveStrings = z.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToHashSet();
            Assert.True(expectedMoveStrings.SetEquals(moveStrings));
        }

        [Theory]
        [InlineData("rnbqk2r/pppp1ppp/5n2/2b1p3/2B1P3/5N2/PPPP1PPP/RNBQK2R w KQkq - 1 4", "e1g1")]
        [InlineData("rnbqk2r/pppp1ppp/5n2/2b1p3/2B1P3/5N2/PPPP1PPP/RNBQK2R w Qkq - 1 4", "")]
        [InlineData("rnbqk2r/pppp1ppp/5n2/2b1p3/2B1P3/5N2/PPPP1PPP/RNBQK2R b k - 1 4", "e8g8")]
        [InlineData("rnbqk2r/pppp1ppp/5n2/2b1p3/2B1P3/5N2/PPPP1PPP/RNBQK2R b KQ - 1 4", "")]
        [InlineData("r1bqk1nr/pp3pbp/2npp1p1/2p5/4P3/2NPB1P1/PPP1NPBP/R2QK2R w KQkq - 6 12", "e1g1")]
        [InlineData("r1bqk1nr/pp3pbp/2npp1p1/2p5/4P3/2NPB1P1/PPPQNPBP/R3K2R w Kkq - 6 12", "e1g1")]
        [InlineData("r1bqk1nr/pp3pbp/2npp1p1/2p5/4P3/2NPB1P1/PPPQNPBP/R3K2R w KQkq - 6 12", "e1g1,e1c1")]
        [InlineData("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1","")]
        public void FenStringGeneratesCorrectCastlingMoves(string fen, string castlingMoves)
        {
            IPosition position = new Position(fen);
            var player = new Player() { Side = position.SideToMove };
            var moves = player.GetAllMoves(position).OfType<CastlingMove>();
            var moveStrings = moves.Select(move => move.ToString());
            var expectedMoveStrings = castlingMoves.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToHashSet();
            Assert.True(expectedMoveStrings.SetEquals(moveStrings));
        }
    }
}