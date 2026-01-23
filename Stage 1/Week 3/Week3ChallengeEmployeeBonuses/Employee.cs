using System;

namespace EmployeeBonuses
{
    public class Employee
    {
        // Automatic Properties
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EmployeeType { get; set; }

        // Default constructor for an empty Employee object
        public Employee()
        {
            LastName = " ";
            FirstName = " ";
            EmployeeType = " ";
        }

        // Constructor with all parameters provided
        public Employee(string lastName, string firstName, string employeeType)
        {
            LastName = lastName;
            FirstName = firstName;
            EmployeeType = employeeType;
        }

        public virtual decimal CalculateBonus() //set to virtual to allow overriding in derived classes
        {
            decimal bonus = 0.00M;
            Console.WriteLine($"{FirstName} {LastName}'s bonus is: ${bonus:0.00}");
            return bonus;
        }

        // Override ToString method for easy file writing
        public override string ToString() //does not need the virtual keyword, baked into the ToString method?
        {
            return("Last name: " + LastName + ", First name: " + FirstName + ", Employee type: " + EmployeeType);
        }

    } // end of class Employee
} // end of namespace EmployeeBonuses