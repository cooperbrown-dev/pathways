using System;

namespace VehicleListInterface
{
    class Vehicle : IGetInVehicle, IDriveVehicle
    {
        public string Make // property
            { get; set; }

        public string Model // property
            { get; set; }

        public int Year // property
            { get; set; }

        public Vehicle() // default empty constructor
        {
            Make = "";
            Model = "";
            Year = 0;
        }

        public Vehicle(string make, string model, int year) // constructor with parameters
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public virtual string GetInVehicle() // interface method
        {
            return "Enter vehicle.";
        }

        public virtual string DriveVehicle() // interface method
        {
            return "Drive vehicle.";
        }

        public override string ToString()
        {
            return "Vehicle: " + Year + " " + Make + " " + Model;
        }
    } // end of class

} // end namespace