using System;

namespace ListAbstractionEmployeeBonuses
{
  class Program
  {
    static void Main(string[] args)
    {

        /*
        Problem description: Create an application that will use lists and an OOP design and using abstract classes and
        methods to calculate the pay of employees who are either hourly or salaried. 
        */
        
        // Declare variables
        bool userChoice;
        string userChoiceString;
        List<Employee> employeeList = new List<Employee>();
        string fileName = "Employees.txt";

        //Testing area
        // load some sample data into the list 
        /*
        employeeList.Add(new HourlyEmployee("Darnold", "Sam", "H", 20.00M));
        employeeList.Add(new HourlyEmployee("Stafford", "Matt", "S", 50000.00M));
        employeeList.Add(new HourlyEmployee("Murray", "Kyler", "H", 25.00M));
        employeeList.Add(new HourlyEmployee("Brady", "Tom", "S", 100000.00M));
        employeeList.Add(new HourlyEmployee("Love", "Jordan", "H", 35.00M));

        // Print the employee data to the console
        for (int i = 0; i < employeeList.Count; i++)
        {
            if(employeeList[i].LastName != " ")
            {
                Console.WriteLine(employeeList[i].ToString());
            }
        }

        // test the CalculateBonus method for the Employee class
        employeeList[0].CalculateBonus();
        employeeList[1].CalculateBonus();
        employeeList[2].CalculateBonus();
        employeeList[3].CalculateBonus();
        employeeList[4].CalculateBonus();
        */

        // Repeat main loop
        do
        {

        // TODO: Get a valid input
            do
            {
                //  Initialize variables
                userChoice = false;

                //  TODO: Provide the user a menu of options

                Console.WriteLine("What would you like to do?");
                Console.WriteLine("L: Load the data file into a list.");
                Console.WriteLine("S: Save the list to the data file.");
                Console.WriteLine("C: Add a name, cuisine, star rating to the list.");
                Console.WriteLine("R: Read a name, cuisine, star rating from the list.");
                Console.WriteLine("U: Update a name, cuisine, star rating in the list.");
                Console.WriteLine("D: Delete a name, cuisine, star rating from the list.");
                Console.WriteLine("Q: Quit the program.");

                //  TODO: Get a user option (valid means its on the menu)

                userChoiceString = Console.ReadLine();

                userChoice = (userChoiceString=="L" || userChoiceString=="l" ||
                            userChoiceString == "S" || userChoiceString == "s" ||
                            userChoiceString == "C" || userChoiceString == "c" ||
                            userChoiceString == "R" || userChoiceString == "r" ||
                            userChoiceString == "U" || userChoiceString == "u" ||
                            userChoiceString == "D" || userChoiceString == "d" ||
                            userChoiceString == "Q" || userChoiceString == "q");

                if (!userChoice)
                {
                    Console.WriteLine("Please enter a valid option.");
                }

            } while (!userChoice);

//L        //  TODO: If the option is L or l then load the text file (names.txt) into the list of employees

            if (userChoiceString=="L" || userChoiceString=="l")
            { try
            {
                Console.WriteLine("In the L/l area");

                using (StreamReader sr = File.OpenText(fileName)) //open file and go through line by line
                {

				    Console.WriteLine(" Here is the content of the file Employees.txt : ");

                    while (!sr.EndOfStream) //read lines from the file until we reach the end of the file
                    {                        
                        //read 4 lines at a time for each employee and assign to variables
                        string lastName = sr.ReadLine();
                        string firstName = sr.ReadLine();
                        string employeeType = sr.ReadLine();
                        string stringPay = sr.ReadLine();

                            if (lastName == null || firstName == null || employeeType == null)
                            {
                                break; //if any lines are null, exit the while loop
                            }

                        //assign list index to new Employee, HourlyEmployee or SalaryEmployee object based on employeeType
                        Employee employee = employeeType == "H" ?
                            new HourlyEmployee(lastName, firstName, employeeType, decimal.Parse(stringPay)) :
                            new SalaryEmployee(lastName, firstName, employeeType, decimal.Parse(stringPay));

                            employeeList.Add(employee);

                        Console.WriteLine(employee); //prints the objects ToString() method
                    }

                    Console.WriteLine(""); //print a blank line for readability

                } //closes file automatically after using block is done
                
            }
            catch (Exception e)
            {
                
                  Console.WriteLine("Sorry that file isn't found");             
            }
            finally
            {
                    Console.WriteLine ("Let's move on...");
            }

            } // End of L/l area

//S        //  TODO: Else if the option is an S or s then store the list of strings into the text file
            
            else if (userChoiceString=="S" || userChoiceString=="s") //use StreamWriter wr write to new list 1 line at a time
            {
                Console.WriteLine("In the S/s area");

                int index = 0;  // index for my list
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    string writeStatus = "";
                    try
                    {
                        int breakCount = 0;

                        foreach (Employee employee in employeeList) //going through each element in employeeList and writing the field to the text file
                            {
                                if (employee.LastName == " ")
                                    {
                                        breakCount++;
                                        continue; //skip to next iteration of the loop
                                    }
                                sw.WriteLine(employee.LastName);
                                sw.WriteLine(employee.FirstName);
                                sw.WriteLine(employee.EmployeeType);
                                if (employee is HourlyEmployee) //boolean check to see if employee is HourlyEmployee
                                    {
                                        sw.WriteLine(((HourlyEmployee)employee).HourlyRate); //casting HourlyEmployee type to employee to access HourlyRate property
                                    }
                                else if (employee is SalaryEmployee) //boolean check to see if employee is SalaryEmployee
                                    {
                                        sw.WriteLine(((SalaryEmployee)employee).AnnualSalary); //casting SalaryEmployee type to employee to access AnnualSalary property
                                    }
                                else
                                    {
                                        sw.WriteLine("0.00"); //for generic Employee objects, write 0.00 for pay rate/salary
                                    }
                                writeStatus = "Successful";
                            } //end of foreach loop
                            //add blank lines at the end of the file for any empty spots in the list
                            for(int i = 0; i < breakCount; i++)
                            {
                                sw.WriteLine(" ");
                                sw.WriteLine(" ");
                                sw.WriteLine(" ");
                                sw.WriteLine(" ");
                            }
                    }
                    catch (Exception e)
                        {
                            Console.WriteLine("Error writing to file");
                            writeStatus = "Failed";
                        }
                    finally
                        {
                            Console.WriteLine($"{writeStatus} write to file. Returning to main menu.");
                        }
                    Console.WriteLine("");

                } //end using StreamWriter
            } // End of S/s area

//C        //  TODO: Else if the option is a C or c then add a name to the list at the first abailable spot, else at the end.

             else if (userChoiceString=="C" || userChoiceString=="c")
            {
                Console.WriteLine("In the C/c area");

                // I.   Prompt the user and get a new employee object to add

                //Validate last name input isn't blank
                string newEmployeeLName;
                do
                {
                Console.Write ("Please enter new employee last name: ");
                newEmployeeLName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newEmployeeLName))
                    {
                    Console.WriteLine("Last name cannot be blank.");
                    }
                }
                while (string.IsNullOrWhiteSpace(newEmployeeLName));


