namespace BattleshipLibrary
{
    public class GridUI
    {
        private readonly string[] allowedLetters;
        private readonly int gridSize;
        private int offsetY = 3;

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
            ForegroundColor = ConsoleColor.DarkGray;
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

        private void DrawAttack(GridSpotModel spot)
        {
            var (x, y) = Coordinates(spot.SpotLetter, spot.SpotNumber);
            var type = spot.Status;
            SetCursorPosition(x, y);
            string hitChars = "";
            if (type == GridSpotModel.SpotStatus.hit)
            {
                hitChars = "##";
                ForegroundColor = ConsoleColor.Red;
            }
            if (type == GridSpotModel.SpotStatus.miss)
            {
                hitChars = "--";
                ForegroundColor = ConsoleColor.Cyan;
            }
            Write(hitChars);
        }

        public void UpdateGrid(PlayerInfo player)
        {
            PrintBlankGrid();
            foreach(var spot in player.ShotsGrid)
            {
                if (spot.Status == GridSpotModel.SpotStatus.miss || spot.Status == GridSpotModel.SpotStatus.hit)
                {
                    DrawAttack(spot);
                }
            }
        }
    }
}
