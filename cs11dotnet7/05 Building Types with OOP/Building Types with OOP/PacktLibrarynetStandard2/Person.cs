using PacktLibrarynetStandard2;

namespace Packt.Shared;

public class Person
{
    public string Name;
    public DateTime DateOfBirth;
    public WondersOfTheAncientWorld FavoriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;
    public List<Person> Children = new();
    
    // read-only fields
    public readonly string HomePlanet = "Earth";
    public static readonly string Creator = "Unknown";
    public readonly DateTime Instantiated;
    public const string Species = "Homo Sapiens";

    // constructors
    public Person() 
    {
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }

    public Person(string initialName, string homePlanet)
    {
        Name = initialName;
        HomePlanet = homePlanet;
        Instantiated = DateTime.Now;
    }
}