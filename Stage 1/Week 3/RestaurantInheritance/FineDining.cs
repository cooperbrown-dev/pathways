using System;

namespace RestaurantInheritance
{
    public class FineDining : Restaurant
    {
        // Automatic Properties
        public bool ReservationsRequired { get; set; }
        public bool ChaufferAvailable { get; set; }

        // Default constructor for an empty FineDining object
        public FineDining() : base()
        {
            ReservationsRequired = false;
            ChaufferAvailable = false;
        }

        // Constructor when 5 parameters are provided
        public FineDining(string name, string cuisine, int rating, bool reservationsRequired, bool chaufferAvailable) : base(name, cuisine, rating)
        {
            ReservationsRequired = reservationsRequired;
            ChaufferAvailable = chaufferAvailable;
        }


        // Override ToString method for easy file writing
        public override string ToString()
        {
            return base.ToString() + ", " + "Reservations required? " + ReservationsRequired + ", " + "Chauffer available? " + ChaufferAvailable;
        }

    } // end of class FineDining
} // end of namespace RestaurantInheritance