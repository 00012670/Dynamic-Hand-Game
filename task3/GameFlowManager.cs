using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class GameFlowManager
    {
        // Default moves for the game
        private static readonly string[] DefaultMoves = { "rock", "spock", "paper", "lizard", "scissors" };
        private string[] moves;                     // Array to store the moves for the current game
        private CryptoService cryptoService;        // CryptoService to generate keys and calculate HMAC
        private GameRules gameRules;                // GameRules to determine the winner of the game
        private TableGenerator tableGenerator;      // TableGenerator to generate the game table
        private Random random;                      // Random to generate random numbers
        private OutputHandler outputHandler;
        private InputHandler inputHandler;


        public GameFlowManager(string[] moves)
        {
            // If no moves are provided, use the default moves
            this.moves = (moves.Length == 0) ? DefaultMoves : moves;
            this.cryptoService = new CryptoService();
            this.gameRules = new GameRules();
            this.tableGenerator = new TableGenerator(this.gameRules);
            this.random = new Random();
            this.outputHandler = new OutputHandler();
            this.inputHandler = new InputHandler();
        }

        // Method to start the game
        public void Play()
        {
            // Check if the objects are initialized
            if (moves == null || outputHandler == null || random == null || cryptoService == null || inputHandler == null)
            {
                Console.WriteLine("One or more required objects are not initialized.");
                return;
            }

            // Check if the number of moves is odd
            if (moves.Length % 2 == 0)
            {
                outputHandler.DisplayErrorMessage(OutputHandler.ErrorOddMoves);
                return;
            }
            // Check if the arguments are non-repeating
            if (new HashSet<string>(moves).Count != moves.Length)
            {
                outputHandler.DisplayErrorMessage(OutputHandler.ErrorNonRepeating);
                return;
            }
            // Generate a random move for the computer
            int computerMove = random.Next(moves.Length);
            // Generate a key and calculate the HMAC
            byte[] key = cryptoService.GenerateKey();
            string hmacString = cryptoService.CalculateHMAC(key, moves[computerMove]);
            // Display the HMAC and the menu
            outputHandler.DisplayHMAC(hmacString);
            outputHandler.DisplayMenu(moves);
            string input = inputHandler.GetUserMove();
            ProcessInput(input, computerMove, key);
        }

        public void ProcessInput(string input, int computerMove, byte[] key)
        {
            // If the input is "?", generate the game table
            if (input == "?")
            {
                tableGenerator.GenerateTable(moves);
                return;
            }
            int playerMove;

            // Check if the input is valid
            if (!inputHandler.IsValidInput(input, out playerMove, moves.Length))
            {
                Console.WriteLine();
                outputHandler.DisplayErrorMessage(OutputHandler.ErrorInvalidInput);
                Console.WriteLine();
                return;
            }
            // If the player's move is 0, exit the game
            if (playerMove == 0)
            {
                Environment.Exit(0);
            }
            // Calculate the result of the game
            string result = gameRules.DetermineWinner(computerMove, playerMove, moves.Length);
            // Display the result of the game, the computer's move, and the original key
            outputHandler.DisplayGameResult(result, moves[playerMove - 1], moves[computerMove - 1], cryptoService.BytesToString(key));

        }
    }
}
