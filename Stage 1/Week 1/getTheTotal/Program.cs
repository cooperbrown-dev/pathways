using System;

namespace GetTotalNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Program descritpion: Prompt user for 5 positive integers. Add them all together and print the result.

        -For each of 5 numbers.
            Prompt for a number.
            Obtain the number.
            If number is an integer
                Check that the number is positive.
                If the number is positive, add it to the accumulator.
                Else, provide error message requesting a positive number.
            else, provide type error.
        Print the total.
        */

            int total = 0; //Accumulator
            int number = 0; //Initialize the number variable.

            //Ask the user to input a number, one at a time
            Console.WriteLine("Please enter 5 positive whole numbers, one at a time: ");

            //Use a for loop to get 5 validated inputs.
            for(int i = 0; i < 5; i++)
            {
                //Use a while loop to validate input for a whole number, and positive number
                bool isValid = false;
                while (!isValid)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out number)) //checking to make sure the string equals an integer when converted.
                    {
                        //check to make sure the number is positive.
                        if(number >= 0)
                        {
                            isValid = true; //number validated, exit the while loop.
                        }
                        else
                        {
                            Console.WriteLine("Error: Please enter a positive number.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Please enter an whole number.");
                    }
                }  //end while not is valid
                //Add the inputted number to the accumulator
                //total += number; put this into a method below.
                total = AccumulateTotal(total, number);
            }

            Console.WriteLine($"The total of all inputed numbers is: {total}"); //print the total after the for loop is done

        } // end Main method
        static int AccumulateTotal(int a, int b)
        {
            return a += b;
        }
    } // end Program class
} // end namespace