                //Validate first name input isn't blank
                string newEmployeeFName;
                do
                {
                    Console.Write ("Please enter new employee first name: ");
                    newEmployeeFName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(newEmployeeFName))
                    {
                        Console.WriteLine("First name cannot be blank.");
                    }
                }
                while (string.IsNullOrWhiteSpace(newEmployeeFName));

                //Validate employee type input
                string newEmployeeType;
                do
                {
                    Console.Write ("Please enter the new employee type (H or S or O(Hourly/Salaried/Other)): ");
                    newEmployeeType = Console.ReadLine().ToUpper();
                    if (newEmployeeType != "H" && newEmployeeType != "S" && newEmployeeType != "O")
                    {
                        Console.WriteLine("Error: Please enter a valid employee type: H, S, or O.");
                    }
                }
                while (newEmployeeType != "H" && newEmployeeType != "S" && newEmployeeType != "O");

                //Validate pay rate input
                Console.Write ("Please enter the new employee pay rate: ");
                decimal newEmployeePayRate;
                while (!decimal.TryParse(Console.ReadLine(), out newEmployeePayRate))
                {
                    Console.WriteLine("Please enter a valid decimal number for the pay rate.");
                    Console.Write("Please enter the employee pay rate: ");
                }

                /*   II.  Find an empty spot in the list 
                        A. Initialize indexFound to -1
                        B. For each index in the list
                              if the item at that index is a blank then set itemFound to the index
                */

