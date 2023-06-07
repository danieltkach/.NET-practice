namespace GuestBook
{
    public static class MessageLogger
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

        public static void WelcomeMessage()
        {
            LogMessage("\t***** GuestBook 2023 *****\n", "yellow");
            LogMessage("Leave name blank to exit the GuestBook application.\n\n");
        }

        public static void GreetGoodbye()
        {
            LogMessage("\nThank you for using GuestBook. Goodbye...");
            Console.ReadKey();
        }
    }
}
