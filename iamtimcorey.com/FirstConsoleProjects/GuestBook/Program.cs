using static GuestBook.GuestLogic;

// Program's welcome messages
LogMessage("\t***** GuestBook 2023 *****\n", "yellow");
LogMessage("Leave name blank to exit the GuestBook application.\n\n");

// Variables definitions
Dictionary<string, int> guests = new();
string name;
int membersCount;

// Main program loop 
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
LogMessage("\nThe following info was registered into the guest book:\n");

// Count guests
int totalGuestsCount = 0;
foreach(var guest in guests)
{
    totalGuestsCount += guest.Value;
}

// Print data
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

// Close program
LogMessage("\nThank you for using GuestBook. Goodbye...");
Console.ReadKey();
