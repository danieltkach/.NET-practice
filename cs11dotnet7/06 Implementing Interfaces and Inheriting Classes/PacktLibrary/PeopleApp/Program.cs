using Packt.Shared;

Person prahlad = new()
{
    Name = "Prahlad",
    DateOfBirth = new(year: 2011, month: 3, day: 23)
};
prahlad.WriteBirthdayToConsole();

Person uma = new()
{
    Name = "Uma",
    DateOfBirth = new(year: 2014, month: 5, day: 24)
};
uma.WriteBirthdayToConsole();

prahlad.Shout = Harry_Shout;
prahlad.Poke();
prahlad.Poke();
prahlad.Poke();
prahlad.Poke();
prahlad.Poke();

Person?[] people =
{
    null,
    new() { Name = "Simon" },
    new() { Name = "Jenny" },
    new() { Name = "Adam" },
    new() { Name = null },
    new() { Name = "Richard" }
};
OutputPeopleNames(people, "Initial list of people:");
Array.Sort(people);
OutputPeopleNames(people, "After sorting using Person's IComparable implementation:");

//DvdPlayer myPlayer = new();
//myPlayer.Stop(); // this won't work

IPlayable myPlayer = new DvdPlayer();
myPlayer.Stop(); // This will call the default Stop() from IPlayable interface and print "Default implementation of Stop()".

DisplacementVector dv1 = new(3, 5);
DisplacementVector dv2 = new(-2, 7);
DisplacementVector dv3 = dv1 + dv2;
WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");