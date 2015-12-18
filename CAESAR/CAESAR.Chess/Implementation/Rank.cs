using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CAESAR.Chess.Implementation
{
    public class Rank : ReadOnlyCollection<ISquare>, IRank
    {
        public Rank(IBoard board, byte number) : base(board.Squares.Skip((number - 1)*8).Take(8).ToList())
        {
            if (board == null)
                throw new ArgumentNullException();
            if (number < 1 || number > 8)
                throw new ArgumentOutOfRangeException();
            Board = board;
            Number = number;
        }

        public byte Number { get; }
        public IBoard Board { get; }
        public override string ToString()
        {
            return Number.ToString();
        }
    }
}