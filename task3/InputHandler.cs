using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class InputHandler
    {
        public string GetUserMove()
        {
            Console.Write("Enter your move: ");
            return Console.ReadLine() ?? string.Empty;
        }

        // Method to validate the user's input
        public bool IsValidInput(string input, out int playerMove, int movesLength)
        {
            // Try to parse the input as an integer and check if it's within the valid range
            return int.TryParse(input, out playerMove) && playerMove >= 0 && playerMove <= movesLength;
        }
    }
}
