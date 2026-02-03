// // Create an abstract class for a membership.  Membership id, contact email, annual cost, current monthly purchases and type are to be properties.  
// In addition to the constructors, include a purchase method, a return method, an abstract apply cash-back rewards method, and a useful toString.

// // Create four classes that inherit from the membership class - one four each membership type.  Create properties for the respective data attributes, 
// implement the apply cash-back method for each as appropriate, and override the toString as appropriate.

using System;
using System.Collections.Generic;

namespace Week5ChallengeCustomerMemberships;
    class Program
    {
        static void Main(string[] args)
        {
            List<Membership> membershipList = new List<Membership>
            {
                new RegularMembership
                {
                    MembershipID = 1001,
                    ContactEmail = "regular@example.com",
                    CurrentMonthlyPurchases = 75m
                },
                new ExecutiveMembership
                {
                    MembershipID = 1002,
                    ContactEmail = "executive@example.com",
                    CurrentMonthlyPurchases = 150m,
                },
                new NonProfitMembership
                {
                    MembershipID = 1003,
                    ContactEmail = "nonprofit@example.com",
                    CurrentMonthlyPurchases = 25m,
                    IsItAMilitaryOrEducationalOrganization = true,
                }, 
                new CorporateMembership
                {
                    MembershipID = 1004,
                    ContactEmail = "corporate@example.com",
                    CurrentMonthlyPurchases = 250m,
                }
            };


            bool userChoice = false;
            string userChoiceString = "";

            do // Main do-while loop, prompts user for action until they choose to quit
            {
                do // Input validation do-while loop for user choice
                {
                    userChoice = false;
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("R: Read all memberships in the membership list.");
                    Console.WriteLine("L: Display all memberships and membership information.");
                    Console.WriteLine("C: Create a new membership.");
                    Console.WriteLine("U: Update an existing membership.");
                    Console.WriteLine("D: Delete an existing membership.");
                    Console.WriteLine("P: Perform a purchase transaction.");
                    Console.WriteLine("T: Perform a return transaction.");
                    Console.WriteLine("A: Apply cash-back rewards.");
                    Console.WriteLine("Q: Quit transaction processing.");


                    userChoiceString = Console.ReadLine();

                    userChoice = (userChoiceString.ToUpper().Equals("R") || 
                    userChoiceString.ToUpper().Equals("L") || 
                    userChoiceString.ToUpper().Equals("C") || 
                    userChoiceString.ToUpper().Equals("U") || 
                    userChoiceString.ToUpper().Equals("D") || 
                    userChoiceString.ToUpper().Equals("P") || 
                    userChoiceString.ToUpper().Equals("T") || 
                    userChoiceString.ToUpper().Equals("A") || 
                    userChoiceString.ToUpper().Equals("Q"));

                    if (!userChoice)
                    {
                        Console.WriteLine("Invalid input, please try again.");
                    }

                } while (!userChoice);

                // End of input validation for the menu loop

    //R         R - Read all of the memberships in the membership list. - ID, and type only.

                if (userChoiceString.ToUpper().Equals("R"))
                {
                    Console.WriteLine("In the R area");

                    foreach(Membership membership in membershipList)
                    {
                        Console.WriteLine($"Membership ID: {membership.MembershipID}, Type: {membership.MembershipType}");
                    }
                } // end of R area

    //L         L - List all of the memberships in the list including all of the information for each account type.
                
                else if (userChoiceString.ToUpper().Equals("L"))
                {
                    Console.WriteLine("In the L area");

                          foreach(Membership membership in membershipList)
                    {
                        Console.WriteLine(membership);
                    }
                    // Prompt user for membership ID and confirm it exists.
                    //Membership membershipFound = null;
                    // var running = true;
                    // while (running)
                    // {
                    //     //try
                    //     //{
                    //         Console.Write("Enter account ID to deposit money into: ");
                    //         //int accountIDInput = int.Parse(Console.ReadLine());

                    //         if(!int.TryParse(Console.ReadLine(), out int accountIDInput))
                    //         {
                    //             Console.WriteLine("Invalid account ID format. Please enter a valid integer.");
                    //             continue;
                    //         }

                    //         var i = accountList.Find(x => x.AccountID == accountIDInput);
                    //         if (i == null)
                    //         {
                    //             Console.WriteLine("Account not found.");
                    //             continue;
                    //         }

                    // } //end of accountID while loop

                    // Prompt user for deposit amount and confirm it's valid
                    // bool validDepositAmount = false;
                    // decimal depositAmountInput = 0.00m;

                    // while(!validDepositAmount)
                    // {
                    //     try
                    //     {
                    //         Console.Write($"Enter $ amount to deposit, current balance: {accountFound.CurrentBalance:C}: ");
                    //         depositAmountInput = decimal.Parse(Console.ReadLine());
                            
                    //         accountFound.Deposit(depositAmountInput);
                    //         validDepositAmount = true;
                    //         Console.WriteLine("Deposit successful. New balance is: " + accountFound.CurrentBalance.ToString("C"));
                    //     }
                    //     catch (FormatException)
                    //     {
                    //         Console.WriteLine("Invalid input format. Please enter a valid decimal number for the deposit amount.");
                    //     }
                    //     catch (Exception ex)
                    //     {
                    //         Console.WriteLine(ex.Message);
                    //     }
                    // } // end of while loop for deposit

                } // end of L area

    //C         C - Create a new membership and add it to the membership list. Be sure you don't duplicate the member ID. It needs to be unqiue.
                else if (userChoiceString.ToUpper().Equals("C"))
                {
                    Console.WriteLine("In the C area");

                    // Prompt user for membership ID and confirm it isn't already in use.
                    int membershipIDInput = -1;
                    bool running = true;
                    while (running)
                    {
                            Console.Write("Enter new membership ID: ");

                            if(!int.TryParse(Console.ReadLine(), out membershipIDInput))
                            {
                                Console.WriteLine("Invalid membership ID format. Please enter a valid integer.");
                                continue;
                            }

                            //Check for existing membership ID
                            var i = membershipList.Find(x => x.MembershipID == membershipIDInput);
                            if (i != null)
                            {
                                Console.WriteLine("Membership ID already exists. Please enter a unique membership ID.");
                                continue;
                            }
                            else
                            {
                                running = false;
                            }
                    } //end of membershipIDValidation while loop

                    Console.WriteLine("Membership ID available. Please continue entering membership information.");

                    Console.Write("Enter membership type (Regular, Executive, NonProfit, Corporate): ");
                    bool validMembershipType = false;
                    string membershipTypeInput = "";
                    while (!validMembershipType)
                    {
                        membershipTypeInput = Console.ReadLine();
                        if (membershipTypeInput.ToUpper().Equals("REGULAR") || membershipTypeInput.ToUpper().Equals("EXECUTIVE") || membershipTypeInput.ToUpper().Equals("NONPROFIT") || membershipTypeInput.ToUpper().Equals("CORPORATE"))
                        {
                            validMembershipType = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid membership type. Please enter Regular, Executive, NonProfit, or Corporate.");
                        }
                    }

                    Console.Write("Enter contact email: ");
                    string contactEmailInput = Console.ReadLine();

                    Console.Write("Enter current monthly purchases: ");
                    decimal currentMonthlyPurchasesInput = 0m;
                    bool validPurchaseAmount = false;
                    while (!validPurchaseAmount)
                    {
                        if (decimal.TryParse(Console.ReadLine(), out currentMonthlyPurchasesInput))
                        {
                            validPurchaseAmount = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid decimal number for the monthly purchases.");
                        }
                    }

                    if (membershipTypeInput.ToUpper().Equals("REGULAR"))
                    {
                    membershipList.Add(new RegularMembership(membershipIDInput, contactEmailInput, currentMonthlyPurchasesInput));
                    }
                    else if (membershipTypeInput.ToUpper().Equals("EXECUTIVE"))
                    {
                    membershipList.Add(new ExecutiveMembership(membershipIDInput, contactEmailInput, currentMonthlyPurchasesInput));
                    }
                    else if (membershipTypeInput.ToUpper().Equals("NONPROFIT"))
                    {
                        Console.Write("Is this a military or educational organization? (yes/no): ");
                        string militaryOrEducationalInput = Console.ReadLine();
                        bool isMilitaryOrEducational = militaryOrEducationalInput.ToUpper().Equals("YES") || militaryOrEducationalInput.ToUpper().Equals("Y");
                    membershipList.Add(new NonProfitMembership(membershipIDInput, contactEmailInput, currentMonthlyPurchasesInput, isMilitaryOrEducational));
                    }
                    else if (membershipTypeInput.ToUpper().Equals("CORPORATE"))
                    {
                    membershipList.Add(new CorporateMembership(membershipIDInput, contactEmailInput, currentMonthlyPurchasesInput));
                    }

                    Console.WriteLine("New membership created successfully.");


                    // Find and confirm account exists
                    // Account accountFound = null;  //can this be the same as foundAccount in D area? Scope issue?

                    // // Prompt user for account ID and confirm it exists.
                    // while (accountFound == null)
                    // {
                    //     try // Try-catch to handle invalid input format
                    //     {
                    //         Console.Write("Enter account ID to withdraw money from: ");
                    //         int accountIDInput = int.Parse(Console.ReadLine());

                    //         foreach (Account account in accountList)
                    //         {
                    //             if (account.AccountID == accountIDInput)
                    //             {
                    //                 accountFound = account;
                    //                 break;
                    //             }
                    //         } // end of accountID foreach loop

                    //         if (accountFound == null)
                    //         {
                    //             Console.WriteLine("Account not found, please try again.");
                    //         }
                    //     }
                    //     catch (FormatException)
                    //     {
                    //         Console.WriteLine("Invalid input format. Please enter a valid account ID.");
                    //     }

                    // } // end of accountID while loop

                    // } // end of while loop

                } // end of C area
    //U
                else if (userChoiceString.ToUpper().Equals("U"))
                {
                    Console.WriteLine("In the U area");

                    Console.WriteLine("Please enter the membership ID of the membership you wish to update:");

                    bool running = true;
                    int membershipIDToUpdate = 0;
                    Membership membershipFound = null;
                    while (running)
                    {
                        if (int.TryParse(Console.ReadLine(), out membershipIDToUpdate))
                        {
                            running = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer for the membership ID.");
                        }

                        membershipFound = membershipList.Find(m => m.MembershipID == membershipIDToUpdate);
                        if (membershipFound != null)
                        {
                            running = false;
                        }
                        else
                        {
                            Console.WriteLine("Membership ID not found, please enter a valid membership ID.");
                        }
                    }

                    Console.Write("Membership ID found. Please enter new contact email: ");
                    string contactEmailInputToUpdateTo = Console.ReadLine();

                    Console.Write("Please enter current monthly purchases amount: ");
                    decimal newMonthlyPurchases = 0;
                    bool validMonthlyPurchases = false;
                    while (!validMonthlyPurchases)
                    {
                        if (decimal.TryParse(Console.ReadLine(), out newMonthlyPurchases))
                        {
                            validMonthlyPurchases = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid decimal number for the monthly purchases.");
                        }
                    }

                    Console.Write("Please enter membership type: ");
                    bool validMembershipType = false;
                    string membershipTypeInputToUpdateTo = "";
                    while (!validMembershipType)
                    {
                        membershipTypeInputToUpdateTo = Console.ReadLine();
                        if (membershipTypeInputToUpdateTo.ToUpper().Equals("REGULAR") || membershipTypeInputToUpdateTo.ToUpper().Equals("EXECUTIVE") || membershipTypeInputToUpdateTo.ToUpper().Equals("NONPROFIT") || membershipTypeInputToUpdateTo.ToUpper().Equals("CORPORATE"))
                        {
                            validMembershipType = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid membership type. Please enter Regular, Executive, NonProfit, or Corporate.");
                        }
                    }

                    bool isMilitaryOrEducational = false;

                    if (membershipTypeInputToUpdateTo.ToUpper() == "NONPROFIT")
                    {
                        Console.Write("Is this a military or educational organization? (yes/no): ");
                        string militaryOrEducationalInput = Console.ReadLine();
                        isMilitaryOrEducational = militaryOrEducationalInput.ToUpper().Equals("YES") || militaryOrEducationalInput.ToUpper().Equals("Y");
                    }

                    Membership updatedMembership;

                    switch (membershipTypeInputToUpdateTo.ToUpper())
                    {
                        case "REGULAR":
                            updatedMembership = new RegularMembership(membershipIDToUpdate, contactEmailInputToUpdateTo, newMonthlyPurchases);
                            break;
                        case "EXECUTIVE":
                            updatedMembership = new ExecutiveMembership(membershipIDToUpdate, contactEmailInputToUpdateTo, newMonthlyPurchases);
                            break;
                        case "NONPROFIT":
                            updatedMembership = new NonProfitMembership(membershipIDToUpdate, contactEmailInputToUpdateTo, newMonthlyPurchases, isMilitaryOrEducational);
                            break;
                        case "CORPORATE":
                            updatedMembership = new CorporateMembership(membershipIDToUpdate, contactEmailInputToUpdateTo, newMonthlyPurchases);
                            break;
                        default:
                            throw new Exception("Unexpected membership type.");
                    }

                    int index = membershipList.IndexOf(membershipFound);
                    membershipList[index] = updatedMembership;

                    Console.WriteLine("Membership updated successfully.");

                } // end of U area

    //D         D - Delete an existing membership from the membership list.

                else if (userChoiceString.ToUpper().Equals("D"))
                {
                    Console.WriteLine("In the D area");

                    Console.WriteLine("Please enter the membership ID of the membership you wish to delete:");
                    bool running = true;
                    int membershipIDToDelete = 0;
                    while (running)
                    {
                        if (int.TryParse(Console.ReadLine(), out membershipIDToDelete))
                        {
                            running = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer for the membership ID.");
                        }

                        Membership membershipFound = membershipList.Find(m => m.MembershipID == membershipIDToDelete);
                        if (membershipFound != null)
                        {
                            running = false;
                        }
                        else
                        {
                            Console.WriteLine("Membership ID not found, please enter a valid membership ID.");
                        }
                    }
                    membershipList.RemoveAll(m => m.MembershipID == membershipIDToDelete);
                    Console.WriteLine("Membership deleted successfully.");
                } // end of D area

    //P         Perform a purchase transaction by getting a membership number from the user and a purchase amount and if 
                // the membership exists add the purchase amount to the monthly purchase total.

                else if (userChoiceString.ToUpper().Equals("P"))
                {
                    Console.WriteLine("In the P area");

                    Console.WriteLine("Please enter the membership ID for the purchase transaction:");
                    bool running = true;
                    int membershipIDForPurchase = 0;
                    while (running)
                    {
                        if (int.TryParse(Console.ReadLine(), out membershipIDForPurchase))
                        {
                            running = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer for the membership ID.");
                        }
                    }

                    Membership membershipFoundForPurchase = membershipList.Find(m => m.MembershipID == membershipIDForPurchase);
                    if (membershipFoundForPurchase != null)
                    {
                        Console.WriteLine("Please enter the purchase amount:");
                        bool running2 = true;
                        decimal purchaseAmount = 0M;
                        while (running2)
                        {
                            if (decimal.TryParse(Console.ReadLine(), out purchaseAmount))
                            {
                                membershipFoundForPurchase.Purchase(purchaseAmount);
                                Console.WriteLine("Purchase successful. New current monthly purchases amount is: " + membershipFoundForPurchase.CurrentMonthlyPurchases.ToString("C"));
                                running2 = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number for the purchase amount.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Membership ID not found.");
                    }   
                } // end of P area

    //T         Perform a return transaction by getting an membership number from the user and a return amount and if 
    //          the membership exists, perform the return by subtracting the return amount for the monthly purchase total.

                else if (userChoiceString.ToUpper().Equals("T"))
                {
                    Console.WriteLine("In the T area");

                    Console.WriteLine("Please enter the membership ID for the return transaction:");
                    bool running = true;
                    int membershipIDForReturn = 0;
                    while (running)
                    {
                        if (int.TryParse(Console.ReadLine(), out membershipIDForReturn))
                        {
                            running = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer for the membership ID.");
                        }
                    }

                    Membership membershipFoundForReturn = membershipList.Find(m => m.MembershipID == membershipIDForReturn);
                    if (membershipFoundForReturn != null)
                    {
                        Console.WriteLine("Please enter the return amount:");
                        bool running2 = true;
                        decimal returnAmount = 0M;
                        while (running2)
                        {
                            if (decimal.TryParse(Console.ReadLine(), out returnAmount))
                            {
                                membershipFoundForReturn.Return(returnAmount);
                                Console.WriteLine("Return successful. New current monthly purchases amount is: " + membershipFoundForReturn.CurrentMonthlyPurchases.ToString("C"));
                                running2 = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number for the return amount.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Membership ID not found.");
                    }   
                } // end of T area

    //A            Apply cash-back reward - For the apply cash-back reward, the membership id will be provided.  Cash-back rewards are handled differently 
    //             depending on the membership type as described above.  When a valid membership ID is given, the system will send a request to the 
    //             rewards system for the amount of the reward.  For this application, you can simply print a console output that says 
    //             "Cash-back reward request for membership xxxxxx in the amount of $yyyy has been made." Then zero out the balance. 

                else if (userChoiceString.ToUpper().Equals("A"))
                {
                    Console.WriteLine("In the A area");

                    Console.WriteLine("Please enter the membership ID to apply cash-back rewards:");
                    bool running = true;
                    int membershipIDForCashBack = 0;
                    while (running)
                    {
                        if (int.TryParse(Console.ReadLine(), out membershipIDForCashBack))
                        {
                            running = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer for the membership ID.");
                        }
                    }

                    Membership membershipFoundForCashBack = membershipList.Find(m => m.MembershipID == membershipIDForCashBack);
                    if (membershipFoundForCashBack != null)
                    {
                        membershipFoundForCashBack.ApplyCashBackRewards();
                        Console.WriteLine($"Cash-back reward request for membership {membershipFoundForCashBack.MembershipID} has been applied. New current monthly purchases amount is: " + membershipFoundForCashBack.CurrentMonthlyPurchases.ToString("C"));
                    }
                    else
                    {
                        Console.WriteLine("Membership ID not found.");
                    }
                } // end of A area
    //Q
                else if (userChoiceString.ToUpper().Equals("Q"))
                {
                    Console.WriteLine("Quitting the program...");
                } // end of Q area
        
            } while (!userChoiceString.ToUpper().Equals("Q")); // end of main do-while loop

            Console.WriteLine("Thank you for using our bank program. Goodbye!");

    } // end of Main
} // end of class