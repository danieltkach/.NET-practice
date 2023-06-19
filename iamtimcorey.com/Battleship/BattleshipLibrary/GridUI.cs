namespace BattleshipLibrary
{
    public class GridUI
    {
        private readonly string[] allowedLetters;
        private readonly int gridSize;
        private readonly int offsetY = 3;

        public GridUI(string[] letters, int size)
        {
            allowedLetters = letters;
            gridSize = size;
        }

        private (int x, int y) Coordinates(string letter, int number)
        {
            int offsetX = WindowWidth / 2 - allowedLetters.Length * 4 / 2;
            int index = Array.IndexOf(allowedLetters, letter.ToUpper());
            return (index * 4 + offsetX, offsetY + number);
        }

        public void PrintBlankGrid()
        {
            ForegroundColor = ConsoleColor.Gray;
            for (int j = 0; j < allowedLetters.Length; j++)
            {
                for (int i = 1; i <= gridSize; i++)
                {

                    var (x, y) = Coordinates(allowedLetters[j], i);
                    SetCursorPosition(x, y);
                    Write($"{allowedLetters[j]}{i}");
                }
            }
        }

        private void DrawSpot(GridSpotModel spot)
        {
            string spotChars = "";
            var (x, y) = Coordinates(spot.SpotLetter, spot.SpotNumber);
            SetCursorPosition(x, y);
            var type = spot.Status;

            if (type == GridSpotModel.SpotStatus.hit)
            {
                spotChars = "##";
                ForegroundColor = ConsoleColor.Red;
            }
            if (type == GridSpotModel.SpotStatus.miss)
            {
                spotChars = "--";
                ForegroundColor = ConsoleColor.Cyan;
            }
            if (type == GridSpotModel.SpotStatus.ship)
            {
                spotChars = "<]";
            }
            Write(spotChars);
        }

        public void UpdateGrid(PlayerInfo player)
        {
            PrintBlankGrid();
            foreach(var spot in player.ShotsGrid)
            {
                if (spot.Status == GridSpotModel.SpotStatus.miss 
                    || spot.Status == GridSpotModel.SpotStatus.hit)
                {
                    DrawSpot(spot);
                }
            }
        }

        public void PrintShips(PlayerInfo player)
        {
            ForegroundColor = ConsoleColor.DarkGreen;
            foreach (var spot in player.ShipLocations)
            {
                DrawSpot(spot);
            }
        }
    }
}
