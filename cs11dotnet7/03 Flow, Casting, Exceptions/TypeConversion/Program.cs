int number = 12;
Console.WriteLine(number.ToString());
bool boolean = true;
Console.WriteLine(boolean.ToString());
DateTime now =  DateTime.Now;
Console.WriteLine(now.ToString());
object me = new();
Console.WriteLine(me.ToString());

Console.Write("Enter amount: $");
string? amount = Console.ReadLine();
if (string.IsNullOrEmpty(amount))
{
    return;
}
try
{
    decimal amountValue = decimal.Parse(amount);
    Console.WriteLine($"Amount formatted as currency: {amountValue:C}");
}
catch (FormatException) when (amount.Contains("$"))
{
    Console.WriteLine("No need to enter the dollar sign.");
}
catch (FormatException)
{
    Console.WriteLine("Amounts must contain only digits.");
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
