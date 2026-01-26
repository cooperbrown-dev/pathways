using System;

namespace ListAbstractionEmployeeBonuses
{
    public class SalaryEmployee : Employee
    {
        // Automatic Properties
        public decimal AnnualSalary { get; set; }

        // Default constructor for an empty Employee object
        public SalaryEmployee() : base()
        {
            AnnualSalary = 0.0M;
        }

        // Constructor with all parameters provided
        public SalaryEmployee(string lastName, string firstName, string employeeType, decimal annualSalary) : base(lastName, firstName, employeeType)
        {
            AnnualSalary = annualSalary;
        }

        public override decimal CalculateBonus()
        {
            decimal bonus = .10M * AnnualSalary;
            Console.WriteLine($"{FirstName} {LastName}'s salary bonus is: ${bonus:0.00}");
            return bonus;
        }

        public override decimal WeeklyPay()
        {
            decimal weeklyPay = AnnualSalary / 52;
            Console.WriteLine($"{FirstName} {LastName}'s weekly pay is: ${weeklyPay:0.00}");
            return weeklyPay;
        }

        // Override ToString method for easy file writing
        public override string ToString()
        {
            //Use polymorphism to call base ToString and add AnnualSalary info
            return(base.ToString() + ", Annual salary: $" + AnnualSalary);
        }

    } // end of class Employee
} // end of namespace EmployeeBonuses