                int indexFound = -1;

                for (int i = 0; i < employeeList.Count; i++)
                {
                    if (employeeList[i].LastName == " " && employeeList[i].FirstName == " ")
                    {
                        indexFound = i;
                        Console.WriteLine(indexFound);
                        break; //exit for loop on the first match
                    }
                } // end for loop

                /*   III. If itemFound does not equal -1
                           Add the name to that spot in the list
                        else give an error message 
                */

                if (indexFound != -1)
                    {
                    employeeList[indexFound] = newEmployeeType == "H" ?
                        new HourlyEmployee(newEmployeeLName, newEmployeeFName, newEmployeeType, newEmployeePayRate) :
                        new SalaryEmployee(newEmployeeLName, newEmployeeFName, newEmployeeType, newEmployeePayRate);

                    Console.WriteLine("\nEmployee information added.\n");
                    }
                else
                    {
                    employeeList.Add(newEmployeeType == "H" ?
                        new HourlyEmployee(newEmployeeLName, newEmployeeFName, newEmployeeType, newEmployeePayRate) :
                        new SalaryEmployee(newEmployeeLName, newEmployeeFName, newEmployeeType, newEmployeePayRate));

                    }
            } // End of C/c area */

//R     //    TODO: Else if the option is an R or r then print the list of names

            else if (userChoiceString=="R" || userChoiceString=="r")
            {
                Console.WriteLine("In the R/r area");

                int employeeFound = -1; //use this to check if there are any employees in the list

                for (int index = 0; index < employeeList.Count; index++)
                {
                    if ((employeeList[index].LastName != " " && employeeList[index].LastName != null))
                        {
                            Console.WriteLine("Index " + index + " is " + employeeList[index]); //calls the objects ToString() method
                            employeeList[index].CalculateBonus(); //call WeeklyPay() method, which uses abstraction and polymorphism
                            employeeList[index].WeeklyPay(); //call WeeklyPay() method, which uses abstraction and polymorphism
                            employeeFound = index;
                        }
                    else
                        {
                            Console.WriteLine("Index " + index + " is available.");
                        }
                } // End of for loop

                //handle the case where there are no restaurants in the list
                //if employeeFound still equals -1 after the for loop then print the message below

                if (employeeFound == -1)
                    {
                    Console.WriteLine("\nList doesn not have any employees yet. Please add some first.\n");
                    }

            } // End of R/r area

//U        //  TODO: Else if the option is a U or u then update a name in the list (if it's there)

            else if (userChoiceString=="U" || userChoiceString=="u")
            {
                Console.WriteLine("In the U/u area");

            //I. Prompt user to get employee object to update

                //Find and validate last name input

                string employeeLNameToUpdate = " ";
                string employeeFNameToUpdate = " ";

                bool employeeLNameFound = false;

                while (!employeeLNameFound)
                {
                Console.Write ("Please enter the employee last name to update: ");
                employeeLNameToUpdate = Console.ReadLine();

                foreach (Employee employee in employeeList)
                {
                    if (employee.LastName == employeeLNameToUpdate)
                    {
                        employeeLNameFound = true;
                        Console.WriteLine("Last name found.");
                        break;
                    }
                } //end of foreach loop
                    if (!employeeLNameFound)
                    {
                        Console.WriteLine("Sorry name not found. Try again.");
                    }
                } //end while loop

                //Find and validate first name input
                bool employeeFNameFound = false;

                while (!employeeFNameFound)
                {
                Console.Write ("Please enter the employee first name to update: ");
                employeeFNameToUpdate = Console.ReadLine();

                foreach (Employee employee in employeeList)
                {
                    if (employee.FirstName == employeeFNameToUpdate)
                    {
                        employeeFNameFound = true;
                        Console.WriteLine("First name found.");
                        break;
                    }
                } // end of foreach loop
                    if (!employeeFNameFound)
                    {
                        Console.WriteLine("Sorry name not found. Try again.");
                    }
                } //end while loop

                Console.Write("Please enter the new employee type (H or S or O (Hourly/Salaried/Other)): ");
                string updateEmployeeTypeTo = Console.ReadLine();
                Console.Write("Please enter the new employee pay rate: ");
                decimal payRateToUpdate;
                while (!decimal.TryParse(Console.ReadLine(), out payRateToUpdate))
                {
                    Console.Write("Please enter a valid decimal number for the pay rate: ");
                }

                /*II. Check for that name in the list
                    A. Initialize indexFound to -1
                    B. For each index from 0 to 12 in the list
                            if the item at that index matches user unput, then set itemFound to an empty string " " 
                */

                    int indexFound = -1;
                    int i = 0;
                    foreach(Employee employee in employeeList)
                    {
                        if (employee.LastName == employeeLNameToUpdate && employee.FirstName == employeeFNameToUpdate)
                        {
                            indexFound = i;
                            employeeList[i] = updateEmployeeTypeTo == "H" ?
                                new HourlyEmployee(employeeLNameToUpdate, employeeFNameToUpdate, updateEmployeeTypeTo, payRateToUpdate) :
                                new SalaryEmployee(employeeLNameToUpdate, employeeFNameToUpdate, updateEmployeeTypeTo, payRateToUpdate);
                            Console.WriteLine("\nEmployee found and updated.\n");
                            break;
                        }
                        i++;
                    } //end foreach loop
                    if (indexFound == -1)
                    {
                        Console.WriteLine ("Sorry name not found.");
                    }
            } // End of U/u area

