using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CAESAR.Chess.Implementation
{
    public class File : ReadOnlyCollection<ISquare>, IFile
    {
        public File(IBoard board, char name) : base((board?.Squares?.Skip(name - 97)?.Where((x, i) => i%8 == 0) ?? new Square[0]).ToList())
        {
            if (board == null)
                throw new ArgumentNullException();
            // 'a' <= name <= 'h'
            if (name < 97 || name > 104)
                throw new ArgumentOutOfRangeException();
            Board = board;
            Name = name;
        }

        public char Name { get; }
        public IBoard Board { get; }
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}