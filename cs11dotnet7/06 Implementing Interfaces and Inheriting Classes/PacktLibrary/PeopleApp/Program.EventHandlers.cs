using Packt.Shared;

partial class Program
{
    //a method to handle the Shout event received by the Person object
    static void Harry_Shout(object? sender, EventArgs e)
    {
        if (sender == null) return;
        Person? p = sender as Person;
        if (p == null) return;
        WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
    }
}