//D         //  TODO: Else if the option is a D or d then delete the name in the list (if it's there)
            //use " " to blank out that spot in the list

            else if (userChoiceString=="D" || userChoiceString=="d")
            {
                Console.WriteLine("In the D/d area");

                //I. Prompt user to get name to delete

                //Declare variables
                string deleteEmployeeLName = " ";
                string deleteEmployeeFName = " ";

                //Find and validate last name input
                bool employeeLNameFound = false;

                while (!employeeLNameFound)
                {
                Console.Write ("Please enter the employee last name to delete: ");
                deleteEmployeeLName = Console.ReadLine();

                foreach (Employee employee in employeeList)
                {
                    if (employee.LastName == deleteEmployeeLName)
                    {
                        employeeLNameFound = true;
                        Console.WriteLine("Last name found.");
                        break;
                    }
                } //end of foreach loop
                    if (!employeeLNameFound)
                    {
                        Console.WriteLine("Sorry name not found. Try again.");
                    }
                } //end while loop

                //Find and validate first name input
                bool employeeFNameFound = false;

                while (!employeeFNameFound)
                {
                Console.Write ("Please enter the employee first name to delete: ");
                deleteEmployeeFName = Console.ReadLine();

                foreach (Employee employee in employeeList)
                {
                    if (employee.FirstName == deleteEmployeeFName)
                    {
                        employeeFNameFound = true;
                        Console.WriteLine("First name found.");
                        break;
                    }
                } // end of foreach loop
                    if (!employeeFNameFound)
                    {
                        Console.WriteLine("Sorry name not found. Try again.");
                    }
                } //end while loop

                /*II. Check for that name in the list
                    A. Initialize indexFound to -1
                    B. For each index from 0 to 12 in the list
                            if the item at that index matches user unput, then set itemFound to an empty string " " 
                */

                int indexFound = -1;

                for (int i = 0; i < employeeList.Count; i++)
                {
                    //check if last and first name entered match the employee at that index
                    if (employeeList[i].LastName == deleteEmployeeLName && employeeList[i].FirstName == deleteEmployeeFName)
                    {
                        indexFound = i;
                        Console.WriteLine(indexFound);
                        break;
                    }
                } //end for loop

                /*   III. If itemFound does not equal -1
                        Delete the restaurant to that spot in the list, the cuisine and rating spot after that, and assign them all to an empty string " "
                        else give an error message */

                if (indexFound != -1)
                {
                    employeeList[indexFound] = new HourlyEmployee(); //reset that index to a new empty Employee object
                    Console.WriteLine("\nEmployee found and deleted.\n");
                }
                else
                {
                    Console.WriteLine ("Sorry employee not found.");
                }
            } // End of D/d area

        //  TODO: Else if the option is a Q or q then quit the program

        } while (!(userChoiceString=="Q") && !(userChoiceString=="q"));
        
        Console.WriteLine("\nGood-bye!");

    }// End of main
  }// End of class
}// End of namespace