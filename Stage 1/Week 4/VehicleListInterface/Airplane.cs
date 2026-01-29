using System;

namespace VehicleListInterface
{
    class Airplane : Vehicle, IGetInVehicle, IDriveVehicle
    {
        public int NumberOfEngines // property
            { get; set; }

        public string WingSpan // property
            { get; set; }

        public Airplane() : base() // default empty constructor
        {
            NumberOfEngines = 0;
            WingSpan = "";
        }

        public Airplane(string make, string model, int year, int numberOfEngines, string wingSpan) : base(make, model, year) // constructor with parameters
        {
            NumberOfEngines = numberOfEngines;
            WingSpan = wingSpan;
        }

        public override string GetInVehicle() // interface method
        {
            return "How to enter: Walk down the jetway and into the airplane.";
        }

        public override string DriveVehicle() // interface method
        {
            return "Start the airplane and taxi down the runway. Get ready for takeoff! Fly high in the sky.";
        }

        public override string ToString()
        {
            return base.ToString() + ", " + "Engines: " + NumberOfEngines + ", " + "Wing Span: " + WingSpan + "\n" + GetInVehicle() + "\n" + DriveVehicle();
        }
    } // end of class
} // end of namespace