using BattleshipLibrary;

// Configuration
string[] allowedLetters = { "A", "B", "C", "D", "E" };
const int gridSize = 5;
const int shipsPerPlayer = 3;
ConsoleUI consoleUI = new(allowedLetters, gridSize, shipsPerPlayer);

// Player 1 registration
PlayerInfo player1 = new();
consoleUI.PlayerRegistration(player1, "Name for player 1: ");

// Player 2 registration
PlayerInfo player2 = new();
consoleUI.PlayerRegistration(player2, "Name for player 2: ");

// Game loop
Clear();
bool gameRunning;
do
{
    consoleUI.PlayerTurn(player1, player2, "Player 1's turn");
    consoleUI.PlayerTurn(player2, player1, "Player 2's turn");
    gameRunning = (player1.Points < shipsPerPlayer) && (player2.Points < shipsPerPlayer);
} while (gameRunning);

if (player1.Points == shipsPerPlayer)
{
    WriteLine("Player 1 Wins!");
}
else
{
    WriteLine("Player 2 Wins!");
}

ReadKey();