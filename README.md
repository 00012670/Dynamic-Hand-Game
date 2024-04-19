# Dynamic Hand Game

Dynamic Hand Game is a console-based game that is a variant of the classic "Rock, Paper, Scissors" game, with the added flexibility of custom moves. 
The game was popularized by the TV show "The Big Bang Theory" and is also known as "Rock, Paper, Scissors, Lizard, Spock". 

## Features

- Play the classic game with default moves: Rock, Paper, Scissors, Lizard, Spock.
- Ability to customize the game with your own moves.
- Secure move selection by the computer using HMAC.
- Display a help table showing the result of each possible move combination.

## How to Play

1. Run the program. If no arguments are provided, the game will use the default moves.
2. The game will display a menu with the available moves, an option to exit, and an option for help.
3. Enter the number corresponding to your move and press Enter.
4. The game will display the result, the computer's move, and the original HMAC key.

## Code Structure

- `GameFlowManager` --> controls the flow of the game.
- `CryptoService`   --> responsible for generating keys and calculating HMAC.
- `GameRules`       --> determines the winner of the game.
- `TableGenerator`  --> generates the game table.
- `OutputHandler`   --> handles all output operations for the game.
- `InputHandler`    --> handles all input operations for the game.


