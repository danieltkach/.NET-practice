int numberOfApples = 12;
decimal pricePerApple = 0.35M;
WriteLine(
    format: "{0} apples cost {1:C}",
    arg0: numberOfApples,
    arg1: pricePerApple * numberOfApples);

string formatted = string.Format(
    format: "{0} apples cost {1:C}",
    arg0: numberOfApples,
    arg1: pricePerApple * numberOfApples);
// WriteToFile(formatted);
WriteLine( formatted );
WriteLine($"{numberOfApples} apples cost {pricePerApple * numberOfApples:C}");
WriteLine();

string applesText = "Apples";
int applesCount = 1234;
string bananasText = "Bananas";
int bananasCount = 56789;

WriteLine(
    format: "{0,-10} {1,6}",
    arg0: "Name",
    arg1: "Count");
WriteLine(
    format: "{0,-10} {1,6:N0}",
    arg0: applesText,
    arg1: applesCount);
WriteLine(
    format: "{0,-10} {1,6:N0}",
    arg0: bananasText,
    arg1: bananasCount);
WriteLine();

Write("Welcome, what's your name? ");
string name = ReadLine()!;
if (name == "")
{
    WriteLine("Hello, stranger.");
} 
    else
{
    WriteLine($"Hi {name}. Welcome to .NET");
}

Write("Press any key combination: ");
ConsoleKeyInfo key = ReadKey();
WriteLine();
WriteLine("Key: {0}, Char: {1}, Modifiers: {2}",
    arg0: key.Key,
    arg1: key.KeyChar,
    arg2: key.Modifiers);