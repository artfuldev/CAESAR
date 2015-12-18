using System;
using System.Linq;

namespace CAESAR.Chess.Implementation
{
    public class Square : ISquare
    {
        public Square(IBoard board, bool isLight = false)
        {
            if (board == null)
                throw new ArgumentNullException();
            Board = board;
            IsLight = isLight;
        }
        public IBoard Board { get; }
        public IFile File => Board.Files.FirstOrDefault(x => x.Contains(this));
        public IRank Rank => Board.Ranks.FirstOrDefault(x => x.Contains(this));
        public string Name => (File.Name + Rank.Number.ToString()).ToLowerInvariant();
        public bool IsLight { get; }
        public bool IsDark => !IsLight;

        public override string ToString()
        {
            return Name;
        }
    }
}