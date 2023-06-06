string greeting = "Welcome to C#";
const char GREETING_ICON = '#';
const int MARGIN = 5;

void PrintIconLine()
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    int charCount = greeting.Length;
    for (int i = 0; i < MARGIN * 2 + charCount; i++)
    {
        Console.Write(GREETING_ICON);
    }
    Console.WriteLine();
}

void PrintGreetingWithMargin(int margin, string greeting)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    for (int i = 0; i < margin; i++)
    {
        Console.Write(" ");
    }
    Console.WriteLine(greeting);
}

// Write greeting sign
PrintIconLine();
PrintGreetingWithMargin(MARGIN, greeting);
PrintIconLine();

// Prompt user for name
Console.ForegroundColor = ConsoleColor.Cyan;
Console.Write("\n\nWhat's your name? ");
Console.ForegroundColor = ConsoleColor.White;
string name = Console.ReadLine()!;
if (name.Replace(" ", "").Length == 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Hello, stranger.");
}
else
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"Hello {name}, let's become .NET experts!");
}

// Prevent console from closing right away
Console.ResetColor();
Console.ReadLine();