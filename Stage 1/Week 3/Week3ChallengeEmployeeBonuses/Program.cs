using System;

namespace EmployeeBonuses
{
  class Program
  {
    static void Main(string[] args)
    {

        /*
        Problem description: Your client needs a way to calculate bonuses for their employees.

        Requirements/User stories:

        Each employee will have a last name, first name and employee type (hourly or salary).
        An hourly employee will have an hourly rate. 
        A salary employee will have an annual salary.
        Bonuses are calculated as followed:
        If not hourly or salary, the bonus is 0.
        Hourly, the bonus is two weeks pay (40 hours per week)
        Salary, the bonus is 10%
        You want a menu that will provide you the options of doing the following:
        L - Load the single text file into the program.  The text file stores four lines for each employee including last name, first name, employee type and hourly rate or salary (depending on employee type - H or S)
        S - Store the current employee information in the text file
        C - Add an employee
        R - Print a list of all the employees including their calculated bonus,
        U - Update information for an employee,
        D - Delete an employee
        Q - Quit the program
        We will discuss your class design before you start, but it will include encapsulation, inheritance, and polymorphism.  Classes will include:
        Employee (last name, first name, employee type; constructors, calculate bonus, toString)
        HourlyEmployee (hourly rate; constructors, calculate bonus, toString)
        SalaryEmployee (annual salary; constructors, calculate bonus, toString
        Be sure to follow best programming practices (no code smell!)
        */
        
        // Declare variables
        bool userChoice;
        string userChoiceString;
        const int arraySize=25;
        Employee[] employeeArray = new Employee[arraySize];
        string fileName = "Employees.txt";

        //Instantiate array of empty Employee objects
        for (int i = 0; i < employeeArray.Length; i++)
        {
            employeeArray[i] = new Employee();
        }

        // load some sample data into the array
        employeeArray[1] = new Employee("Doe", "John", "H");
        employeeArray[2] = new Employee("Smith", "Jane", "S");
        employeeArray[3] = new Employee("Brown", "Charlie", "X");
        employeeArray[4] = new HourlyEmployee("Johnson", "Emily", "H", 20.00M);
        employeeArray[5] = new SalaryEmployee("Davis", "Michael", "S", 60000.00M);

        // Print the employee data to the console
        for (int i = 0; i < employeeArray.Length; i++)
        {
            if(employeeArray[i].LastName != " ")
            {
                Console.WriteLine(employeeArray[i].ToString());
            }
        }

        // test the CalculateBonus method for the Employee class
        employeeArray[1].CalculateBonus();
        employeeArray[2].CalculateBonus();
        employeeArray[3].CalculateBonus();
        employeeArray[4].CalculateBonus();
        employeeArray[5].CalculateBonus();

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
                Console.WriteLine("L: Load the data file into an array.");
                Console.WriteLine("S: Save the array to the data file.");
                Console.WriteLine("C: Add a name, cuisine, star rating to the array.");
                Console.WriteLine("R: Read a name, cuisine, star rating from the array.");
                Console.WriteLine("U: Update a name, cuisine, star rating in the array.");
                Console.WriteLine("D: Delete a name, cuisine, star rating from the array.");
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

//L        //  TODO: If the option is L or l then load the text file (names.txt) into the array of strings (nameArray)

            if (userChoiceString=="L" || userChoiceString=="l")
            { try
            {
                Console.WriteLine("In the L/l area");

                int index = 0;  // index for my array
                using (StreamReader sr = File.OpenText(fileName)) //open file and go through line by line
                {

				    Console.WriteLine(" Here is the content of the file Employees.txt : ");

                    while (index < employeeArray.Length) //read lines from the file until we reach the array size
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

                        //assign array index to new Employee, HourlyEmployee or SalaryEmployee object based on employeeType
                        employeeArray[index] = employeeType == "H" ?
                            new HourlyEmployee(lastName, firstName, employeeType, decimal.Parse(stringPay)) :
                            employeeType == "S" ?
                            new SalaryEmployee(lastName, firstName, employeeType, decimal.Parse(stringPay)) :
                            new Employee(lastName, firstName, employeeType);

                        Console.WriteLine(employeeArray[index]); //prints the objects ToString() method

                        index++; //increment index for the next iteration until we reach the array size
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

//S        //  TODO: Else if the option is an S or s then store the array of strings into the text file
            
            else if (userChoiceString=="S" || userChoiceString=="s") //use StreamWriter wr write to new array 1 line at a time
            {
                Console.WriteLine("In the S/s area");

                int index = 0;  // index for my array
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    string writeStatus = "";
                    try
                    {
                        int breakCount = 0;

                        foreach (Employee employee in employeeArray) //going through each element in employeeArray and writing the field to the text file
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
                                        sw.WriteLine(((HourlyEmployee)employee).HourlyRate);
                                    }
                                else if (employee is SalaryEmployee) //boolean check to see if employee is SalaryEmployee
                                    {
                                        sw.WriteLine(((SalaryEmployee)employee).AnnualSalary);
                                    }
                                else
                                    {
                                        sw.WriteLine("0.00"); //for generic Employee objects, write 0.00 for pay rate/salary
                                    }
                                writeStatus = "Successful";
                            }
                            //add blank lines at the end of the file for any empty spots in the array
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

                    /*
                    Could also use 
                    File.WriteAllLines(fileName, nameArray);
                    Console.WriteLine("File saved");
                    */
                } //end using StreamWriter
            } // End of S/s area

//C        //  TODO: Else if the option is a C or c then add a name to the array (if there's room there)
            //add a name to an array if there is a spot

             else if (userChoiceString=="C" || userChoiceString=="c")
            {
                Console.WriteLine("In the C/c area");

                // I.   Prompt the user and get a new employee object to add

                //testing input validation for last name, this only checks if it is blank
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


                Console.Write ("Please enter new employee first name: ");
                string newEmployeeFName = Console.ReadLine();
                Console.Write ("Please enter the new employee type (H or S or O(Hourly/Salaried/Other)): ");
                string newEmployeeType = Console.ReadLine();
                Console.Write ("Please enter the new employee pay rate: ");
                decimal newEmployeePayRate;
                while (!decimal.TryParse(Console.ReadLine(), out newEmployeePayRate))
                {
                    Console.WriteLine("Please enter a valid decimal number for the pay rate.");
                    Console.Write("Please enter the employee pay rate: ");
                }


                //string newEmployeeStringPay = Console.ReadLine();

                /*   II.  Find an empty spot in the array 
                        A. Initialize indexFound to -1
                        B. For each index from 0 to 25 in the array
                              if the item at that index is a blank then set itemFound to the index 
                */

                int indexFound = -1;

                for (int i = 0; i < employeeArray.Length; i++)
                {
                    if (employeeArray[i].LastName == " " && employeeArray[i].FirstName == " ")
                    {
                        indexFound = i;
                        Console.WriteLine(indexFound);
                        break; //exit for loop on the first match
                    }
                } // end for loop

                /*   III. If itemFound does not equal -1
                           Add the name to that spot in the array 
                        else give an error message 
                */

                if (indexFound != -1)
                    {
                    employeeArray[indexFound] = newEmployeeType == "H" ?
                        new HourlyEmployee(newEmployeeLName, newEmployeeFName, newEmployeeType, newEmployeePayRate) :
                        newEmployeeType == "S" ?
                        new SalaryEmployee(newEmployeeLName, newEmployeeFName, newEmployeeType, newEmployeePayRate) :
                        new Employee(newEmployeeLName, newEmployeeFName, newEmployeeType);

                    Console.WriteLine("\nEmployee information added.\n");
                    }
                else
                    {
                    Console.WriteLine ("\nSorry, no room for the employee.\n");
                    }
            } // End of C/c area */

//R     //    TODO: Else if the option is an R or r then print the array

            else if (userChoiceString=="R" || userChoiceString=="r")
            {
                Console.WriteLine("In the R/r area");

                int employeeFound = -1; //use this to check if there are any employees in the array

                for (int index = 0; index < arraySize; index++)
                {

                    //took out the continue to skip to next iteration of loop

                    if ((employeeArray[index].LastName != " " && employeeArray[index].LastName != null))
                        {
                            Console.WriteLine("Index " + index + " is " + employeeArray[index]);
                            employeeArray[index].CalculateBonus();
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

//U        //  TODO: Else if the option is a U or u then update a name in the array (if it's there)

            else if (userChoiceString=="U" || userChoiceString=="u")
            {
                Console.WriteLine("In the U/u area");

            //I. Prompt user to get employee object to update

                Console.Write ("Please enter the employee last name to update: ");
                string employeeLNameToUpdate = Console.ReadLine();
                Console.Write("Please enter the employee first name to update: ");
                string employeeFNameToUpdate = Console.ReadLine();
                Console.Write("Please enter the new employee type (H or S or O (Hourly/Salaried/Other)): ");
                string updateEmployeeTypeTo = Console.ReadLine();
                Console.Write("Please enter the new employee pay rate: ");
                decimal payRateToUpdate;
                while (!decimal.TryParse(Console.ReadLine(), out payRateToUpdate))
                {
                    Console.Write("Please enter a valid decimal number for the pay rate: ");
                }

                /*II. Check for that name in the array
                    A. Initialize indexFound to -1
                    B. For each index from 0 to 12 in the array
                            if the item at that index matches user unput, then set itemFound to an empty string " " 
                */

                    int indexFound = -1;
                    int i = 0;
                    foreach(Employee employee in employeeArray)
                    {
                        if (employee.LastName == employeeLNameToUpdate && employee.FirstName == employeeFNameToUpdate)
                        {
                            indexFound = i;
                            employeeArray[i] = updateEmployeeTypeTo == "H" ?
                                new HourlyEmployee(employeeLNameToUpdate, employeeFNameToUpdate, updateEmployeeTypeTo, payRateToUpdate) :
                                updateEmployeeTypeTo == "S" ?
                                new SalaryEmployee(employeeLNameToUpdate, employeeFNameToUpdate, updateEmployeeTypeTo, payRateToUpdate) :
                                new Employee(employeeLNameToUpdate, employeeFNameToUpdate, updateEmployeeTypeTo);
                            Console.WriteLine("\nEmployee found and updated.\n");
                            break;
                        }
                        i++;
                    }
                    if (indexFound == -1)
                    {
                        Console.WriteLine ("Sorry name not found.");
                    }
            } // End of U/u area

//D         //  TODO: Else if the option is a D or d then delete the name in the array (if it's there)
            //use " " to blank out that spot in the array

            else if (userChoiceString=="D" || userChoiceString=="d")
            {
                Console.WriteLine("In the D/d area");

                //I. Prompt user to get name to delete

                Console.Write ("Please enter the employee last name to delete: ");
                string deleteEmployeeLName = Console.ReadLine();
                Console.Write ("Please enter the employee first name to delete: ");
                string deleteEmployeeFName = Console.ReadLine();


                /*II. Check for that name in the array
                    A. Initialize indexFound to -1
                    B. For each index from 0 to 12 in the array
                            if the item at that index matches user unput, then set itemFound to an empty string " " 
                */

                int indexFound = -1;

                for (int i = 0; i < employeeArray.Length; i++)
                {
                    //check if last and first name entered match the employee at that index
                    if (employeeArray[i].LastName == deleteEmployeeLName && employeeArray[i].FirstName == deleteEmployeeFName)
                    {
                        indexFound = i;
                        Console.WriteLine(indexFound);
                        break;
                    }
                } //end for loop

                /*   III. If itemFound does not equal -1
                        Delete the restaurant to that spot in the array, the cuisine and rating spot after that, and assign them all to an empty string " "
                        else give an error message */

                if (indexFound != -1)
                {
                    employeeArray[indexFound] = new Employee(); //reset that index to a new empty Employee object
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