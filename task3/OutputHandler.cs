using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class OutputHandler
    {
        // Error messages for invalid game setup
        public const string ErrorOddMoves = "Error: The number of moves must be odd.";
        public const string ErrorNonRepeating = "Error: The arguments must be non-repeating.";
        public const string ErrorInvalidInput = "Invalid input. Please enter a number from the menu.";
        public const string ErrorInsufficientMoves = "Error: The number of moves must be greater than one.";

        public void DisplayHMAC(string hmac)
        {
            Console.WriteLine($"HMAC: \n{hmac}");
        }

        public void DisplayMenu(string[] moves)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Available moves:");
            for (int i = 0; i < moves.Length; i++)
            {
                sb.AppendLine($"{i + 1} - {moves[i]}");
            }
            sb.AppendLine("0 - exit");
            sb.AppendLine("? - help");
            Console.Write(sb.ToString());
        }
        public void DisplayGameResult(string result, string playerMove, string computerMove, string hmacKey)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"Your move: {playerMove}");
            sb.AppendLine($"Computer move: {computerMove}");
            sb.AppendLine(result);
            sb.AppendLine($"HMAC key: \n{hmacKey}");
            sb.AppendLine();
            Console.Write(sb.ToString());
        }

        public void DisplayErrorMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
