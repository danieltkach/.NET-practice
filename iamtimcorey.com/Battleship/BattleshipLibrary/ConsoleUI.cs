using System;
using System.Numerics;

namespace BattleshipLibrary
{
    public class ConsoleUI
    {
        private readonly string[] allowedLetters;
        private readonly int gridSize;
        private readonly int maxShips;
        int playerInputCursorPosition = 14;
        public GridUI grid;
        const string SPACES = "                                                    ";

        public ConsoleUI(string[] letters, int size, int ships)
        {    
            allowedLetters = letters;
            gridSize = size;
            maxShips = ships;
            grid = new(letters, size);
        }

        public void WelcomeMessage()
        {
            ForegroundColor = ConsoleColor.Cyan;
            Write("*** Welcome to ");
            ForegroundColor = ConsoleColor.Red;
            Write("Battleship >>>\n");
        }

        public void PrintRules()
        {
            ForegroundColor = ConsoleColor.DarkCyan;
            WriteLine("\nRules:");
            Write("Allowed letters are: ");
            WriteLine(string.Join(" ", allowedLetters));
            WriteLine($"Allowed numbers are from 1 to {gridSize}");
            ResetColor();
        }

        private void ReadPlayerInfo(PlayerInfo player, string prompt)
        {
            ForegroundColor = ConsoleColor.Cyan;
            Write($"\n{prompt}");
            ForegroundColor = ConsoleColor.Red;
            player.Username = ReadLine();
        }

        public void PlayerRegistration(PlayerInfo player, string message)
        {
            Clear();
            WelcomeMessage();
            PrintRules();
            ReadPlayerInfo(player, message);
            grid.PrintBlankGrid();
            ReadShipLocations(player);
        }

        private string GetValidatedLetter()
        {
            string inputLetter;
            do
            {
                SetCursorPosition(0, playerInputCursorPosition+1);
                WriteLine(SPACES);
                SetCursorPosition(0, playerInputCursorPosition + 1);
                ForegroundColor = ConsoleColor.Cyan;
                Write("Letter: ");
                ForegroundColor = ConsoleColor.Red;
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
                SetCursorPosition(0, playerInputCursorPosition + 2);
                WriteLine(SPACES);
                SetCursorPosition(0, playerInputCursorPosition + 2);
                ForegroundColor = ConsoleColor.Cyan;
                Write("Number: ");
                ForegroundColor = ConsoleColor.Red;
                validNumber = 
                    int.TryParse(ReadLine(), out inputNumber)
                    && inputNumber <= gridSize
                    && inputNumber > 0;
            } while (!validNumber);
            return inputNumber;
        }

        public GridSpotModel ReadCoordinate()
        {
            GridSpotModel shipLocation = new()
            {
                SpotLetter = GetValidatedLetter(),
                SpotNumber = GetValidatedNumber()
            };
            return shipLocation;
        }

        public void ReadShipLocations(PlayerInfo player)
        {
            for (int i = 1; i <= maxShips; i++)
            {
                bool alreadyExists;
                GridSpotModel newShipLocation;
                do
                {
                    ForegroundColor = ConsoleColor.Cyan;
                    SetCursorPosition(0, playerInputCursorPosition);
                    WriteLine(SPACES);
                    WriteLine(SPACES);
                    WriteLine(SPACES);
                    SetCursorPosition(0, playerInputCursorPosition);
                    Write($"Coordinates for ship ");
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine($"#{i}");
                    newShipLocation = ReadCoordinate();
                    alreadyExists = player.ShipLocations.Any(ship => ship.SpotLetter == newShipLocation.SpotLetter && ship.SpotNumber == newShipLocation.SpotNumber);
                    ForegroundColor = ConsoleColor.DarkRed;
                    if (alreadyExists) Console.WriteLine("\nYou already added a ship in that location.");
                } while (alreadyExists);
                SetCursorPosition(0, playerInputCursorPosition+4);
                WriteLine(SPACES);
                player.AddShipLocation(newShipLocation);
                grid.PrintShips(player);
            }
        }

        public void PlayerTurn(PlayerInfo shooter, PlayerInfo target, string message)
        {
            for (int i = 0; i < 6; i++)
            {
                SetCursorPosition(0, playerInputCursorPosition + i);
                WriteLine("                        ");
            }
            SetCursorPosition(0, playerInputCursorPosition);
            ForegroundColor = ConsoleColor.Blue;
            WriteLine(message);

            void ErasePreviousMessage()
            {
                int resultCursorPosition = WindowWidth / 2 - 10;
                SetCursorPosition(resultCursorPosition, 0);
                Write(SPACES);
                SetCursorPosition(resultCursorPosition, 0);
            }

            GridSpotModel shoot = ReadCoordinate();
            bool hit = shooter.Shoot(target, shoot);
            if (hit)
            {
                ErasePreviousMessage();
                ForegroundColor = ConsoleColor.Red;
                Write($"{ shooter.Username} HITS!");
                Beep(200, 2000);
                shooter.AddPoint();
                ResetColor();
            }
            else
            {
                ErasePreviousMessage();
                ForegroundColor = ConsoleColor.Cyan;
                Write($"{shooter.Username} _ misses _ ");
                Beep(1000, 100);
                Beep(1000, 100);
                Beep(1000, 100);
                ResetColor();
            }
        }
    }
}
