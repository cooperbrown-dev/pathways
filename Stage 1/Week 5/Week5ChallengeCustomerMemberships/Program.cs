using System;
using System.Collections.Generic;

namespace Week5ChallengeCustomerMemberships;
    class Program
    {
        static void Main(string[] args)
        {

            // Create a list of memberships, and filling it with some sample data

            List<Membership> membershipList = new List<Membership>
            {
                new RegularMembership
                {
                    MembershipID = 1001,
                    ContactEmail = "regular@example.com",
                    CurrentMonthlyPurchases = 400m
                },
                new ExecutiveMembership
                {
                    MembershipID = 1002,
                    ContactEmail = "execunder1000@mexample.com",
                    CurrentMonthlyPurchases = 600m,
                },
                new ExecutiveMembership
                {
                    MembershipID = 1003,
                    ContactEmail = "execover1000@example.com",
                    CurrentMonthlyPurchases = 1500m,
                },
                new CorporateMembership
                {
                    MembershipID = 1004,
                    ContactEmail = "corporate@example.com",
                    CurrentMonthlyPurchases = 2500m,
                },
                new NonProfitMembership
                {
                    MembershipID = 1005,
                    ContactEmail = "truenonprofit@example.com",
                    CurrentMonthlyPurchases = 800m,
                    IsItAMilitaryOrEducationalOrganization = true,
                }, 
                new NonProfitMembership
                {
                    MembershipID = 1006,
                    ContactEmail = "falsenonprofit2@example.com",
                    CurrentMonthlyPurchases = 500m,
                    IsItAMilitaryOrEducationalOrganization = false,
                }
            };

            bool userChoice = false;
            string userChoiceString = "";

            do // Main do-while loop, prompts user for action until they choose to quit
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Membership Management System!");

                do // Main menu
                {
                    userChoice = false;
                    Console.WriteLine("---------");
                    Console.WriteLine("Main Menu");
                    Console.WriteLine("---------");
                    Console.WriteLine("A: Administrative Options (Create, Read, Update, Delete).");
                    Console.WriteLine("T: Transaction Processing Options (Purchase, Return, Apply Cash-Back Rewards).");
                    Console.WriteLine("Q: Quit program.");
                    
                    userChoiceString = Console.ReadLine().ToUpper();

                    userChoice = (userChoiceString.Equals("A") || userChoiceString.Equals("T") || userChoiceString.Equals("Q"));
                    if (!userChoice)
                    {
                        Console.WriteLine("Invalid input, please try again.");
                    }
                }
                while (!userChoice);

                if (userChoiceString.Equals("Q"))
                {
                    Console.WriteLine("Quitting the program... Goodbye!");
                    break;
                }

                else if (userChoiceString.Equals("A"))
                {
                    bool exitAdimMenu = false;
                    userChoiceString = "";

                    while (!exitAdimMenu && !userChoiceString.Equals("Q")) // Administrative Options
                    {
                        userChoice = false;

                        Console.WriteLine("---------------------------");
                        Console.WriteLine("Administrative Options Menu");
                        Console.WriteLine("---------------------------");
                        Console.WriteLine("R: Read all memberships in the membership list.");
                        Console.WriteLine("C: Create a new membership.");
                        Console.WriteLine("U: Update an existing membership.");
                        Console.WriteLine("D: Delete an existing membership.");
                        Console.WriteLine("M: Go back to main menu.");
                        Console.WriteLine("Q: Quit program.");

                        userChoiceString = Console.ReadLine().ToUpper();

                        userChoice = 
                            userChoiceString == "R" || 
                            userChoiceString == "C" || 
                            userChoiceString == "U" || 
                            userChoiceString == "D" || 
                            userChoiceString == "M" || 
                            userChoiceString == "Q";

                        if (!userChoice)
                        {
                            Console.WriteLine("Invalid input, please try again.");
                            continue;
                        }

        //R             R - Read all of the memberships in the membership list.

                        if (userChoiceString.ToUpper().Equals("R"))
                        {
                            Console.WriteLine("Membership List:");

                            List<Membership> sortedList = membershipList.OrderBy(m => m.MembershipID).ToList();
                            sortedList.ForEach(membership => Console.WriteLine(membership));
                        }
                    
        //C             C - Create a new membership and add it to the membership list. Be sure you don't duplicate the member ID. It needs to be unqiue.
                        else if (userChoiceString.ToUpper().Equals("C"))
                        {
                        Console.WriteLine("Create a New Membership.");

                        // Prompt user for membership ID and confirm it isn't already in use.
                        int membershipIDInput = -1;
                        bool running = true;
                        while (running)
                        {
                            Console.WriteLine("Enter new membership ID: ");

                            if(!int.TryParse(Console.ReadLine(), out membershipIDInput) || membershipIDInput < 1001)
                            {
                                Console.WriteLine("Invalid membership ID format. Please enter a valid membership ID above 1000.");
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
                        Console.WriteLine("Enter membership type (Regular, Executive, NonProfit, Corporate): ");

                        bool validMembershipType = false;
                        string membershipTypeInput = "";
                        while (!validMembershipType)
                        {
                            membershipTypeInput = Console.ReadLine().ToUpper();
                            if (membershipTypeInput is "REGULAR" or "R" || 
                            membershipTypeInput is "EXECUTIVE" or "E" ||
                            membershipTypeInput is "NONPROFIT" or "N" ||
                             membershipTypeInput is "CORPORATE" or "C")
                            {
                                validMembershipType = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid membership type. Please enter Regular, Executive, NonProfit, or Corporate.");
                            }
                        }

                        Console.WriteLine("Enter contact email: ");

                        bool validContactEmail = false;
                        string contactEmailInput = "";
                        while (!validContactEmail)
                        {
                            contactEmailInput = Console.ReadLine();
                            if (contactEmailInput.Contains("@") && contactEmailInput.Contains("."))
                            {
                                validContactEmail = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid email format. Please enter a valid email address.");
                            }
                        }

                        Console.WriteLine("Enter current monthly purchases: ");
                        decimal currentMonthlyPurchasesInput = 0m;
                        bool validPurchaseAmount = false;
                        while (!validPurchaseAmount)
                        {
                            if (decimal.TryParse(Console.ReadLine(), out currentMonthlyPurchasesInput) && currentMonthlyPurchasesInput >= 0)
                            {
                                validPurchaseAmount = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid decimal number for the monthly purchases.");
                            }
                        }

                        Membership newMembership = null;

                        switch (membershipTypeInput.ToUpper())
                        {
                            case "REGULAR":
                            case "R":
                                newMembership = new RegularMembership(membershipIDInput, contactEmailInput, currentMonthlyPurchasesInput);
                                break;
                            case "EXECUTIVE":
                            case "E":
                                newMembership = new ExecutiveMembership(membershipIDInput, contactEmailInput, currentMonthlyPurchasesInput);
                                break;
                            case "CORPORATE":
                            case "C":
                                newMembership = new CorporateMembership(membershipIDInput, contactEmailInput, currentMonthlyPurchasesInput);
                                break;
                            case "NONPROFIT":
                            case "N":
                                Console.WriteLine("Is this a military or educational organization? (yes/no): ");
                                running = true;
                                bool isMilitaryOrEducational = false;
                                string isMilitaryOrEducationalInput = "";
                                while (running)
                                {
                                    isMilitaryOrEducationalInput = Console.ReadLine();
                                    if (isMilitaryOrEducationalInput.ToUpper() is "YES" or "Y")
                                    {
                                        isMilitaryOrEducational = true;
                                        running = false;
                                    }
                                    else if (isMilitaryOrEducationalInput.ToUpper() is "NO" or "N")
                                    {
                                        isMilitaryOrEducational = false;
                                        running = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                                    }
                                }

                                newMembership = new NonProfitMembership(membershipIDInput, contactEmailInput, currentMonthlyPurchasesInput, isMilitaryOrEducational);
                                break;
                            default:
                                throw new Exception("Unexpected membership type.");
                        }

                        membershipList.Add(newMembership);

                        Console.WriteLine($"New {newMembership.MembershipType} membership {newMembership.MembershipID} created successfully.");

                        } // end of C area
        //U
                        else if (userChoiceString.ToUpper().Equals("U"))
                        {
                            Console.WriteLine("Update an existing membership.");

                            Console.WriteLine("Please enter the membership ID of the membership you wish to update: ");

                            int membershipIDToUpdate = 0;
                            Membership membershipFound = null;
                            while (membershipFound == null)
                            {
                                if (!int.TryParse(Console.ReadLine(), out membershipIDToUpdate) || membershipIDToUpdate < 1001)
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid membership ID above 1000.");
                                    continue;
                                }

                                membershipFound = membershipList.Find(m => m.MembershipID == membershipIDToUpdate);
                                if (membershipFound == null)
                                {
                                    Console.WriteLine("Membership ID not found, please enter a valid membership ID: ");
                                }
                            }

                            Console.WriteLine("Membership ID found. Please enter new contact email: ");

                            bool validContactEmail = false;
                            string contactEmailInput = "";
                            while (!validContactEmail)
                            {
                                contactEmailInput = Console.ReadLine();
                                if (contactEmailInput.Contains("@") && contactEmailInput.Contains("."))
                                {
                                    validContactEmail = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid email format. Please enter a valid email address.");
                                }
                            }

                            Console.WriteLine("Please enter current monthly purchases amount: ");
                            decimal newMonthlyPurchases = 0;
                            bool validMonthlyPurchases = false;
                            while (!validMonthlyPurchases)
                            {
                                if (decimal.TryParse(Console.ReadLine(), out newMonthlyPurchases) && newMonthlyPurchases >= 0)
                                {
                                    validMonthlyPurchases = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid positive number for the monthly purchases.");
                                }
                            }

                            Console.WriteLine("Enter membership type (Regular, Executive, NonProfit, Corporate): ");
                            bool validMembershipType = false;
                            string membershipTypeInput = "";
                            while (!validMembershipType)
                            {
                                membershipTypeInput = Console.ReadLine().ToUpper();
                                if (membershipTypeInput.Equals("REGULAR") || membershipTypeInput.Equals("R") || 
                                membershipTypeInput.Equals("EXECUTIVE") || membershipTypeInput.Equals("E") || 
                                membershipTypeInput.Equals("NONPROFIT") || membershipTypeInput.Equals("N") || 
                                membershipTypeInput.Equals("CORPORATE") || membershipTypeInput.Equals("C"))
                                {
                                    validMembershipType = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid membership type. Please enter Regular, Executive, NonProfit, or Corporate.");
                                }
                            }

                            bool isMilitaryOrEducational = false;

                            if (membershipTypeInput.ToUpper() == "NONPROFIT" || membershipTypeInput.ToUpper() == "N")
                            {
                                bool running = true;
                                while (running)
                                {
                                    Console.WriteLine("Is this a military or educational organization? (yes/no): ");
                                    string militaryOrEducationalInput = Console.ReadLine();
                                    if (militaryOrEducationalInput.ToUpper().Equals("YES") || militaryOrEducationalInput.ToUpper().Equals("Y"))
                                    {
                                        isMilitaryOrEducational = true;
                                        running = false;
                                    }
                                    else if (militaryOrEducationalInput.ToUpper().Equals("NO") || militaryOrEducationalInput.ToUpper().Equals("N"))
                                    {
                                        isMilitaryOrEducational = false;
                                        running = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                                    }
                                }
                            }

                            Membership updatedMembership;

                            switch (membershipTypeInput.ToUpper())
                            {
                                case "REGULAR":
                                case "R":
                                    updatedMembership = new RegularMembership(membershipIDToUpdate, contactEmailInput, newMonthlyPurchases);
                                    break;
                                case "EXECUTIVE":
                                case "E":
                                    updatedMembership = new ExecutiveMembership(membershipIDToUpdate, contactEmailInput, newMonthlyPurchases);
                                    break;
                                case "NONPROFIT":
                                case "N":
                                    updatedMembership = new NonProfitMembership(membershipIDToUpdate, contactEmailInput, newMonthlyPurchases, isMilitaryOrEducational);
                                    break;
                                case "CORPORATE":
                                case "C":
                                    updatedMembership = new CorporateMembership(membershipIDToUpdate, contactEmailInput, newMonthlyPurchases);
                                    break;
                                default:
                                    throw new Exception("Unexpected membership type.");
                            }

                            int index = membershipList.IndexOf(membershipFound);
                            membershipList[index] = updatedMembership;

                            Console.WriteLine($"Membership ID {updatedMembership.MembershipID} updated successfully.");

                        } // end of U area

        //D             D - Delete an existing membership from the membership list.

                        else if (userChoiceString.ToUpper().Equals("D"))
                        {
                            Console.WriteLine("Delete an Existing Membership.");

                            Console.WriteLine("Please enter the membership ID of the membership you wish to delete:");
                            bool running = true;
                            int membershipIDToDelete = 0;
                            Membership membershipFound = null;
                            while (running)
                            {
                                if (!int.TryParse(Console.ReadLine(), out membershipIDToDelete))
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid integer for the membership ID.");
                                    continue;
                                }

                                membershipFound = membershipList.Find(m => m.MembershipID == membershipIDToDelete);
                                if (membershipFound == null)
                                {
                                    Console.WriteLine("Membership ID not found, please enter a valid membership ID.");
                                    continue;
                                }
                                running = false;
                            }
                            membershipList.RemoveAll(m => m.MembershipID == membershipIDToDelete);
                            Console.WriteLine($"Membership ID {membershipIDToDelete} deleted successfully.");
                        } // end of D area

                        else if (userChoiceString.ToUpper().Equals("M"))
                        {
                            Console.WriteLine("Returning to Main Menu.");
                            Console.Clear();
                            exitAdimMenu = true;
                        } // end of M area

                        else if (userChoiceString.ToUpper().Equals("Q"))
                        {
                            Console.WriteLine("Quitting the program... Goodbye!");
                            Environment.Exit(0);
                        } // end of Q area

                    } //end of while loop for Administrative Options

                }// End of Administrative Options area, enter Transaction Processing Options area --------------------------------
                
                else if (userChoiceString.Equals("T"))
                {
                    bool exitTransMenu = false;

                    while (!exitTransMenu && !userChoiceString.Equals("Q")) // Transaction Processing Options
                    {
                        userChoice = false;
                        userChoiceString = "";

                        Console.WriteLine("---------------------------");
                        Console.WriteLine("Transaction Processing Menu");
                        Console.WriteLine("---------------------------");
                        Console.WriteLine("L: Display all memberships and membership information.");
                        Console.WriteLine("P: Perform a purchase transaction.");
                        Console.WriteLine("T: Perform a return transaction.");
                        Console.WriteLine("A: Apply cash-back rewards.");
                        Console.WriteLine("M: Go back to main menu.");
                        Console.WriteLine("Q: Quit program.");

                        userChoiceString = Console.ReadLine().ToUpper();
                        userChoice = 
                            userChoiceString == "L" || 
                            userChoiceString == "P" || 
                            userChoiceString == "T" || 
                            userChoiceString == "A" || 
                            userChoiceString == "M" || 
                            userChoiceString == "Q";

                        if (!userChoice)
                            {
                                Console.WriteLine("Invalid input, please try again.");
                                continue;
                            }

            //L         L - List all of the memberships in the list including all of the information for each account type.
                        if (userChoiceString.ToUpper().Equals("L"))
                        {
                            Console.WriteLine("Membership List:");

                            List<Membership> sortedList = membershipList.OrderBy(m => m.MembershipID).ToList();
                            sortedList.ForEach(membership => Console.WriteLine(membership));
                        }

            //P         Perform a purchase transaction by getting a membership number from the user and a purchase amount and if 
                        // the membership exists add the purchase amount to the monthly purchase total.

                        else if (userChoiceString.ToUpper().Equals("P"))
                        {
                            Console.WriteLine("Starting purchase transaction.");
                            Console.WriteLine("Please enter the membership ID for the purchase transaction:");

                            bool running = true;
                            int membershipIDForPurchase = 0;
                            Membership membershipFound = null;

                            while (running)
                            {
                                if (!int.TryParse(Console.ReadLine(), out membershipIDForPurchase))
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid integer for the membership ID.");
                                    continue;
                                }

                                membershipFound = membershipList.Find(m => m.MembershipID == membershipIDForPurchase);   
                                if (membershipFound == null)
                                {
                                    Console.WriteLine("Membership ID not found. Please enter a valid membership ID:");
                                    continue;
                                }
                                running = false;
                            }

                            Console.WriteLine("Please enter the purchase amount:");
                            bool running2 = true;
                            decimal purchaseAmount = 0M;
                            while (running2)
                            {
                                if (decimal.TryParse(Console.ReadLine(), out purchaseAmount) && purchaseAmount > 0)
                                {
                                    membershipFound.Purchase(purchaseAmount);
                                    Console.WriteLine("Purchase successful. New current monthly purchases amount is: " + membershipFound.CurrentMonthlyPurchases.ToString("C"));
                                    running2 = false;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid number above 0 for the purchase amount.");
                                }
                            }
                        } // end of P area

            //T         Perform a return transaction by getting an membership number from the user and a return amount and if 
            //          the membership exists, perform the return by subtracting the return amount for the monthly purchase total.

                        else if (userChoiceString.ToUpper().Equals("T"))
                        {
                            Console.WriteLine("Starting Return Transaction.");

                            Console.WriteLine("Please enter the membership ID for the return transaction:");
                            bool running = true;
                            int membershipIDForReturn = 0;
                            Membership membershipFound = null;

                            while (running)
                            {
                                if (!int.TryParse(Console.ReadLine(), out membershipIDForReturn))
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid integer for the membership ID.");
                                    continue;
                                }

                                membershipFound = membershipList.Find(m => m.MembershipID == membershipIDForReturn);
                                if (membershipFound == null)
                                {
                                    Console.WriteLine("Membership ID not found. Please enter a valid membership ID:");
                                    continue;
                                }
                                running = false;
                            }
                            
                            Console.WriteLine("Please enter the return amount:");
                            bool running2 = true;
                            decimal returnAmount = 0M;
                            while (running2)
                            {
                                if (decimal.TryParse(Console.ReadLine(), out returnAmount) && returnAmount > 0)
                                {
                                    membershipFound.Return(returnAmount);
                                    Console.WriteLine($"Return successful. New current monthly purchases amount for account {membershipFound.MembershipID} is: {membershipFound.CurrentMonthlyPurchases:C}");
                                    running2 = false;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid number above 0 for the return amount.");
                                }
                            }
                        } // end of T area

        //A            Apply cash-back reward - For the apply cash-back reward, the membership id will be provided.  Cash-back rewards are handled differently 
        //             depending on the membership type as described above.  When a valid membership ID is given, the system will send a request to the 
        //             rewards system for the amount of the reward.  For this application, you can simply print a console output that says 
        //             "Cash-back reward request for membership xxxxxx in the amount of $yyyy has been made." Then zero out the balance. 

                        else if (userChoiceString.ToUpper().Equals("A"))
                        {
                            Console.WriteLine("Apply Cash-Back Rewards.");

                            Console.WriteLine("Please enter the membership ID to apply cash-back rewards:");
                            bool running = true;
                            int membershipIDInput = 0;
                            Membership membershipFound = null;
                            while (running)
                            {
                                if (!int.TryParse(Console.ReadLine(), out membershipIDInput))
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid integer for the membership ID.");
                                    continue;
                                }

                                membershipFound = membershipList.Find(m => m.MembershipID == membershipIDInput);
                                if (membershipFound == null)
                                {
                                    Console.WriteLine("Membership ID not found. Please try again.");
                                    continue;
                                }
                                    running = false;
                            }

                            membershipFound.ApplyCashBackRewards();

                        } // end of A area

                        else if (userChoiceString.ToUpper().Equals("M"))
                        {
                            Console.WriteLine("Returning to Main Menu...");
                            Console.Clear();
                            exitTransMenu = true;
                        } // end of M area

                        else if (userChoiceString.ToUpper().Equals("Q"))
                        {
                            Console.WriteLine("Quitting the program... Goodbye!");
                        }
                    } //end of while loop for Transaction Processing Options
                } // end of Transaction Processing Options area

        //Q     Quit the program.
                else if (userChoiceString.ToUpper().Equals("Q"))
                {
                    Console.WriteLine("Quitting the program... Goodbye!");
                } // end of Q area
        
            } while (!userChoiceString.ToUpper().Equals("Q")); // end of main do-while loop
    } // end of Main
} // end of class