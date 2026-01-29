using System;

namespace VehicleListInterface
{
    class Motorcycle : Vehicle, IGetInVehicle, IDriveVehicle
    {
        public bool HasSidecar // property
            { get; set; }

        public string MotorcycleType // property
            { get; set; }

        public string SeatHeight // property
            { get; set; }

        public Motorcycle() : base()// default empty constructor
        {
            HasSidecar = false;
            MotorcycleType = "";
            SeatHeight = "";
        }

        public Motorcycle(string make, string model, int year, bool hasSidecar, string motorcycleType, string seatHeight) : base(make, model, year) // constructor with parameters
        {
            HasSidecar = hasSidecar;
            MotorcycleType = motorcycleType;
            SeatHeight = seatHeight;
        }

        public override string GetInVehicle() // interface method
        {
            return "How to enter: Hop over and onto the motorcycle seat.";
        }

        public override string DriveVehicle() // interface method
        {
            return "Start the motorcycle, drive down the street, start popping wheelies.";
        }

        public override string ToString()
        {
            return base.ToString() + ", " + "Has Sidecar? " + HasSidecar + ", " + "Motorcycle Type: " + MotorcycleType + ", " + "Seat Height: " + SeatHeight
            + "\n" + GetInVehicle() + "\n" + DriveVehicle() + "\n";
        }
    } // end of class
} // end of namespace
