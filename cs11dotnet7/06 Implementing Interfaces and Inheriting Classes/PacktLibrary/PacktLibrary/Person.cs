namespace Packt.Shared;

public class Person : object, IComparable<Person?>
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

    //public int CompareTo(Person? other)
    //{
    //    int position;
    //    if ((this is not null) && (other is not null))
    //    {
    //        if ((Name is not null) && (other.Name is not null))
    //        {
    //            position = Name.CompareTo(other.Name);
    //        }
    //        else if ((Name is not null) && (other.Name is null))
    //        {
    //            position = -1;
    //        }
    //        else if ((Name is null) && (other.Name is not null))
    //        {
    //            position = 1;
    //        }
    //        else
    //        {
    //            position = 0;
    //        }
    //    }
    //    else if ((this is not null) && (other is null))
    //    {
    //        position = -1;
    //    }
    //    else if ((this is null) && (other is not null))
    //    {
    //        position = 1;
    //    }
    //    else
    //    {
    //        position = 0;
    //    }
    //    return position;
    //}

    // This one is a similar version to the above commented code, simplified.
    // It does not behave exactly the same as the null ones are placed first
    // but the simplification is worth it.
    public int CompareTo(Person? other)
{
    if (other is null)
    {
        return 1;
    }
    else
    {
        return this.Name?.CompareTo(other.Name) ?? (other.Name is null ? 0 : -1);
    }
}

}