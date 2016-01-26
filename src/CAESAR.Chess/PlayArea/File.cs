﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CAESAR.Chess.PlayArea
{
    public class File : IFile
    {
        public File(IBoard board, char name, IEnumerable<ISquare> squares)
        {
            if (board == null)
                throw new ArgumentNullException("A file cannot be created without a board reference", nameof(board));
            if (name < 97 || name > 104)
                throw new ArgumentOutOfRangeException("A file can only have names from a to h", nameof(name));
            if (squares == null)
                throw new ArgumentNullException("A file cannot be created without squares", nameof(squares));
            var list = squares as List<ISquare> ?? squares.ToList();
            if (!list.Any())
                throw new ArgumentNullException("A file cannot be created without squares", nameof(squares));
            if (list.Count() != 8)
                throw new ArgumentException("A file can only be created with 8 squares", nameof(squares));

            Board = board;
            Name = name;
            Squares = list.AsReadOnly();
        }

        public char Name { get; }
        public IBoard Board { get; }
        public IReadOnlyCollection<ISquare> Squares { get; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}