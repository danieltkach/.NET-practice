using System.IO;

IEnumerable<string> listOfDirectories = Directory.EnumerateDirectories(Directory.GetDirectoryRoot("c:"));
foreach (string directory in listOfDirectories)
{
    Console.WriteLine(directory);
}