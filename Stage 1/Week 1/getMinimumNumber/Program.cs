using System;
class getMinimumNumber
{
    static void Main(string[] args)
    {
        /*
        - Ask user to input 10 integers //for loop since we know we want it 10 times.
            -Obtain integer and validate it. //while loop since we don't know how many inputs the user will provide.
            -Compare validated number to max value, keep the lowest number.
            -After 10 numbers have been entered, show the lowest number.
        */

        int numberCompare = int.MaxValue; //Have to set it to something to start the comparison

        Console.WriteLine("Please enter an integer: ");

        for (int i = 0; i < 10; i++)
        {
            bool isValid = false;
            while (!isValid)
            {
            string input = Console.ReadLine();
            if(int.TryParse(input, out int currentNumber))
                {
                    if (currentNumber < numberCompare)
                    {
                        numberCompare = currentNumber;
                        isValid = true;
                    }
                }
                else
                {
                    Console.WriteLine("Error: Please enter a whole number.");
                }
                
            }
        }

        Console.WriteLine($"The lowest number is: {numberCompare}");
    }
}