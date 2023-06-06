namespace GuestBook
{
    public static class GuestLogic
    {
        public static void LogMessage(string msg, string color = "gray")
        {
            Dictionary<string, ConsoleColor> colorTable = new();
            colorTable.Add("red", ConsoleColor.Red);
            colorTable.Add("gray", ConsoleColor.DarkGray);
            colorTable.Add("white", ConsoleColor.White);
            colorTable.Add("yellow", ConsoleColor.Yellow);
            colorTable.Add("cyan", ConsoleColor.Cyan);
            colorTable.Add("darkCyan", ConsoleColor.DarkCyan);

            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = colorTable[color];
            Console.Write(msg);
            Console.ForegroundColor = originalColor;
        }
    }
}
