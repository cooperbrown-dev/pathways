using System;

namespace ListAbstractionEmployeeBonuses
{
    public class HourlyEmployee : Employee
    {
        // Automatic Properties
        public decimal HourlyRate { get; set; }

        // Default constructor for an empty Employee object
        public HourlyEmployee() : base()
        {
            HourlyRate = 0.00M;
        }

        // Constructor with all parameters provided
        public HourlyEmployee(string lastName, string firstName, string employeeType, decimal hourlyRate) : base(lastName, firstName, employeeType)
        {
            HourlyRate = hourlyRate;
        }

        public override decimal CalculateBonus()
        {
            decimal bonus = 80 * HourlyRate;
            Console.WriteLine($"{FirstName} {LastName}'s hourly bonus is: ${bonus}");
            return bonus;
        }

        public override decimal WeeklyPay()
        {
            decimal weeklyPay = 40 * HourlyRate;
            Console.WriteLine($"{FirstName} {LastName}'s weekly pay is: ${weeklyPay}");
            return weeklyPay;
        }

        // Override ToString method for easy file writing
        public override string ToString()
        {
            //Use polymorphism to call base ToString and add HourlyRate info
            return(base.ToString() + ", Hourly rate: $" + HourlyRate);
        }

    } // end of class Employee
} // end of namespace EmployeeBonuses