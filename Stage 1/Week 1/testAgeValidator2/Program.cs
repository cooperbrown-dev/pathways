using System;
class GetTheTotal
{
    static void Main(string[] args)
    {
        /*
        - Ask user to input age
        - Obtain age
        - Validate that age is an integer
        -   If age is an integer, validate that it's between 0 and 120
                If age is between 0 and 120, print valid age
                If age is not between 0 and 120, provide range error
        - If age is not an integer, provide type error
        */

        int age;
        bool isValid = false;

        Console.WriteLine("Please enter age (0-120): ");
        do
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out age))
            {
                if (age >= 0 && age <= 120)
                {
                    Console.WriteLine($"Age validated: {age}");
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Error: Please enter a number between 0 and 120.");
                }
            }
            else
            {
                Console.WriteLine("Error: Please enter a whole number.");
            }
        }

        while(!isValid);
        Console.WriteLine("End of the program. Press any key to exit.");
    }
}


