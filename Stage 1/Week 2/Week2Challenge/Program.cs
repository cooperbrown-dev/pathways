using System;

namespace HelloWorld
{
  class Program
  {
    static void Main(string[] args)
    {

        /*
            Problem description: You want to maintain a list of the restaurants at which you have dined.

            Requirements/User stories:

            You want to keep track of the name, cuisine (ie Italian, Greek, etc.) and your review of restaurants (0-5 stars) and
            you want it to be persistent (stored in a text file).  Provide room for 25 restaurants.
            You want a menu that will provide you the options of doing the following:
            L - Load the user's list of restaurants, cuisine and ratings (from a data file into a data structure),
            S -  Save the user's list of restaurants (from a data structure to a data file)
            Bonus - save them so there are no blank lines in the data file 
            C - Add a restaurant, cuisine and rating,
            Make sure the user provides a restaurant, cuisine and rating
            Make sure to handle the "file full" case
            R - Print a list of all the restaurants and their cuisine and rating,
            Bonus - only print a list of the restaurants - no blank lines in your list
            Make sure to handle the case where there are no restaurants in the list
            U - Update the rating for a restaurant, (Bonus: Update the restaurant name and cuisine)
            D - Delete a restaurant
            Q - Quit the program
        */
        
        // Declare variables
        bool userChoice;
        string userChoiceString;
        const int arraySize=75;
        string[] restaurantArray = new string[arraySize];
        string fileName = "RestaurantReviews.txt";

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
                        restaurantArray[index] = s;
                        index++;
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

            } // End of L/l area

        //  TODO: Else if the option is an S or s then store the array of strings into the text file

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

