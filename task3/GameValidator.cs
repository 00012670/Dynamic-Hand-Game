using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class GameValidator
    {
        public static bool AreMovesValid(string[] moves)
        {
            // Check if the number of moves is greater than one
            if (moves.Length <= 1)
            {
                Console.WriteLine(OutputHandler.ErrorInsufficientMoves);
                return false;
            }
            // Check if the number of moves is odd
            if (moves.Length % 2 == 0)
            {
                Console.WriteLine(OutputHandler.ErrorOddMoves);
                return false;
            }
            // Check if the arguments are non-repeating
            if (new HashSet<string>(moves).Count != moves.Length)
            {
                Console.WriteLine(OutputHandler.ErrorNonRepeating);
                return false;
            }
            return true;
        }

        public static bool AreObjectsInitialized(GameFlowManager game)
        {
            if (game.Moves == null || game.OutputHandler == null || game.Random == null || game.CryptoService == null || game.InputHandler == null)
            {
                Console.WriteLine("One or more required objects are not initialized.");
                return false;
            }
            return true;
        }

    }
}
