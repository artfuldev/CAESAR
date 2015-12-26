using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CAESAR.Chess.Implementation
{
    public class Rank : IRank
    {
        public Rank(IBoard board, byte number, IEnumerable<ISquare> squares)
        {
            if (board == null)
                throw new ArgumentNullException("A rank cannot be created without a board reference", nameof(board));
            if (number < 1 || number > 8)
                throw new ArgumentOutOfRangeException();
            if(squares == null || !squares.Any())
                throw new ArgumentNullException("A rank cannot be created without squares", nameof(squares));
            if (squares.Count() != 8)
                throw new ArgumentException("A rank can only be created with 8 squares", nameof(squares));

            Board = board;
            Number = number;
            Squares = squares.ToList();
        }

        public byte Number { get; }
        public IBoard Board { get; }
        public IReadOnlyCollection<ISquare> Squares { get; }
        public override string ToString()
        {
            return Number.ToString();
        }
    }
}