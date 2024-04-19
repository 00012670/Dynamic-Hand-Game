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
        private static readonly string[] DefaultMoves = { "rock", "Spock",  "paper", "lizard", "scissors" };
        public string[] Moves { get; private set; }
        public CryptoService CryptoService { get; private set; }
        public GameRules GameRules { get; private set; }
        public TableGenerator TableGenerator { get; private set; }
        public Random Random { get; private set; }
        public OutputHandler OutputHandler { get; private set; }
        public InputHandler InputHandler { get; private set; }


        public GameFlowManager(string[] moves)
        {
            // If no moves are provided, use the default moves
            this.Moves = (moves.Length == 0) ? DefaultMoves : moves;
            this.CryptoService = new CryptoService();
            this.GameRules = new GameRules();
            this.TableGenerator = new TableGenerator(this.GameRules);
            this.Random = new Random();
            this.OutputHandler = new OutputHandler();
            this.InputHandler = new InputHandler();
        }

        // Method to start the game
        public void Play()
        {
            if (!GameValidator.AreMovesValid(Moves))
            {
                return;
            }

            // Check if the objects are initialized
            if (!GameValidator.AreMovesValid(Moves) || !GameValidator.AreObjectsInitialized(this))
            {
                return;
            }

            // Generate a random move for the computer, starting from 1 instead of 0
            int computerMove = Random.Next(1, Moves.Length + 1);
            // Generate a key and calculate the HMAC
            byte[] key = CryptoService.GenerateKey();
            string hmacString = CryptoService.CalculateHMAC(key, Moves[computerMove - 1]);
            // Display the HMAC and the menu
            OutputHandler.DisplayHMAC(hmacString);
            OutputHandler.DisplayMenu(Moves);
            string input = InputHandler.GetUserMove();
            ProcessInput(input, computerMove, key);

        }

        public void ProcessInput(string input, int computerMove, byte[] key)
        {
            // If the input is "?", generate the game table
            if (input == "?")
            {
                TableGenerator.GenerateTable(Moves);
                return;
            }
            int playerMove;

            // Check if the input is valid
            if (!InputHandler.IsValidInput(input, out playerMove, Moves.Length))
            {
                Console.WriteLine();
                OutputHandler.DisplayErrorMessage(OutputHandler.ErrorInvalidInput);
                Console.WriteLine();
                return;
            }
            // If the player's move is 0, exit the game
            if (playerMove == 0)
            {
                Environment.Exit(0);
            }
            // Calculate the result of the game
            string result = GameRules.DetermineWinner(computerMove, playerMove, Moves.Length);
            // Display the result of the game, the computer's move, and the original key
            OutputHandler.DisplayGameResult(result, Moves[playerMove - 1], Moves[computerMove - 1], CryptoService.BytesToString(key));
        }
    }
}
