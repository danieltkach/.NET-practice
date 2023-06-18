namespace BattleshipLibrary
{
    public class GridUI
    {
        private readonly string[] allowedLetters;
        private readonly int gridSize;

        public GridUI(string[] letters, int size)
        {
            allowedLetters = letters;
            gridSize = size;
        }

        private (int x, int y) Coordinates(string letter, int number)
        {
            int offsetX = WindowWidth / 2 - allowedLetters.Length * 4 / 2;
            int offsetY = 3;
            int index = Array.IndexOf(allowedLetters, letter.ToUpper());
            return (index * 4 + offsetX, offsetY + number);
        }

        public void PrintGrid()
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

        public enum AttackType { hit, miss };

        public void DrawAttack(string letter, int number, AttackType type)
        {
            var (x, y) = Coordinates(letter, number);
            SetCursorPosition(x, y);
            string hitChars = "";
            if (type == AttackType.hit)
            {
                hitChars = "##";
                ForegroundColor = ConsoleColor.Red;
            }
            if (type == AttackType.miss)
            {
                hitChars = "--";
                ForegroundColor = ConsoleColor.Cyan;
            }
            Write(hitChars);
        }
    }
}
