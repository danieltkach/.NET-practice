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
PlayerInfo winner;
PlayerInfo looser;
do
{
    gridUI.UpdateGrid(player1);
    consoleUI.PlayerTurn(player1, player2, "Player 1's turn");
    if (player1.Points == shipsPerPlayer)
    {
        winner = player1;
        looser = player2;
        break;
    }

    gridUI.UpdateGrid(player2);
    consoleUI.PlayerTurn(player2, player1, "Player 2's turn");
    if (player2.Points == shipsPerPlayer)
    {
        winner = player2;
        looser = player1;
        break;
    }
} while (true);

// Game ending
// Print ships and show winner grid
gridUI.UpdateGrid(looser);
gridUI.PrintShips(winner);

// Print signs
SetCursorPosition(WindowWidth / 2 - 20, 0);
ForegroundColor = ConsoleColor.Red;
Write("* * * * * * * * * * * * * * * * * * * * * ");
ForegroundColor = ConsoleColor.Yellow;
SetCursorPosition(WindowWidth / 2 - 20, 1);
Write($"               {winner.Username} Wins!");
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