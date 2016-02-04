using System;
using CAESAR.Chess.PlayArea;
using CAESAR.Chess.Positions;

namespace CAESAR.Chess.Moves
{
    public class EnPassantMove : CapturingMove
    {
        public string EnPassantPawnSquareName { get; }
        public EnPassantMove(ISquare source, string destinationSquareName) : base(source, destinationSquareName)
        {
            var destinationFile = destinationSquareName[0];
            char destinationRank = char.MinValue;
            switch (destinationSquareName[1])
            {
                case '3':
                    destinationRank = '4';
                    break;
                case '6':
                    destinationRank = '5';
                    break;
            }
            if(destinationRank != '4' && destinationRank != '5')
                throw new ArgumentOutOfRangeException(nameof(destinationSquareName), destinationSquareName);
            EnPassantPawnSquareName = destinationFile.ToString() + destinationRank;
        }
        protected override IPosition MakeImplementation(IPosition position)
        {
            position = base.MakeImplementation(position);
            position.Board.GetSquare(EnPassantPawnSquareName).Piece = null;
            return position;
        }
    }
}