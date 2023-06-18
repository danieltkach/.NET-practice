using BattleshipLibrary;

// Configuration
string[] allowedLetters = { "A", "B", "C", "D", "E", "F", "G" };
int gridSize = allowedLetters.Length;
const int shipsPerPlayer = 3;
ConsoleUI consoleUI = new(allowedLetters, gridSize, shipsPerPlayer);
GridUI gridUI = new(allowedLetters, gridSize);
Beep();

// Player 1 registration
PlayerInfo player1 = new();
consoleUI.PlayerRegistration(player1, "Name for player 1: ");

// Player 2 registration
PlayerInfo player2 = new();
consoleUI.PlayerRegistration(player2, "Name for player 2: ");

// Game loop
Clear();
gridUI.PrintBlankGrid();
do
{
    gridUI.UpdateGrid(player1);
    consoleUI.PlayerTurn(player1, player2, "Player 1's turn");
    if (player1.Points == shipsPerPlayer) break;

    gridUI.UpdateGrid(player2);
    consoleUI.PlayerTurn(player2, player1, "Player 2's turn");
    if (player2.Points == shipsPerPlayer) break;
} while (true);

// Game ending
SetCursorPosition(WindowWidth / 2 - 20, 0);
ForegroundColor = ConsoleColor.Red;
Write("* * * * * * * * * * * * * * * * * * * * * ");
ForegroundColor = ConsoleColor.Yellow;
SetCursorPosition(WindowWidth / 2 - 20, 1);
if (player1.Points == shipsPerPlayer)
{
    Write($"               {player1.Username} Wins!");
}
else
{
    Write($"               {player2.Username} Wins!");
}
SetCursorPosition(WindowWidth / 2 - 20, 2);
ForegroundColor = ConsoleColor.Red;
WriteLine("* * * * * * * * * * * * * * * * * * * * * ");
Beep();
ReadKey();
ResetColor();
SetCursorPosition(25, 16);
ForegroundColor = ConsoleColor.Yellow;
WriteLine("...thank you for playing!");
ReadKey();