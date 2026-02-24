using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMVC
{
    class CalcView
    {
        public CalcView()
        {

        }

        public void DisplayTitle()
        {
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");
        }

        public double GetDoubleFromUser()
        {
            // Ask the user to type the number.
            Console.Write("Type a number, and then press Enter: ");
            // Get the input
            string numInput = Console.ReadLine();
            // See if it is a number
            double cleanNum = 0;
            while (!double.TryParse(numInput, out cleanNum))
            {
                Console.Write("This is not valid input. Please enter a number: ");
                numInput = Console.ReadLine();
            }
            return cleanNum;
        }

        public string GetOperator()
        {
            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");

            string op = Console.ReadLine().ToLower();

            return op;
        }

        public void ShowCalculation(double result)
        {
            Console.WriteLine("Your result: {0:0.##}\n", result);
        }
        
        public void IfNan()
        {
            Console.WriteLine("This operation can not be performed.\n");
        }

        public void CatchExcE(string message)
        {
            Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + message);
        }

        public bool AskUserToContinueOrQuit()
        {
            bool endApp = false;

            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n")
            {
                endApp = true;
            }
            return endApp;
        }

    }
}
