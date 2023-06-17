using BattleshipLibrary;

// Configuration
const int maxShips = 2;
string[] allowedLetters = { "A", "B", "C", "D", "E" };
ConsoleUI consoleUI = new(allowedLetters, maxShips);

// Player 1 registration
consoleUI.WelcomeMessage();
consoleUI.PrintRules(); 
PlayerInfo player1 = new(); 
consoleUI.ReadPlayerInfo(player1, "Name for player 1: ");
consoleUI.ReadShipLocations(player1);

// Player 2 registration
consoleUI.WelcomeMessage();
consoleUI.PrintRules();
Clear();
PlayerInfo player2 = new();
consoleUI.ReadPlayerInfo(player2, "Name for player 2: ");
consoleUI.ReadShipLocations(player2);

// Game loop
bool gameOver = false;
int player1Points = 0;
int player2Points = 0;
do
{
    WriteLine("Player 1's turn");
    GridSpot demoShoot = new GridSpot()
    {
        SpotLetter = "A",
        SpotNumber = 1,
    };
    bool hit = player1.Shoot(player2, demoShoot);
    WriteLine(hit);
    gameOver = true;
    WriteLine("Player 2's turn");
} while (!gameOver);

ReadKey();