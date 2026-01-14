using System;
using System.Diagnostics;

namespace Feet2Inches
{
    class Program
    {
        static void Main(string[] args)
        {
        /* Program description:  This program will take a string from the user which will be the number of feet, convert it to a double, 
          calculate the number of feet to the number of inches, and output the number of inches.
          
          Algorithm
          I.   Prompt the user for number of feet
          II.  Obtain the number of feet from the user
          III. Convert the number of feet to number of inches
          IV.  Output the number of inches
      */
            double inch;                 // inch will contain the number of inches calcuated
            // I.   Prompt the user for number of feet
            Console.WriteLine("Input value in feet: ");
         
            // II.  Obtain the number of feet from the user
                                // feet will contain the number of feet the user enters (converted from string to double)
            double feet;
            //feet = Convert.ToDouble(Console.ReadLine()); Changed this to a method below.
            feet = GetDouble(Console.ReadLine());
            //III. Convert the number of feet to number of inches
            inch = feet * 12;
            
            //IV.  Output the number of inches
            Console.WriteLine("{0} Feet is {1} Inches", feet, inch);
            Console.ReadKey();
        } // end Main method

        static double GetDouble(string ft)
        {
            return Convert.ToDouble(ft);
        }
    } // end Program class
} // end namespace