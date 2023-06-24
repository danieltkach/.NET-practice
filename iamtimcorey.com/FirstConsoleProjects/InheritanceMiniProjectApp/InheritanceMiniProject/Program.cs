using System;
using System.Collections.Generic;

namespace InheritanceMiniProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IRentable> rentables = new List<IRentable>();
            List<IPurchasable> purchasables = new List<IPurchasable>();

            var vehicle = new VehicleModel() { DealerFee = 25, ProductName = "Kia Optima" };
            var book = new BookModel() { ProductName = "A Tale of Two Cities", NumberOfPages = 350 };
            var excavator = new ExcavatorModel() { ProductName = "Bulldozer", QuantityInStock = 2 };

            rentables.Add(vehicle);
            rentables.Add(excavator);

            purchasables.Add(book);
            purchasables.Add(vehicle);

            Console.Write("Do you want to rent or purchase something (rent / purchase): ");
            string decision = Console.ReadLine();
            if (decision.ToLower() == "rent")
            {
                foreach (var item in rentables)
                {
                    Console.WriteLine($"Item: {item.ProductName}");
                    Console.Write("Do you want to rent this item (yes / no): ");
                    string yesNoAnswer = Console.ReadLine();
                    if (yesNoAnswer.ToLower() == "yes")
                    {
                        item.Rent();
                    }
                }
            }
            else
            {
                foreach (var item in purchasables)
                {
                    Console.WriteLine($"Item: {item.ProductName}");
                    Console.Write("Do you want to purchase this item (yes / no): ");
                    string yesNoAnswer = Console.ReadLine();
                    if (yesNoAnswer.ToLower() == "yes")
                    {
                        item.Purchase();
                    }
                }
            }
            Console.WriteLine("We are done. Thank you!");
            Console.ReadLine();
        }
    }
}
