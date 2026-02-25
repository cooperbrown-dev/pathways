using System;

namespace InterfaceAndDI
{
    public class TacoBellDriveThru : IDriveThru
    {
        public void Order(string order)
        {
            Console.WriteLine("At Taco Bell DriveThru.");
            OrderFood(order);
        }

        private void OrderFood(string order)
        {
            Console.WriteLine($"Welcome to Taco Bell, please place your order: {order}");
        }
    }
}
