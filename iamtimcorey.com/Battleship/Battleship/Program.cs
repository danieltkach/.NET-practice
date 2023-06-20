using BattleshipLibrary;

// Configuration
string[] allowedLetters = { "A", "B", "C", "D", "E", "F", "G" };

int gridSize = allowedLetters.Length;
const int shipsPerPlayer = 3;
ConsoleUI consoleUI = new(allowedLetters, gridSize, shipsPerPlayer);

// Player 1 registration
PlayerModel player1 = new();
consoleUI.PlayerRegistration(player1, "Name for player 1: ");

// Player 2 registration
PlayerModel player2 = new();
consoleUI.PlayerRegistration(player2, "Name for player 2: ");

// Game loop
Clear();
PlayerModel winner = null;
PlayerModel looser ;

while (winner == null)
{
    consoleUI.grid.UpdateGrid(player1);
    bool scored;
    do
    {
        scored = consoleUI.PlayerTurn(player1, player2, $"{player1.Username}'s turn");
        consoleUI.grid.UpdateGrid(player1);
        if (player1.Points == shipsPerPlayer)
        {
            winner = player1;
            looser = player2;
            EndGame();
            break;
        }
    } while(scored);

    if (winner != null) break;

    consoleUI.grid.UpdateGrid(player2);
    do
    {
        scored = consoleUI.PlayerTurn(player2, player1, $"{player2.Username}'s turn");
        consoleUI.grid.UpdateGrid(player2);
        if (player2.Points == shipsPerPlayer)
        {
            winner = player2;
            looser = player1;
            EndGame();
            break;
        }
    } while (scored);
}

void EndGame()
{
    consoleUI.grid.UpdateGrid(looser);
    consoleUI.grid.PrintShips(winner);
    consoleUI.PrintEndGameSigns(winner);
}