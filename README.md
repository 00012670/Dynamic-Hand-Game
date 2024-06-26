# Dynamic Hand Game

This is a console-based implementation of the game Rock Paper Scissors Lizard Spock. The game is an extension of the classic game of chance, Rock Paper Scissors, created by Sam Kass and Karen Bryla. 

## Features

- This game provides default moves: Rock, Paper, Scissors, Lizard, Spock.
- Ability to customize the game with your own moves.
- The game includes a help option that displays a table of all possible move outcomes.
- The game uses HMAC to ensure a fair game.
- The game includes a help option that displays a table of all possible move outcomes.

 ## How to Run
 
1. Make sure you have .NET Core installed on your machine. If not, you can download it from the [official website](https://dotnet.microsoft.com/download).
2. Open your terminal or command prompt.
3. Navigate to the project directory using the `cd` command.
4. Run the command `dotnet run` followed by your moves. For example, `dotnet run rock paper scissors lizard spock`.

## How to Play

#### 1. Run the Program

- Execute the program.
- If no arguments are provided, the game will use the default moves.

#### 2. Gameplay

Upon starting, the game will:

- Display an HMAC of the computer’s move.
- Present a list of available moves.
- Display "0 - exit" for exiting the game.
- Display "? - help" for displaying a table of all possible move outcomes.

To play:

- Enter the number corresponding to your move.
- Press enter.

The game will then show:

- The result.
- The computer’s move.
- The HMAC key.

Afterward, the game will automatically restart.

#### 3. Exiting the Game

- To exit, simply enter 0.


## Project Structure

- `GameFlowManager` --> controls the game flow.
- `CryptoService`   --> responsible for generating keys and calculating HMAC.
- `GameRules`       --> determines the winner of the game.
- `TableGenerator`  --> generates the help table.
- `OutputHandler`   --> handles all console output.
- `InputHandler`    --> handles all input operations for the game.
- `Program.cs`      --> entry point of the program.

## Note

The game requires an odd number of unique moves. If an even number of moves, less than two, or any duplicate moves, are provided, the game will display an error message and exit.
