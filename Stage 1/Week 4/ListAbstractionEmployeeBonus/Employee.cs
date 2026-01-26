using System;

namespace ListAbstractionEmployeeBonuses
{
    public abstract class Employee
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

        public abstract decimal CalculateBonus(); //set to abstract to require overriding in derived classes

        public abstract decimal WeeklyPay(); //abstract method for calculating weekly pay

        // Override ToString method for easy file writing
        public override string ToString() //does not need the virtual keyword, baked into the ToString method?
        {
            return("Last name: " + LastName + ", First name: " + FirstName + ", Employee type: " + EmployeeType);
        }

    } // end of class Employee
} // end of namespace EmployeeBonuses