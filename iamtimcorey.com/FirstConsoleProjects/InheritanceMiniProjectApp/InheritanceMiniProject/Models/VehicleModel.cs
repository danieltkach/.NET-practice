using System;

namespace InheritanceMiniProject
{
    public class VehicleModel : InventoryItemModel, IRentable, IPurchasable
    {
        public decimal DealerFee { get; set; }

        public void Purchase()
        {
            QuantityInStock -= 1;
            Console.WriteLine("This vehicle has been purchased.");
        }

        public void Rent()
        {
            QuantityInStock -= 1;
            Console.WriteLine("This vehicle has been rented.");
        }

        public void ReturnRental()
        {
            QuantityInStock += 1;
            Console.WriteLine("This vehicle has been returned.");
        }
    }
}
