using BattleshipLibrary;

// Configuration
string[] allowedLetters = { "A", "B", "C", "D", "E", "F", "G" };
int gridSize = allowedLetters.Length;
const int shipsPerPlayer = 5;
ConsoleUI consoleUI = new(allowedLetters, gridSize, shipsPerPlayer);

// Player 1 registration
PlayerInfo player1 = new();
consoleUI.PlayerRegistration(player1, "Name for player 1: ");

// Player 2 registration
PlayerInfo player2 = new();
consoleUI.PlayerRegistration(player2, "Name for player 2: ");

// Game loop
Clear();
consoleUI.grid.PrintBlankGrid();
PlayerInfo winner;
PlayerInfo looser;
do
{
    consoleUI.grid.UpdateGrid(player1);
    consoleUI.PlayerTurn(player1, player2, $"{player1.Username}'s turn");
    if (player1.Points == shipsPerPlayer)
    {
        winner = player1;
        looser = player2;
        break;
    }

    consoleUI.grid.UpdateGrid(player2);
    consoleUI.PlayerTurn(player2, player1, $"{player2.Username}'s turn");
    if (player2.Points == shipsPerPlayer)
    {
        winner = player2;
        looser = player1;
        break;
    }
} while (true);

// Game ending
// Print ships and show winner grid
consoleUI.grid.UpdateGrid(looser);
consoleUI.grid.PrintShips(winner);

// Print signs
int cursorX = WindowWidth / 2 - 20;
SetCursorPosition(cursorX, 0);
ForegroundColor = ConsoleColor.Red;
Write("* * * * * * * * * * * * * * * * * * * * * ");
ForegroundColor = ConsoleColor.Yellow;
SetCursorPosition(cursorX, 1);
Write($"               {winner.Username} Wins!");
SetCursorPosition(cursorX, 2);
ForegroundColor = ConsoleColor.Red;
WriteLine("* * * * * * * * * * * * * * * * * * * * * ");
Beep();
ReadKey();
ResetColor();
SetCursorPosition(25, 16);
ForegroundColor = ConsoleColor.Yellow;
WriteLine("...thank you for playing!");
ReadKey();