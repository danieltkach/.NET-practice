using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WrapUpDemo
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            List<PersonModel> people = new List<PersonModel>
            {
                new PersonModel { FirstName = "Daniel", LastName = "Tkach", Email = "daniel.tkach@dataart.com"},
                new PersonModel { FirstName = "Eli", LastName = "Feijoo", Email = "eleonorafeijoo103@gmail.com" },
                new PersonModel { FirstName = "Prahlad", LastName = "Tkach", Email = "prahladezequieltkach@gmail.com" },
                new PersonModel { FirstName = "Uma", LastName = "Tkach", Email = "umalucilatkach@gmail.com" },
                new PersonModel { FirstName = "Dandarnsome", LastName = "Heckathing", Email = "no one knows"}
            };

            List<CarModel> cars = new List<CarModel> {
                new CarModel { Manufacturer = "Renault", Model = "Duster" },
                new CarModel { Manufacturer = "Ford", Model = "Galaxy" },
                new CarModel { Manufacturer = "Janitor Motors", Model = "Fast as heck"}
            };

            DataAccess<PersonModel> peopleData = new DataAccess<PersonModel>();
            peopleData.BadEntryFound += PersonData_BadEntryFound;
            peopleData.SaveToCSV(people, @"../../Files/people.csv");

            DataAccess<CarModel> carData = new DataAccess<CarModel>();
            carData.BadEntryFound += CarData_BadEntryFound;
            carData.SaveToCSV(cars, @"../../Files/cars.csv");
        }

        private static void CarData_BadEntryFound(object sender, CarModel e)
        {
            Console.WriteLine($"Bad entry for item \"{e.Manufacturer} {e.Model}\".");
        }

        private static void PersonData_BadEntryFound(object sender, PersonModel e)
        {
            Console.WriteLine($"Bad entry for item \"{e.FirstName} {e.LastName}\".");
        }
    }

    public class DataAccess<T> where T : new() // where the element that's passed in has to have an empty constructor
    {
        public event EventHandler<T> BadEntryFound;

        public void SaveToCSV(List<T> items, string filePath)
        {
            T entry = new T();
            List<string> rows = new List<string>();
            var cols = entry.GetType().GetProperties();

            // headers
            string row = "";
            foreach (var col in cols)
            {
                row += $",{col.Name}";
            }
            row = row.Substring(1); // trims first character, which is a comma in this case
            rows.Add(row);

            // data rows
            foreach (var item in items)
            {
                row = "";
                bool badWordDetected = false;
                foreach (var col in cols)
                {
                    string val = col.GetValue(item, null).ToString();
                    badWordDetected = BadWordDetector(val);
                    if (badWordDetected == true)
                    {
                        BadEntryFound?.Invoke(this, item);
                        break;
                    }

                    row += $",{val}";
                }

                if (badWordDetected == false)
                {
                    row = row.Substring(1); // trims first character, which is a comma in this case
                    rows.Add(row);
                }
            }

            // save to file
            File.WriteAllLines(filePath, rows);
        }

        public bool BadWordDetector(string stringToTest)
        {
            bool output = false;
            string lowerCaseTest = stringToTest.ToLower();

            if (lowerCaseTest.Contains("darn") || lowerCaseTest.Contains("heck"))
            {
                output = true;
            }

            return output;
        }
    }
}