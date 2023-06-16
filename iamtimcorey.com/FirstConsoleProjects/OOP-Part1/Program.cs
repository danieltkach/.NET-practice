using OOP_Part1;

Person person = new Person()
{
    StreetAdress = "Calle 40",
    City = "Santa Teresita",
    State = "Buenos Aires",
    ZipCode = "7107"
};

Console.WriteLine(person.FullAddress);