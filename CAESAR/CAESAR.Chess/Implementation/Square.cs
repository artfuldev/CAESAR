using System;
using System.Linq;

namespace CAESAR.Chess.Implementation
{
    public class Square : ISquare
    {
        public Square(IBoard board, IFile file, IRank rank, string name, bool isLight = false)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board),
                    "A square cannot be constructed without a board reference");
            if (file == null)
                throw new ArgumentNullException(nameof(file),
                    "A square cannot be constructed without a file reference");
            if (rank == null)
                throw new ArgumentNullException(nameof(rank),
                    "A square cannot be constructed without a rank reference");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("A square cannot have an empty name", nameof(name));
            Board = board;
            File = file;
            Rank = rank;
            Name = name;
            IsLight = isLight;
        }
        public IBoard Board { get; }
        public IFile File { get; }
        public IRank Rank { get; }
        public string Name { get; }
        public bool IsLight { get; }
        public bool IsDark => !IsLight;

        public override string ToString()
        {
            return Name;
        }
    }
}