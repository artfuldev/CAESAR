using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAESAR.Chess.Implementation;
using Xunit;

namespace CAESAR.Chess.Tests
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class BoardTests
    {
        [Fact]
        public void PassingTests()
        {
            var board = new Board();
            var outputString = "";
            foreach (var square in board.Squares)
                outputString += square.Name + ", ";
            outputString.TrimEnd(',');
            Console.WriteLine(outputString);
        }
    }
}
