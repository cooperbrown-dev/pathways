using System;

namespace InterfaceAndDI
{
    public class DriveThruService : IDriveThru
    {
        private readonly IDriveThru _drivethru;
        public DriveThruService(IDriveThru drivethru)
        {
            _drivethru = drivethru;
        }
        public void Order(string order)
        {
            _drivethru.Order(order);
        }
    }
}