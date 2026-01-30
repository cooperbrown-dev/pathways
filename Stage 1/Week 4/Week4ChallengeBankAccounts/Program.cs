using System;
using System.Collections.Generic;   // needed for Lists

namespace Week4ChallengeBankAccounts;

class Program
{
    static void Main (string[] args)
    {
        // Create an empty list of Accounts
        List<Account> accountList = new List<Account>();

        //Adding accounts to the list
        accountList.Add(new SavingsAccount(1001, "Savings", 100000, 0.03m));
        accountList.Add(new CheckingAccount(1002, "Checking", 50000, 50.00m));
        accountList.Add(new CDAccount(1003, "CD", 20000, 0.06m, 0.08m));

        foreach(Account account in accountList)
        {
            Console.WriteLine(account);
        }

        bool userChoice;
        string userChoiceString;

        do // Main do-while loop, prompts user for action until they choose to quit
        {
            do // Input validation do-while loop for user choice
            {
                userChoice = false;
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("L: Display all accounts and account information.");
                Console.WriteLine("D: Deposit money into an account.");
                Console.WriteLine("W: Withdraw money from an account.");
                Console.WriteLine("Q: Quit transaction processing.");

                userChoiceString = Console.ReadLine();

                userChoice = (userChoiceString.ToUpper().Equals("L") || 
                userChoiceString.ToUpper().Equals("D") || 
                userChoiceString.ToUpper().Equals("W") || 
                userChoiceString.ToUpper().Equals("Q"));

                if (!userChoice)
                {
                    Console.WriteLine("Invalid input, please try again.");
                }

            } while (!userChoice);

            if (userChoiceString.ToUpper().Equals("L"))
            {
                Console.WriteLine("In the L area");

                foreach(Account account in accountList)
                {
                    Console.WriteLine(account);
                }

            }

            else if (userChoiceString.ToUpper().Equals("D"))
            {
                Console.WriteLine("In the D area");
//D
                // Prompt user for account ID and confirm it exists.
                Account foundAccount = null;

                while (foundAccount == null)
                {
                    try
                    {
                        Console.Write("Enter account ID to deposit money into: ");
                        int accountIDInput = int.Parse(Console.ReadLine());

                        foreach(Account account in accountList)
                        {
                            if (account.AccountID == accountIDInput)
                            {
                                foundAccount = account;
                                break;
                            }
                        }

                        if (foundAccount == null)
                        {
                            Console.WriteLine("Account not found, please try again.");
                        }
                    } // end of try
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input format. Please enter a valid account ID.");
                    }
                } //end of accountID while loop

                // Prompt user for deposit amount and confirm it's valid
                bool validDepositAmount = false;
                decimal depositAmountInput = 0.00m;

                while(!validDepositAmount)
                {
                    try
                    {
                        Console.Write($"Enter $ amount to deposit, current balance: {foundAccount.CurrentBalance:C}: ");
                        depositAmountInput = decimal.Parse(Console.ReadLine());
                        
                        foundAccount.Deposit(depositAmountInput);
                        validDepositAmount = true;
                        Console.WriteLine("Deposit successful. New balance is: " + foundAccount.CurrentBalance.ToString("C"));
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input format. Please enter a valid decimal number for the deposit amount.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                } // end of while loop for deposit

            } // end of D area --------------------------------------------------------------------------

            else if (userChoiceString.ToUpper().Equals("W"))
            {
                Console.WriteLine("In the W area");
//W
                // Find and confirm account exists
                Account accountFound = null;

                // Prompt user for account ID and confirm it exists.
                while (accountFound == null)
                {
                    try // Try-catch to handle invalid input format
                    {
                        Console.Write("Enter account ID to withdraw money from: ");
                        int accountIDInput = int.Parse(Console.ReadLine());

                        foreach (Account account in accountList)
                        {
                            if (account.AccountID == accountIDInput)
                            {
                                accountFound = account;
                                break;
                            }
                        } // end of accountID foreach loop

                        if (accountFound == null)
                        {
                            Console.WriteLine("Account not found, please try again.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input format. Please enter a valid account ID.");
                    }

                } // end of accountID while loop

                // Prompt user for withdraw amount, pass into Withdraw() method, validate the amount, return new balance if validated.
                bool validWithdrawAmount = false;
                decimal withdrawAmountInput = 0.00m;

                while (!validWithdrawAmount)
                {
                    try
                    {
                        Console.Write($"Enter amount to withdraw from {accountFound.AccountType} account {accountFound.AccountID}: {accountFound.CurrentBalance:C} available: ");
                        withdrawAmountInput = decimal.Parse(Console.ReadLine());

                        accountFound.Withdraw(withdrawAmountInput);
                        validWithdrawAmount = true;
                        Console.WriteLine($"{accountFound.AccountType} account balance updated. Account balance is now: {accountFound.CurrentBalance:C}");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input format. Please enter a valid decimal number for the withdrawal amount.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                } // end of while loop

            } // end of W area

            else if (userChoiceString.ToUpper().Equals("Q"))
            {
                Console.WriteLine("Quitting the program...");
            } // end of Q area
    
        } while (!userChoiceString.ToUpper().Equals("Q")) ;

        Console.WriteLine("Thank you for using our bank program. Goodbye!");

    } // end of Main
} // end of class

/* // Previous Withdraw method logic in Program.cs before moving to Account classes

                // Prompt user for withdraw amount, confirm it's valid per account type rules
 bool validWithdrawAmount = false;
                decimal withdrawAmountInput = 0.00m;

                while (!validWithdrawAmount)
                {
                    try
                    {
                        Console.Write($"Enter $ amount to withdraw from {accountFound.AccountType} account {accountFound.AccountID}: ");
                        withdrawAmountInput = decimal.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input format. Please enter a valid decimal number for the withdrawal amount.");
                        continue; // Prompt user again
                    }

                    if (withdrawAmountInput > 0 && withdrawAmountInput <= accountFound.CurrentBalance) //check if withdraw amount is valid
                    {
                        accountFound.Withdraw(withdrawAmountInput);
                        validWithdrawAmount = true;
                        //Console.WriteLine($"{accountFound.AccountType} account balance updated. Account balance is now: {accountFound.CurrentBalance:C}");
                    }
                    else
                    {
                        Console.WriteLine("Error: Withdraw amount must be greater than 0 and less than or equal to the current balance.");
                    }
                } // end of while loop
*/