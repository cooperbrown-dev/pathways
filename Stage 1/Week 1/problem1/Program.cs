using System;
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

        Do
            Prompt User for a base number, and show option to quit.
            Obtain base
                If, base is integer
                    If, base is greater than or equal to 1
                        Do
                            Prompt User for exponent 
                                If, exponent is integer
                                    If, exponent is greater than or equal to 1
                                        Integer and exponent is valid! Run Power Function
                                Else, provide range error message
                            Else, provide type error message
                        While
                    Else, provide range error message
                Else, provide type error message

            Obtain the result of Power Function
            Display result
        While
        */
        
        int answer;
        bool userIsDone = false;
        bool isValid = false;

        do
        {

        Console.Write("Please enter a base number or enter \"q\" to quit program: ");
        string input = Console.ReadLine();

            
            if (int.TryParse(input, out int result))
            {
                if(result >= 1) //trying do while loop here
                {
                    do //beginning of inner do loop
                    {
                        Console.Write("Please enter an exponent: ");
                        string strExponent = Console.ReadLine();
                        if(int.TryParse(strExponent, out int intExponent))
                        {
                            if(intExponent >= 1)
                            {
                                isValid = true;
                                answer = Power(result, intExponent);
                                Console.WriteLine($"{result} to the power of {intExponent} is {answer}");
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
                    while(isValid == false); //end of inner do while
                }
                else
                {
                    Console.WriteLine("Error: Please provide a number greater than 0.");
                } // end of second conditional statement.
            }
            else if ("q" == input)
            {
                userIsDone = true; 
            }
            else
            {
                Console.WriteLine("Error: Please provide a whole number.");
            } // end of first conditional statement.
            
        } //end of outer do

        while(userIsDone == false); //ender of outer while

        Console.WriteLine("Program ended. Press any key to exit.");
        Console.ReadLine();
    } //end of main

    static int Power(int a, int b)
    {
        return (int) Math.Pow(a, b);
    }
}