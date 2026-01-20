using System;

namespace RestaurantOOP
{
    public class Restaurant
    {
        // Automatic Properties
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public int Rating { get; set; }

        // Constructor
        public Restaurant(string name, string cuisine, int rating)
        {
            Name = name;
            Cuisine = cuisine;
            Rating = rating;
        }

        //add a constructor for an empty Restaurant object?

        // Override ToString method for easy file writing
        public override string ToString()
        {
            return(Name + ", " + Cuisine + ", " + Rating + "/5 Stars");
        }

    } // end of class Restaurant
} // end of namespace RestaurantOOP