namespace BattleshipLibrary
{
    public class ConsoleUI
    {
        private readonly string[] allowedLetters;
        private readonly int maxShips;

        public ConsoleUI(string[] letters, int ships)
        {    
            allowedLetters = letters;
            maxShips = ships;
        }

        public void WelcomeMessage()
        {
            WriteLine("Welcome to Battleship");
        }

        public void PrintRules()
        {
            WriteLine("\nRules:");
            Write("Allowed letters are: ");
            WriteLine(string.Join(" ", allowedLetters));
            WriteLine($"Allowed numbers are from 1 to {maxShips}");
        }

        public void ReadPlayerInfo(PlayerInfo player, string prompt)
        {
            Write($"\n{prompt}");
            player.Username = ReadLine();
        }

        private string GetValidatedLetter()
        {
            string inputLetter;
            do
            {
                Write("Letter: ");
                inputLetter = ReadLine().ToUpper();
            } while (!allowedLetters.Contains(inputLetter));
            return inputLetter;
        }

        private int GetValidatedNumber()
        {
            bool validNumber;
            int inputNumber;
            do
            {
                Write("Number: ");
                validNumber = 
                    int.TryParse(ReadLine(), out inputNumber)
                    && inputNumber <= allowedLetters.Length
                    && inputNumber > 0;

            } while (!validNumber);
            return inputNumber;
        }

        public void ReadShipLocations(PlayerInfo player)
        {
            for (int i = 1; i <= maxShips; i++)
            {
                WriteLine($"Coordinates for ship #{i}");
                GridSpot shipLocation = new()
                {
                    SpotLetter = GetValidatedLetter(),
                    SpotNumber = GetValidatedNumber()
                };
                player.AddShipLocation(shipLocation);
            }
        }
    }
}
