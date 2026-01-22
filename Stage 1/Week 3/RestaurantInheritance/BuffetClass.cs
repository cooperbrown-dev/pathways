using System;

namespace MusicInheritancePolymorphism
{
    public class Buffet : Restaurant
    {
        // Automatic Properties
        public bool AllYouCanEat { get; set; }
        public bool dessert { get; set; }

        // Default constructor for an empty Buffet object
        public Buffet() : base()
        {
            AllYouCanEat = false;
            dessert = false;
        }

        // Constructor when 5 parameters are provided
        public Buffet(string name, string cuisine, int rating, bool allYouCanEat, bool dessert) : base(name, cuisine, rating)
        {
            AllYouCanEat = allYouCanEat;
            this.dessert = dessert;
        }

        // Override ToString method for easy file writing
        public override string ToString()
        {
            return base.ToString() + ", " + "All you can eat? " + AllYouCanEat + ", " + "Has dessert? " + dessert;
        }

    } // end of class Buffet
} // end of namespace RestaurantInheritance