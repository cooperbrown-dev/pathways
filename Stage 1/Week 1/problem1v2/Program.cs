using System;
using System.Reflection.Metadata;
class Problem1
{
    static void Main(string[] args)
    {
        /*
        Problem description:  Create a program that will obtain a base from the user and an exponent from the user and 
        will print out the value of the base taken to the exponent power.  Use a method, Power, to calculate the value.  
        Be sure that both the base and exponent are integers greater than or equal to 1. So, check that both the data type
         is valid and that the value is valid. Repeat the process until the user wants to quit. 


        Algorithim:
        Prompt User for a base number, and show option to quit. //while loop
            If, base is integer //first do while loop
                If, base is greater than or equal to 1, save number and exit loop.
                Else, provide range error message
            Else, provide type error message

                    Prompt User for exponent //start of next do while loop
                        If, exponent is integer
                            If, exponent is greater than or equal to 1
                                Integer and exponent is valid! Run Power Function
                            Else, provide range error message
                        Else, provide type error message

        Obtain the result of Power Function
        Display result
        */
        

        bool userIsDone = false;
        bool isValid = false;
        string input = string.Empty;
        string strResult = string.Empty;
        int intResult = 0;
        

        while(userIsDone == false)
        {
            Console.WriteLine("Please enter a base number or enter \"q\" to quit program: ");

            input = Console.ReadLine();
            if(input = "q")
            {
                userIsDone = true;
            }
                do
                {
                    if (int.TryParse(input, out intResult))
                    {
                        if(intResult >= 1) //trying do while loop here
                        {
                            Console.WriteLine("Test");
                            isValid = true; //exit this loop
                            Console.WriteLine("Test2");
                        }
                        else
                        {
                            Console.WriteLine("Error: Please provide a number greater than 0.");
                        } // end of second conditional statement.
                    } 
                    else
                    {
                        Console.WriteLine("Error: Please provide a whole number.");
                    } // end of first conditional statement.
                    
                } //end of do
                while(isValid == false); //end of first do while loop

                    do
                    {
                        Console.WriteLine("Please enter an exponent or press \"q\" to quit the program: ");
                        string strExponent = Console.ReadLine();
                        if(int.TryParse(strExponent, out int intExponent))
                        {
                            if(intExponent >= 1)
                            {
                                int answer = Power(intResult, intExponent);
                                Console.WriteLine($"{intResult} to the power of {intExponent} is {answer}");
                            }
                            else
                            {
                                Console.WriteLine("Error: Please provide a number greater than 0.");
                            }
                            }
                        else
                        {
                        Console.WriteLine("Error: Please provide a whole number.");
                        }
                    }
                    while(userIsDone == false);

        } //end of while loop

        Console.WriteLine("Program ended. Press any key to exit.");
        Console.ReadLine();

    } //end of main

    static int Power(int a, int b)
    {
        return (int) Math.Pow(a, b);
    }
}