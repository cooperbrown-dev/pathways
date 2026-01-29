using System;

namespace VehicleListInterface
{
    class Car : Vehicle, IGetInVehicle, IDriveVehicle
    {
        public int NumberOfDoors // property
            { get; set; }

        public string DriveTrain // property
            { get; set; }

        public bool HasSunroof // property
            { get; set; }

        public Car() : base() // default empty constructor
        {
            NumberOfDoors = 0;
            DriveTrain = "";
            HasSunroof = false;
        }

        public Car(string make, string model, int year, int numberOfDoors, string driveTrain, bool hasSunroof) : base(make, model, year) // constructor with parameters
        {
            NumberOfDoors = numberOfDoors;
            DriveTrain = driveTrain;
            HasSunroof = hasSunroof;
        }

        public override string GetInVehicle() // interface method
        {
            return "How to enter: Open driver side door and get in the car.";
        }

        public override string DriveVehicle() // interface method
        {
            return "Start the car and drive away. Maybe a taco bell run?";
        }

        public override string ToString()
        {
            return base.ToString() + ", " + "Doors: " + NumberOfDoors + ", " + "Drive Train: " + DriveTrain + ", " + "Has Sunroof? " + HasSunroof +
            " " + "\n" + GetInVehicle() + "\n" + DriveVehicle() + "\n";
        }
    } // end of class

} // end of namespace