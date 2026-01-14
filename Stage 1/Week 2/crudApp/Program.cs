using System;
using System.ComponentModel.DataAnnotations;

namespace HelloWorld
{
  class Program
  {
    static void Main(string[] args)
    {
        
        // Declare variables
        bool userChoice;
        string userChoiceString;
        const int arraySize=12;
        string[] nameArray = new string[arraySize];
        string fileName = "names.txt";

      // Repeat main loop
      do
      {

        // TODO: Get a valid input
            do
            {
                //  Initialize variables

                userChoice = false;

                //  TODO: Provide the user a menu of options

                Console.WriteLine("What's your pleasure? ");
                Console.WriteLine("L: Load the data file into an array.");
                Console.WriteLine("S: Save the array to the data file.");
                Console.WriteLine("C: Add a name to the array.");
                Console.WriteLine("R: Read a name from the array.");
                Console.WriteLine("U: Update a name in the array.");
                Console.WriteLine("D: Delete a name from the array.");
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

        //  TODO: If the option is L or l then load the text file (names.txt) into the array of strings (nameArray)

            if (userChoiceString=="L" || userChoiceString=="l")
            { try
            {
                Console.WriteLine("In the L/l area");

                int index = 0;  // index for my array
                using (StreamReader sr = File.OpenText(fileName)) //open file and go through line by line
                {
                    string s = "";
				    Console.WriteLine(" Here is the content of the file names.txt : ");
                    while ((s = sr.ReadLine()) != null) //read one line at a time as long as it's not null
                    {
                       Console.WriteLine(s);
                       nameArray[index] = s;
                       index = index + 1;
                    }
                    Console.WriteLine("");
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

            }

        //  TODO: Else if the option is an S or s then store the array of strings into the text file

            else if (userChoiceString=="S" || userChoiceString=="s") //use StreamWriter wr write to new array 1 line at a time
            {
                Console.WriteLine("In the S/s area");


            }

        //  TODO: Else if the option is a C or c then add a name to the array (if there's room there)
            //add a name to an array if there is a spot

            else if (userChoiceString=="C" || userChoiceString=="c")
            {
                Console.WriteLine("In the C/c area");

                // I.   Prompt the user and get a new name

                Console.Write ("Please enter the name to add> ");
                string newName = Console.ReadLine();

                /*   II.  Find an empty spot in the array 
                        A. Initialize indexFound to -1
                        B. For each index from 0 to 12 in the array
                              if the item at that index is a blank then set itemFound to the index 
                */

                int indexFound = -1;
                Console.WriteLine(nameArray.GetLength(0)); //prints length of array
                for (int i = 0; i < nameArray.GetLength(0); i++)
                {
                    if (nameArray[i] == " ")
                    {
                        indexFound = i;
                        Console.WriteLine(indexFound);
                    }
                        
                }

                /*   III. If itemFound does not equal -1
                           Add the name to that spot in the array 
                        else give an error message */

                if (indexFound != -1)
                    nameArray[indexFound] = newName;
                else
                    Console.WriteLine ("Sorry no room for the name.");

            }

        //  TODO: Else if the option is an R or r then print the array

            else if (userChoiceString=="R" || userChoiceString=="r")
            {
                Console.WriteLine("In the R/r area");
                for (int index = 0; index < arraySize; index++)
                {
                    if ((nameArray[index])!=" ")
                        Console.WriteLine("Index " + index + " is " + nameArray[index]);
                    else
                        Console.WriteLine("Index " + index + " is available.");
                }

            }
        //  TODO: Else if the option is a U or u then update a name in the array (if it's there)

            else if (userChoiceString=="U" || userChoiceString=="u")
            {
                Console.WriteLine("In the U/u area");
            }

        //  TODO: Else if the option is a D or d then delete the name in the array (if it's there)
        //use " " to blank out that spot in the array

            else if (userChoiceString=="D" || userChoiceString=="d")
            {
                Console.WriteLine("In the D/d area");
                //put a blank string with a blank character

                //I. Prompt user to get name to delete

                Console.Write ("Please enter the name to delete> ");
                string deleteName = Console.ReadLine();

                /*II. Check for that name in the array
                    A. Initialize indexFound to -1
                    B. For each index from 0 to 12 in the array
                            if the item at that index matches user unput, then set itemFound to an empty string " " 
                */

                int indexFound = -1;
                Console.WriteLine(nameArray.GetLength(0)); //prints length of array

                for (int i = 0; i < nameArray.GetLength(0); i++)
                {

                    if (nameArray[i] == deleteName)
                    {
                        indexFound = i;
                        Console.WriteLine(indexFound);
                        break;
                    }
                }
                /*   III. If itemFound does not equal -1
                        Delete the name to that spot in the array and assign it to an empty string " "
                        else give an error message */

                if (indexFound != -1)
                {
                    nameArray[indexFound] = " ";
                    Console.WriteLine("Name found and deleted");    
                }
                else
                {
                    Console.WriteLine ("Sorry name not found.");
                }
            }

        //  TODO: Else if the option is a Q or q then quit the program

            else 
            {
                Console.WriteLine("Good-bye!");
            }
        } while (!(userChoiceString=="Q") && !(userChoiceString=="q"));
    }  // end main
  }  // end program
}  // end namespace