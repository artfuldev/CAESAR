﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAESAR.Chess.Implementation;

namespace CAESAR.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var board = new Board();
            var outputString = "";
            foreach (var square in board.Squares)
                outputString += square.Name + ", ";
            outputString.TrimEnd(',');
            Console.WriteLine(outputString);
            Console.ReadLine();
        }
    }
}
