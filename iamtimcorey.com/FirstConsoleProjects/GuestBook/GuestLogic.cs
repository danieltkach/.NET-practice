namespace GuestBook
{
    public static class GuestLogic
    {
        private static Dictionary<string, int> guests = new();
        private static string name;
        private static int membersCount;

        private static void LogMessage(string msg, string color = "gray")
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

        public static void StartRegistrations()
        {
            while (true)
            {
                // Ask for name
                LogMessage("Family name, please: ", "white");
                Console.ForegroundColor = ConsoleColor.Cyan;
                name = Console.ReadLine();
                if (name == "") break;

                // Ask for number of members
                LogMessage("How many members? ", "white");
                Console.ForegroundColor = ConsoleColor.Cyan;
                bool validEntry = int.TryParse(Console.ReadLine(), out membersCount);

                // Save data
                if (!validEntry)
                {
                    LogMessage("Entry not valid.\n", "red");
                }
                else
                {
                    guests[name] = membersCount;
                    LogMessage($"{name} family registered successfully.\n");
                }
            }

            LogMessage("Data entry finished...\n");
        }

        public static void PrintGuestList()
        {
            // Count guests
            int totalGuestsCount = 0;
            foreach (var guest in guests)
            {
                totalGuestsCount += guest.Value;
            }

            LogMessage($"\n\tTotal guests: {totalGuestsCount}\n", "yellow");
            LogMessage("--------------------------------------------------------\n");

            int placeIndex = 1;
            string TABS = "\t\t\t";
            LogMessage($"PLACE{TABS}FAMILY{TABS}MEMBERS\n", "darkCyan");
            foreach (var guest in guests)
            {
                LogMessage($"{placeIndex}{TABS}{guest.Key}{TABS}{guest.Value}\n", "cyan");
                placeIndex++;
            }
        }

        public static void GreetGoodbye()
        {
            LogMessage("\nThank you for using GuestBook. Goodbye...");
            Console.ReadKey();
        }
    }
}