                        foreach (string name in restaurantArray) //going through each element in the restaurantArray array and writing the variable name to that element.
                            {
                                if (name == " ")
                                    {
                                        breakCount++;
                                        continue; //skip to next iteration of the loop
                                    }
                                sw.WriteLine(name);
                                writeStatus = "Successful";
                            }
                            for(int i = 0; i < breakCount; i++)
                            {
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

        //  TODO: Else if the option is a C or c then add a name to the array (if there's room there)
            //add a name to an array if there is a spot

            else if (userChoiceString=="C" || userChoiceString=="c")
            {
                Console.WriteLine("In the C/c area");

                // I.   Prompt the user and get a new restaurant, cuisine and rating

                Console.Write ("Please enter restaurant name to add: ");
                string newRestaurant = Console.ReadLine();
                Console.Write ("Please enter the cuisine type to add: ");
                string newCuisine = Console.ReadLine();
                Console.Write ("Please enter the star rating (0-5): ");
                string newRating = Console.ReadLine();

                /*   II.  Find an empty spot in the array 
                        A. Initialize indexFound to -1
                        B. For each index from 0 to 75 in the array
                              if the item at that index is a blank then set itemFound to the index 
                */

                int indexFound = -1;

                for (int i = 0; i < restaurantArray.Length; i++)
                {
                    if (restaurantArray[i] == " ")
                    {
                        indexFound = i;
                        Console.WriteLine(indexFound);
                        break; //exit for loop on the first match
                    }
                } // end for loop

                /*   III. If itemFound does not equal -1
                           Add the name to that spot in the array 
                        else give an error message */

                if (indexFound != -1)
                    {
                    restaurantArray[indexFound] = newRestaurant;
                    restaurantArray[indexFound + 1] = newCuisine;
                    restaurantArray[indexFound+ 2] = newRating;
                    Console.WriteLine("\nRestaurant, Cuisine and Rating added.\n");
                    }
                else
                    {
                    Console.WriteLine ("\nSorry, no room for the restaurant/cusine/rating.\n");
                    }
            } // End of C/c area

        //  TODO: Else if the option is an R or r then print the array

            else if (userChoiceString=="R" || userChoiceString=="r")
            {
                Console.WriteLine("In the R/r area");

                int restaurantFound = -1; //use this to check if there are any restaurants in the list

                for (int index = 0; index < arraySize; index++)
                {
                    if ((restaurantArray[index])==" ")
                        {
                            continue; //skip to next iteration of the loop
                        }
                    else if ((restaurantArray[index])!=" ")
                        {
                            Console.WriteLine("Index " + index + " is " + restaurantArray[index]);
                            restaurantFound = index;
                        }
                    else
                        {
                            Console.WriteLine("Index " + index + " is available.");
                        }
                } // End of for loop

                //handle the case where there are no restaurants in the list
                //if restaurantFound still equals -1 after the for loop then print the message below

                if (restaurantFound == -1)
                    {
                    Console.WriteLine("\nList doesn not have any restaurants yet. Please add some first.\n");
                    }

            } // End of R/r area
        //  TODO: Else if the option is a U or u then update a name in the array (if it's there)

            else if (userChoiceString=="U" || userChoiceString=="u")
            {
                Console.WriteLine("In the U/u area");

            //I. Prompt user to get name to update

                Console.Write ("Please enter the restaurant to update: ");
                string restaurantToUpdate = Console.ReadLine();
                Console.Write("Please enter the new restaurant to update to: ");
                string updateRestaurantTo = Console.ReadLine();
                Console.Write("Please enter the cuisine of this new restaurant: ");
                string updateCuisineTo = Console.ReadLine();
                Console.Write("Please enter the star rating of this new restaurant: ");
                string updateRatingTo = Console.ReadLine();

                /*II. Check for that name in the array
                    A. Initialize indexFound to -1
                    B. For each index from 0 to 12 in the array
                            if the item at that index matches user unput, then set itemFound to an empty string " " 
                */

                /*int indexFound = -1;
                Console.WriteLine(nameArray.Length); //prints length of array

                for (int i = 0; i < nameArray.Length; i++)
                {

                    if (nameArray[i] == nameToUpdate)
                    {
                        indexFound = i;
                        Console.WriteLine(indexFound);
                        nameArray[i] = updateNameTo;
                        Console.WriteLine("Name found and updated.");
                        break;
                    }
                }
                    if (indexFound == -1)
                    {
                        Console.WriteLine ("Sorry name not found.");
                    }*/

                    int indexFound = -1;
                    int i = 0;
                    foreach(string name in restaurantArray)
                    {
                        if (name == restaurantToUpdate)
                        {
                            indexFound = i;
                            restaurantArray[i] = updateRestaurantTo;
                            restaurantArray[i + 1] = updateCuisineTo;
                            restaurantArray[i + 2] = updateRatingTo;
                            Console.WriteLine("\nRestaurant found and updated.\n");
                            break;
                        }
                        i++;
                    }
                    if (indexFound == -1)
                    {
                        Console.WriteLine ("Sorry name not found.");
                    }
            } // End of U/u area

            //  TODO: Else if the option is a D or d then delete the name in the array (if it's there)
            //use " " to blank out that spot in the array

            else if (userChoiceString=="D" || userChoiceString=="d")
            {
                Console.WriteLine("In the D/d area");

                //I. Prompt user to get name to delete

                Console.Write ("Please enter the restaurant to delete: ");
                string deleteRestaurant = Console.ReadLine();

                /*II. Check for that name in the array
                    A. Initialize indexFound to -1
                    B. For each index from 0 to 12 in the array
                            if the item at that index matches user unput, then set itemFound to an empty string " " 
                */

                int indexFound = -1;

                for (int i = 0; i < restaurantArray.Length; i++)
                {

                    if (restaurantArray[i] == deleteRestaurant)
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
                    restaurantArray[indexFound] = " ";
                    restaurantArray[indexFound + 1] = " ";
                    restaurantArray[indexFound + 2] = " ";
                    Console.WriteLine("\nRestaurant, Cuisine and Rating found and deleted.\n");
                }
                else
                {
                    Console.WriteLine ("Sorry restaurant not found.");
                }
            } // End of D/d area

        //  TODO: Else if the option is a Q or q then quit the program

        } while (!(userChoiceString=="Q") && !(userChoiceString=="q"));
        
        Console.WriteLine("\nGood-bye!");

    }// End of main
  }// End of class
}// End of namespace