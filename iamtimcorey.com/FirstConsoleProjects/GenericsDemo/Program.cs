using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FizzBuzzCheck();
            void FizzBuzzCheck()
            {
                //for (int i = 0; i <= 20; i++)
                //{
                //    Console.Write($"{FizzBuzz(i)}, ");
                //}
                //Console.WriteLine(".");

                string[] wordsList = { "Daniel", "Eli", "Prahlad", "Uma Lucila", "This has fiftee" };
                foreach (var item in wordsList)
                {
                    Console.Write($"{item}: {FizzBuzz(item)}, ");
                }
                Console.WriteLine(".");

                Console.WriteLine($"false:  {FizzBuzz(false)}");
                Console.WriteLine($"true: {FizzBuzz(true)}");

                Console.WriteLine($"123456789012345: {FizzBuzz(123456789012345)}");

                Console.WriteLine($"class Person: {FizzBuzz(new PersonModel { Name = "Dan" })}");
            }
            GenericHelper<PersonModel> GenericPerson = new GenericHelper<PersonModel>();
            PersonModel okPerson = new PersonModel() { Name = "Dan" };
            PersonModel noPerson = new PersonModel() { Name = "Mr XYZ", HasError = true };
            GenericPerson.CheckItemAndAdd(okPerson);
            GenericPerson.CheckItemAndAdd(noPerson);
            Console.WriteLine($"First rejected item's name: {GenericPerson.RejectedItems[0].Name}");
            Console.WriteLine($"First accepted item's name: {GenericPerson.Items[0].Name}");

            GenericToString<PersonModel> stringable = new GenericToString<PersonModel>();
            Console.Write("Stringabling!! => ");
            stringable.Print();

            // prevents the console from closing
            Console.ReadLine();
        }

        public static string FizzBuzz<T>(T item)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            string output = "";
            int length = item.ToString().Length;
            if (length % 3 == 0)
            {
                output += "Fizz";
            }
            if (length % 5 == 0)
            {
                output += "Buzz";
            }
            Console.ResetColor();
            return output;
        }

        public interface IErrorCheck
        {
            bool HasError { get; set; }
        }

        public class PersonModel : IErrorCheck
        {
            public string Name { get; set; }
            public int Id { get; set; }

            public bool HasError { get; set; }
        }

        public class CarModel : IErrorCheck
        {
            public string Manufacturer { get; set; }
            public int Year { get; set; }
            public bool HasError { get; set; }
        }

        public class GenericHelper<T> where T : class, IErrorCheck
        {
            public List<T> Items { get; set; } = new List<T>();
            public List<T> RejectedItems { get; set; } = new List<T>();

            public void CheckItemAndAdd(T Item)
            {
                if (Item.HasError == false)
                {
                    Items.Add(Item);
                }
                else
                {
                    RejectedItems.Add(Item);
                }
            }
        }

        public class GenericToString<T> where T : class
        {
            public void Print()
            {
                Console.WriteLine(this.ToString());
            }
        }
    }
}
