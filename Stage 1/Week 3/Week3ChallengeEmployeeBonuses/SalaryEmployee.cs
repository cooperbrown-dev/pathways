using System;

namespace EmployeeBonuses
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

        // Override ToString method for easy file writing
        public override string ToString()
        {
            return("Last name: " + LastName + ", First name: " + FirstName + ", Employee type: " + EmployeeType + ", Annual salary: $" + AnnualSalary);
        }

    } // end of class Employee
} // end of namespace EmployeeBonuses