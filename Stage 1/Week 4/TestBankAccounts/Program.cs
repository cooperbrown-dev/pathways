using System;
using System.Collections.Generic;

namespace TestBankAccounts;

class Program
{
    static void Main(string[] args)
    {
        //Making a new empty list for Account objects
        List<Account> accountList = new List<Account>();

        bool userChoice = false;
        string userInput = "";
        
        do
        {
            do
            {
                Console.WriteLine("What would you like to do?");
                    
                Console.WriteLine("L: Display all accounts and account information.");
                Console.WriteLine("D: Deposit money into an account.");
                Console.WriteLine("W: Withdraw money from an account.");
                Console.WriteLine("Q: Quit transaction processing.");

                userInput = Console.ReadLine();

                if (userInput.ToUpper() == "L" ||
                    userInput.ToUpper() == "D" ||
                    userInput.ToUpper() == "W" ||
                    userInput.ToUpper() == "Q")
                {
                    userChoice = true;
                }

                else
                {
                    Console.WriteLine("Incorrect input, please enter one of the options on the list");
                }

            } while (!userChoice);

            if (userInput.ToUpper() == "L")
            {
                Console.WriteLine("In the L area");
            }
            
            else if (userInput.ToUpper() == "D")
            {
                Console.WriteLine("In the D area");
            }
            
            else if (userInput.ToUpper() == "W")
            {
                Console.WriteLine("In the D area");
            }

        } while (userInput.ToUpper() != "Q");

        Console.WriteLine("Exiting program...");
    } // end of main
} // end of Program class
