namespace GuestBook
{
    public static class GuestLogic
    {
        private static Dictionary<string, int> guests = new();
        private static string name;
        private static int membersCount;

        public static void StartRegistrations()
        {
            while (true)
            {
                // Ask for name
                MessageLogger.LogMessage("Family name, please: ", "white");
                Console.ForegroundColor = ConsoleColor.Cyan;
                name = Console.ReadLine();
                if (name == "") break;

                // Ask for number of members
                MessageLogger.LogMessage("How many members? ", "white");
                Console.ForegroundColor = ConsoleColor.Cyan;
                bool validEntry = int.TryParse(Console.ReadLine(), out membersCount);

                // Save data
                if (!validEntry)
                {
                    MessageLogger.LogMessage("Entry not valid.\n", "red");
                }
                else
                {
                    guests[name] = membersCount;
                    MessageLogger.LogMessage($"{name} family registered successfully.\n");
                }
            }

            MessageLogger.LogMessage("Data entry finished...\n");
        }

        public static void PrintGuestList()
        {
            // Count guests
            int totalGuestsCount = 0;
            foreach (var guest in guests)
            {
                totalGuestsCount += guest.Value;
            }

            MessageLogger.LogMessage($"\n\tTotal guests: {totalGuestsCount}\n", "yellow");
            MessageLogger.LogMessage("--------------------------------------------------------\n");

            int placeIndex = 1;
            string TABS = "\t\t\t";
            MessageLogger.LogMessage($"PLACE{TABS}FAMILY{TABS}MEMBERS\n", "darkCyan");
            foreach (var guest in guests)
            {
                MessageLogger.LogMessage($"{placeIndex}{TABS}{guest.Key}{TABS}{guest.Value}\n", "cyan");
                placeIndex++;
            }
        }
    }
}
