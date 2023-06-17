using BattleshipLibrary;

const int maxShips = 2;
string[] allowedLetters = { "A", "B", "C", "D", "E" };
ConsoleUI consoleUI = new(allowedLetters, maxShips);

consoleUI.WelcomeMessage();
consoleUI.PrintRules(); 
PlayerInfo player1 = new(); 
consoleUI.ReadPlayerInfo(player1, "Name for player 1: ");
consoleUI.ReadShipLocations(player1);

//consoleUI.WelcomeMessage();
//consoleUI.PrintRules();
//Clear();
//PlayerInfo player2 = new();
//consoleUI.ReadPlayerInfo(player2, "Name for player 2: ");
//consoleUI.ReadShipLocations(player2);

WriteLine($"{player1.Username}'s locations");
foreach(var shipLocation in player1.ShipLocations)
{
    Write($"{shipLocation.GetCoordinate()}\t");
}

ReadKey();