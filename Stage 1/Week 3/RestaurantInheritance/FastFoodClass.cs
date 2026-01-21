using System;

namespace RestaurantInheritance
{
    public class FastFood : Restaurant
    {
        // Automatic Properties
        public bool DriveThru { get; set; }
        public bool ValueMenu { get; set; }

        // Default constructor for an empty FastFood object
        // use parent constructor for name, cuisine, rating
        public FastFood() : base()
        {
            DriveThru = false;
            ValueMenu = false;
        }

        // Constructor when 5 parameters are provided
        public FastFood(string name, string cuisine, int rating, bool driveThru, bool valueMenu) : base(name, cuisine, rating)
        {
            DriveThru = driveThru;
            ValueMenu = valueMenu;
        }


        // Override ToString method for easy file writing
        public override string ToString()
        {
            return base.ToString() + ", " + "Has a drive thru? " + DriveThru + ", " + "Has a value menu? " + ValueMenu;
        }

    } // end of class FastFood
} // end of namespace RestaurantInheritance