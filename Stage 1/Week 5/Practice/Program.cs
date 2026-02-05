using System;
using System.Collections.Generic;

namespace Week5Practice;
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            string userInput = "";
            while (userInput != "q")
            {
                Console.WriteLine("Main menu");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Press 1 for Main menu.");
                Console.WriteLine("Press 2 for Options.");
                Console.WriteLine("Press q to Quit.");
                userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        running = true;
                        userInput = "";
                        while (running)
                        {
                            Console.WriteLine("Menu 1");
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine("Press a for this.");
                            Console.WriteLine("Press b for that.");
                            Console.WriteLine("Press m to go back to main menu.");
                            Console.WriteLine("Press q to Quit.");
                            userInput = Console.ReadLine();
                            
                            if (userInput == "a")
                            {
                                Console.WriteLine("Entering this...");
                                Console.WriteLine("Press any key to exit or q to Quit");
                                Console.Read();
                            }
                            else if (userInput == "b")
                            {
                                Console.WriteLine("Entering that...");
                                Console.WriteLine("Press any key to exit or q to Quit");
                                Console.Read();
                            }
                            else if (userInput == "m")
                            {
                                Console.WriteLine("Going back to main menu...");
                                break;
                            }
                            else if (userInput == "q")
                            {
                                running = false;
                            }
                        }

                        break;
                        
                    case "2":
                        running = true;
                        userInput = "";
                        while (running == true)
                        {
                            Console.WriteLine("Menu 2");
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine("Press a for apples.");
                            Console.WriteLine("Press b for bananas.");
                            Console.WriteLine("Press m to go back to main menu.");
                            Console.WriteLine("Press q to Quit.");
                            userInput = Console.ReadLine();

                            switch (userInput)
                            {
                                case "a":
                                    Console.WriteLine("Entering apples...");
                                    Console.WriteLine("Press any key to exit or q to Quit");
                                    Console.Read();
                                    break;
                                
                                case "b":
                                    Console.WriteLine("Entering bananas");
                                    Console.WriteLine("Press any key to exit or q to Quit");
                                    Console.Read();
                                    break;
                            
                               case "m":
                                    Console.WriteLine("Going back to main menu...");
                                    running = false;
                                    break;
                            
                                case "q":
                                    running = false;
                                    break;
                            }
                        }
                        break;
                    
                    case "q":
                        Console.WriteLine("Quitting application...");
                        running = false;
                        break;
                } // end of swtich
            } // end of main menu
                Console.WriteLine("Goodbye!");
        } // end of main
    } // end of class