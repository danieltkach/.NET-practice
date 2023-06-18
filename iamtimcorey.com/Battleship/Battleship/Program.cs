using BattleshipLibrary;

// Configuration
string[] allowedLetters = { "A", "B", "C", "D", "E", "F", "G" };
int gridSize = allowedLetters.Length;
const int shipsPerPlayer = 1;
ConsoleUI consoleUI = new(allowedLetters, gridSize, shipsPerPlayer);
GridUI gridUI = new(allowedLetters, gridSize);

gridUI.PrintGrid();
gridUI.DrawAttack("A", 5, GridUI.AttackType.miss);
gridUI.DrawAttack("F", 2, GridUI.AttackType.miss);
gridUI.DrawAttack("E", 4, GridUI.AttackType.hit);
gridUI.DrawAttack("A", 3, GridUI.AttackType.hit);

ReadKey();

// Player 1 registration
PlayerInfo player1 = new();
consoleUI.PlayerRegistration(player1, "Name for player 1: ");

// Player 2 registration
PlayerInfo player2 = new();
consoleUI.PlayerRegistration(player2, "Name for player 2: ");

// Game loop
Clear();
do
{
    consoleUI.PlayerTurn(player1, player2, "Player 1's turn");
    if (player1.Points == shipsPerPlayer) break;
    consoleUI.PlayerTurn(player2, player1, "Player 2's turn");
    if (player2.Points == shipsPerPlayer) break;
} while (true);

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