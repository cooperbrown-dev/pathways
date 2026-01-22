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

        /* Non shorthand version
        private bool driveThru;
        private bool valueMenu;

        public bool DriveThru
        {
         get { return DriveThru; }
         set { DriveThru = value; }
        }

        public bool ValueMenu
        {
         get { return ValueMenu; }
         set { ValueMenu = value; }
        }
        */

    } // end of class FastFood
} // end of namespace RestaurantInheritance