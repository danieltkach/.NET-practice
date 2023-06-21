namespace Packt.Shared;

public class ImmutablePerson
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
}

public record ImmutableVehicle
{
    public string Brand { get; init; }
    public string Color { get; init; }
    public int Wheels { get; init; }
}

public record ImmutableAnimal(string Name, string Species);
