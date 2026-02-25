using System;

namespace InterfaceAndDI
{
    public class McDonaldsDriveThru : IDriveThru
    {
        public void Order(string order)
        {
            Console.WriteLine("At McDonalds DriveThru.");
            OrderFood(order);
        }

        private void OrderFood(string order)
        {
            Console.WriteLine($"Welcome to Mcdonalds, please place your order: {order}");
        }
    }
}
