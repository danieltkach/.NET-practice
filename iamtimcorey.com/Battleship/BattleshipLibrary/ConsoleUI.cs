using System;
using System.Numerics;

namespace BattleshipLibrary
{
    public class ConsoleUI
    {
        private readonly string[] allowedLetters;
        private readonly int gridSize;
        private readonly int maxShips;

        public ConsoleUI(string[] letters, int size, int ships)
        {    
            allowedLetters = letters;
            gridSize = size;
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
            WriteLine($"Allowed numbers are from 1 to {gridSize}");
        }

        private void ReadPlayerInfo(PlayerInfo player, string prompt)
        {
            Write($"\n{prompt}");
            player.Username = ReadLine();
        }

        public void PlayerRegistration(PlayerInfo player, string message)
        {
            Clear();
            WelcomeMessage();
            PrintRules();
            ReadPlayerInfo(player, message);
            ReadShipLocations(player);
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

        public GridSpot ReadCoordinate()
        {
            GridSpot shipLocation = new()
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
                WriteLine($"Coordinates for ship #{i}");
                GridSpot shipLocation = ReadCoordinate();
                player.AddShipLocation(shipLocation);
            }
        }

        public void PlayerTurn(PlayerInfo shooter, PlayerInfo target, string message)
        {
            WriteLine(message);
            GridSpot shoot = ReadCoordinate();
            bool hit = shooter.Shoot(target, shoot);
            if (hit)
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("Ship hit!");
                shooter.AddPoint();
                ResetColor();
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Miss!");
                ResetColor();
            }
        }
    }
}
