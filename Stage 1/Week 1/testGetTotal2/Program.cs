using System;

class testGetTotal2
{
    static void Main(string[] args)
    {
        /* Program descritpion: Prompt user for 5 positive integers. Add them all together and print the result.

        -Prompt user for 5 numbers, one at a time.
            If number is an integer
                Check that the number is positive.
                If the number is positive, add it to the accumulator.
                If the number is not, provide error message requesting a positive number.
            If not an integer, provide type error.
            After 5 numbers are collected, print the total.
        */

        int number = 0;
        int total = 0;

        Console.WriteLine("Please enter five positive integers, 1 at a time: ");

        for (int i = 0; i < 5; i++)
        {
            bool isValid = false;
            while (!isValid)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    if (number > 0)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Error: Please enter a positive number");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Please enter a whole number");
                }
            }
            total += number;
        }
        Console.WriteLine($"Total is {total}.");

        

        
    }
}