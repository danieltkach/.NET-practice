using Humanizer;

Console.WriteLine("What's up, Cody.");

Console.WriteLine("Quantities:");
HumanizeQuantities();

Console.WriteLine("\nDate/Time Manipulation:");
HumanizeDates();

JustDates();

static void HumanizeQuantities()
{
    Console.WriteLine("case".ToQuantity(0));
    Console.WriteLine("case".ToQuantity(1));
    Console.WriteLine("case".ToQuantity(5));
}

static void HumanizeDates()
{
    Console.WriteLine(DateTime.UtcNow.AddHours(-24).Humanize());
    Console.WriteLine(DateTime.UtcNow.AddHours(-2).Humanize());
    Console.WriteLine(TimeSpan.FromDays(1).Humanize());
    Console.WriteLine(TimeSpan.FromDays(16).Humanize());
}

static void JustDates()
{
    Console.WriteLine(DateTime.UtcNow.AddHours(-24));
    Console.WriteLine(DateTime.UtcNow.AddHours(-2));
    Console.WriteLine(TimeSpan.FromDays(1));
    Console.WriteLine(TimeSpan.FromDays(16) + "\n");
}