using System;

namespace InterfaceAndDI
{
    class Program
    {
        static void Main(string[] args)
        {
            IDriveThru order = new McDonaldsDriveThru();
            //IDriveThru order = new RunzaOrder();
            //IDriveThru order = new TacoBellOrder();

            DriveThruService driveThruService = new DriveThruService(order);
            driveThruService.Order("Your order here.");

        }
    }
}