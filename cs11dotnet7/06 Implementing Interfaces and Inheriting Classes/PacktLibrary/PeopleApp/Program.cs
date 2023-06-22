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
