using System;

namespace InterfaceAndDI
{
    public class RunzaDriveThru : IDriveThru
    {
        public void Order(string order)
        {
            Console.WriteLine("At Runza DriveThru.");
            OrderFood(order);
        }

        private void OrderFood(string order)
        {
            Console.WriteLine($"Welcome to Runza, please place your order: {order}");
        }
    }

}
