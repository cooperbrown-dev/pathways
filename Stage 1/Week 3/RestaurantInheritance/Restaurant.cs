using System;

namespace RestaurantInheritance
{
    public class Restaurant
    {
        // Automatic Properties
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public int? Rating { get; set; }

        // Default constructor for an empty Restaurant object
        public Restaurant()
        {
            Name = " ";
            Cuisine = " ";
            Rating = 0;
        }

        // Constructor with 3 parameters provided
        public Restaurant(string name, string cuisine, int rating)
        {
            Name = name;
            Cuisine = cuisine;
            Rating = rating;
        }

        // Override ToString method for easy file writing
        public override string ToString()
        {
            return(Name + ", " + Cuisine + ", " + Rating + "/5 Stars");
        }

    } // end of class Restaurant
} // end of namespace RestaurantInheritance