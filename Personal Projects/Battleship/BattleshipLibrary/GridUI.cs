namespace BattleshipLibrary
{
    public class GridUI
    {
        private readonly string[] allowedLetters;
        private readonly int gridSize;
        private readonly int verticalOffset;

        public GridUI(string[] letters, int size, int offset)
        {
            allowedLetters = letters;
            gridSize = size;
            verticalOffset = offset;
        }

        // Returns the cursor position for a given grid position (e.g. "A3" -> 12,8)
        private (int x, int y) Coordinates(string letter, int number)
        {
            int horizontalOffset = WindowWidth / 2 - allowedLetters.Length * 4 / 2;
            int index = Array.IndexOf(allowedLetters, letter.ToUpper());
            return (index * 4 + horizontalOffset, verticalOffset + number);
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
                ForegroundColor = ConsoleColor.Green;
                spotChars = "<]";
            }
            Write(spotChars);
        }

        // Draws the grid adding misses and hits
        public void UpdateGrid(PlayerModel player)
        {
            ForegroundColor = ConsoleColor.Gray;
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

        // Used to draw the ships as the player adds them
        // and also at the end to show where the ships were.
        public void PrintShips(PlayerModel player)
        {
            ForegroundColor = ConsoleColor.DarkGreen;
            foreach (var spot in player.ShipLocations)
            {
                DrawSpot(spot);
            }
        }
    }
}
