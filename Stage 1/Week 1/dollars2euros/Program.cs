using System;
using System.Diagnostics;

namespace DollarsToEuros
{
    class Program
    {
        static void Main(string[] args)
        {
        /*Program description: This program will take a number from the user, which will be the dollar amount,
        convert that amount to a decimal, calculate the conversion from dollars to euros, and then output the amount of euros.   
        
        Algorithm
        I.   Prompt the user for dollar amount.
             float dollars;
        II.  Obtain the amount of dollars from the user.
              dollars = Convert.ToSingle(Console.ReadLine());
        III. Convert the dollar amount to the euro amount.
        IV.  Output the Euro amount.*/
        //decimal dollars = 0;
        Console.Write("Enter dollar amount: ");

        dollars = Convert.ToDecimal(Console.ReadLine());

        decimal euros = GetEuros(dollars, .85m);
        
        Console.WriteLine($"{dollars} dollars converts to {euros} euros.");
        Console.ReadKey();

        } // end Main method
        static decimal GetEuros(decimal doll, decimal rate) //Method declared
        {
            return doll * rate; //Decimals require m after number
        }// End of method
    } // End Program class
} // End namespace
