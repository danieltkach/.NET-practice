// Program's welcome messages
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("\t***** GuestBook 2023 *****");
Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("Leave name blank to exit the GuestBook application.\n");

// Variables definitions
Dictionary<string, int> guests = new();
string name;
int membersCount;

// Main program loop 
while (true)
{
    // Ask for name
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("Family name, please: ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    name = Console.ReadLine();
    if (name == "") break;

    // Ask for number of members
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("How many members? ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    bool validEntry = int.TryParse(Console.ReadLine(), out membersCount);

    // Save data
    if (!validEntry)
    {
        Console.WriteLine("Entry not valid.");
    } 
    else
    {
        guests[name] = membersCount;
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"{name} family registered successfully.\n");
    }
}
Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("Data entry finished...");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("\nThe following info was registered into the guest book:\n");

// Count guests
int totalGuestsCount = 0;
foreach(var guest in guests)
{
    totalGuestsCount += guest.Value;
}

// Print data
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"\n\t\tTotal guests: {totalGuestsCount}");
Console.WriteLine("--------------------------------------------------------");

int placeIndex = 1;
Console.ForegroundColor = ConsoleColor.DarkCyan;
string TABS = "\t\t\t";
Console.WriteLine($"PLACE{TABS}FAMILY{TABS}MEMBERS");
Console.ForegroundColor = ConsoleColor.Cyan;
foreach (var guest in guests)
{
    Console.WriteLine($"{placeIndex}{TABS}{guest.Key}{TABS}{guest.Value}");
    placeIndex++;
}

// Close program
Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine("\nThank you for using GuestBook. Goodbye...");
Console.ReadKey();
