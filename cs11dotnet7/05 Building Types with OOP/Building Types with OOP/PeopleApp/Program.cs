using Packt.Shared;
using PacktLibrarynetStandard2;

Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-GB");

Person bob = new();
WriteLine(bob.ToString());

bob.Name = "Bob Smith";
bob.DateOfBirth = new DateTime(1965, 12, 22);
WriteLine(format: "{0} was born on {1:dddd, d MMMM yyyy}",
    arg0: bob.Name,
    arg1: bob.DateOfBirth);

// Enums
bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
WriteLine(
    format: "{0} favorite wonder is {1}. Its integer is {2}",
    arg0: bob.Name,
    arg1: bob.FavoriteAncientWonder,
    arg2: (int)bob.FavoriteAncientWonder);

bob.BucketList =
    WondersOfTheAncientWorld.HangingGardensOfBabylon
    | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}.");

// Lists
bob.Children.Add(new Person { Name = "Alfred" });
bob.Children.Add(new() { Name = "Zoe" });
WriteLine($"{bob.Name} has {bob.Children.Count} children: ");
foreach (var child in bob.Children)
{
    WriteLine($"> {child.Name}");
}

// Fields (static, constant, read-only, with constructors)
BankAccount.InterestRate = 0.012M;
BankAccount jonesAccount = new()
{
    AccountName = "Mrs. Jones",
    Balance = 2400
};
WriteLine(format: "{0} earned {1:C} interest.",
    arg0: jonesAccount.AccountName,
    arg1: jonesAccount.Balance * BankAccount.InterestRate);

BankAccount gerrierAccount = new()
{
    AccountName = "Ms. Gerrier",
    Balance = 98
};
WriteLine(format: "{0} earned {1:C} interest.",
    arg0: gerrierAccount.AccountName,
    arg1: gerrierAccount.Balance * BankAccount.InterestRate);

WriteLine($"{bob.Name} is a {Person.Species}");
WriteLine($"{bob.Name} was born on {bob.HomePlanet}");
WriteLine($"{bob.Name}'s creator is {Person.Creator}");

Person blankPerson = new();
WriteLine(format:
    "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
    arg0: blankPerson.Name,
    arg1: blankPerson.HomePlanet,
    arg2: blankPerson.Instantiated);

Person gunny = new(initialName: "Gunny", homePlanet: "Mars");
WriteLine(format:
    "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}",
    arg0: gunny.Name,
    arg1: gunny.HomePlanet,
    arg2: gunny.Instantiated);

Person sam = new()
{
    Name = "Sam",
    DateOfBirth = new(1969, 6, 25)
};
WriteLine(sam.Origin);
WriteLine(sam.Greeting);
WriteLine(sam.Age);
var (origin, greeting, age) = sam;
WriteLine($"{sam.Name}'s info:\n {origin} \t {greeting} \t age: {age}");

sam.FavoriteIceCream = "Chocolate Fudge";
WriteLine(sam.FavoriteIceCream);
string color = "Re";
try
{
    sam.FavoritePrimaryColor = color;
    WriteLine(sam.FavoritePrimaryColor);
}
catch (Exception ex)
{
    WriteLine("Tried to set {0} to '{1}': {2}",
        nameof(sam.FavoritePrimaryColor), color, ex.Message);
}

// Indexing
sam.Children.Add(new() { Name = "Charlie", DateOfBirth = new(2010, 3, 18) });
sam.Children.Add(new() { Name = "Ella", DateOfBirth = new(2020, 12, 24) });
// get using Children list
WriteLine($"Sam's first child is {sam.Children[0].Name}.");
WriteLine($"Sam's second child is {sam.Children[1].Name}.");
// get using integer position indexer
WriteLine($"Sam's first child is {sam[0].Name}");
WriteLine($"Sam's second child is {sam[1].Name}");
// get using name indexer
WriteLine($"Sam's child named Ella is {sam["Ella"].Age} years old.");

// using overloaded methods
Person lamech = new() { Name = "Lamech" };
Person adah = new() { Name = "Adah" };
Person zillah = new() { Name = "Zillah" };
lamech.Marry(adah);
Person.Marry(zillah, lamech);

void IsMarriedTo(Person person)
{
    WriteLine($"{person.Name} is married to {person.Spouse?.Name ?? "nobody"}");
}
IsMarriedTo(lamech);
IsMarriedTo(adah);
IsMarriedTo(zillah);

// call instance method
Person baby1 = lamech.ProcreateWith(adah);
baby1.Name = "Jabal";
WriteLine($"{baby1.Name} was born on {baby1.DateOfBirth}");
// call static method
Person baby2 = Person.Procreate(zillah, lamech);
baby2.Name = "Tubalcain";

void HowManyChildren(Person person)
{
    int count = person.Children.Count;
    WriteLine($"{person.Name} has {count} {(count > 1 ? "children" : "child")}");
}
HowManyChildren(lamech);
HowManyChildren(adah);
HowManyChildren(zillah);

for(int i = 0; i < lamech.Children.Count; i++)
{
    WriteLine("{0}'s child #{1} is named \"{2}\".",
        arg0: lamech.Name, arg1: i, arg2: lamech[i].Name);
}