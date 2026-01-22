using System;

namespace RestaurantInheritance
{
  class Program
  {
    static void Main(string[] args)
    {

        //Declare and instantiate an array of Restaurant objects
        Restaurant[] restaurantArray = new Restaurant[25];

        //Loop through each array element and instantiate a new blank Restaurant object
        for (int i = 0; i < restaurantArray.Length; i++)
        {
            restaurantArray[i] = new Restaurant();
        }

        // load some sample data into the array

        restaurantArray[1].Name = "Runza";
        restaurantArray[1].Cuisine = "Fast Food";
        restaurantArray[1].Rating = 5;
        restaurantArray[5].Name = "Subway";
        restaurantArray[5].Cuisine = "Sandwiches";
        restaurantArray[5].Rating = 4;
        restaurantArray[15].Name = "Taco Johns";
        restaurantArray[15].Cuisine = "Mexican";
        restaurantArray[15].Rating = 3;

        // Print the restaurant data to the console

        for (int i = 0; i < restaurantArray.Length; i++)
        {
            if(restaurantArray[i].Name != " ")
            {
                Console.WriteLine(restaurantArray[i].ToString());
            }
        }

        Console.WriteLine(); //space between tests

        // test the inheritance with default constructor and parameterized constructor

        FastFood ff1 = new FastFood();
        Console.WriteLine(ff1.ToString());
        FastFood ff2 = new FastFood("Runza", "American", 5, true, false);
        Console.WriteLine(ff2.ToString());

        Buffet b1 = new Buffet();
        Console.WriteLine(b1.ToString());
        Buffet b2 = new Buffet("Golden Corral", "American", 4, true, true);
        Console.WriteLine(b2.ToString());

        FineDining fd1 = new FineDining();
        Console.WriteLine(fd1.ToString());
        FineDining fd2 = new FineDining("Brother Sebastian's", "Steakhouse", 5, true, false);
        Console.WriteLine(fd2.ToString());

        Console.WriteLine(); //space between tests

        // test adding FastFood, Buffet, and FineDining objects to the Restaurant array

        restaurantArray[20] = ff2;
        restaurantArray[21] = b2;
        restaurantArray[22] = fd2;
        
        // Print the restaurant data to the console

        for (int i = 0; i < restaurantArray.Length; i++)
        {
            if(restaurantArray[i].Name != " ")
            {
                Console.WriteLine(restaurantArray[i].ToString());
            }
        }

    } // end of Main
  } // end of class Program
} // end of namespace RestaurantInheritance