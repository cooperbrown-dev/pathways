using System;
using System.Collections.Generic;   // needed for Lists

namespace VehicleListInterface
{
  class Program
  {
    static void Main(string[] args)
    { 

        // Create a list of Vehicles
        List<Vehicle> vehicleList = new List<Vehicle>();

        // Add a vehicle to the list to test
        vehicleList.Add(new Vehicle("Ford", "Mustang", 2007));

        // Add a car vehicle to the list to test
        vehicleList.Add(new Car("Honda", "Civic", 2018, 4, "FWD", true));

        // Add a motorcycle vehicle to the list to test
        vehicleList.Add(new Motorcycle("Harley-Davidson", "Street Glide", 2023, false, "Cruiser", "32 inches"));

        // Add a airplane vehicle to the list to test
        vehicleList.Add(new Airplane("Boeing", "747", 2015, 4, "224 feet"));

        // Print the list
        foreach (Vehicle vehicle in vehicleList)
        {
            Console.WriteLine(vehicle);
        } // end foreach  

        // Test calling interface methods directly from the list with polymorphism
        Console.WriteLine();
        Console.WriteLine(vehicleList[1].GetInVehicle());
        Console.WriteLine(vehicleList[2].DriveVehicle());

    } // end Main

  }  // end class Program

}  // end nameSspace