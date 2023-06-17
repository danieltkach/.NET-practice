using BattleshipLibrary;

// Configuration
string[] allowedLetters = { "A", "B", "C" };
const int gridSize = 3;
const int shipsPerPlayer = 1;
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

// Game ending
ForegroundColor = ConsoleColor.Red;
WriteLine("* * * * * * * * * * * * * * * * * * * * * ");
ForegroundColor = ConsoleColor.Yellow;
if (player1.Points == shipsPerPlayer)
{
    WriteLine($"               {player1.Username} Wins!");
}
else
{
    WriteLine($"               {player2.Username} Wins!");
}
ForegroundColor = ConsoleColor.Red;
WriteLine("* * * * * * * * * * * * * * * * * * * * * ");
ReadKey();
ResetColor();
WriteLine("\n...thank you for playing!");
ReadKey();