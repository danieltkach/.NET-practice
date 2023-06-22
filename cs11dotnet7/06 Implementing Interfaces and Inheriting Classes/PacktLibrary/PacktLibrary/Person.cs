namespace Packt.Shared;

public class Person : object
{
    public string? Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public void WriteBirthdayToConsole()
    {
        WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
    }

    // delegate field
    public EventHandler? Shout;
    // data field
    public int AngerLevel;
    // method
    public void Poke()
    {
        AngerLevel++;
        if (AngerLevel >= 3)
        {
            // if something is listening
            if (Shout != null)
            {
                // ... then call the delegate
                Shout(this, EventArgs.Empty);
            }
        }
    }
}