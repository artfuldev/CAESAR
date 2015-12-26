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
        private IFile _file;
        private IRank _rank;
        private string _name;
        public IFile File => _file ?? (_file = Board.Files.FirstOrDefault(x => x.Contains(this)));
        public IRank Rank => _rank?? (_rank = Board.Ranks.FirstOrDefault(x => x.Contains(this)));
        public string Name => _name ?? (_name = (File.Name + Rank.Number.ToString()));
        public bool IsLight { get; }
        public bool IsDark => !IsLight;

        public override string ToString()
        {
            return Name;
        }
    }
}