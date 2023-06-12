partial class Program
{
    static void TimesTable(byte number, byte size = 10)
    {
        ForegroundColor = ConsoleColor.Green;
        WriteLine($"Multiplication Table for {number}");
        ForegroundColor = ConsoleColor.Red;
        for (int i = 1; i <= size; i++)
        {
            WriteLine($"{i} x {number} = {i*number}");
        }
        ResetColor();
    }

    static decimal CalculateTax(decimal amount, string location)
    {
        decimal result = location switch
        {
            "USA" => amount * 8.25M,
            "ARG" => amount * 25.70M,
            _ => amount
        };
        return result;
    }
}