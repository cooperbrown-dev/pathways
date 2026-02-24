using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMVC
{
    class CalcModel
    {
        public double Number1 { get; set; }
        public double Number2 { get; set; }
        public string Operator { get; set; }

        //defualt constructor
        public CalcModel()
        {
            Number1 = 0;
            Number2 = 0;
            Operator = "";
        }

        //overloaded constructor
        public CalcModel(double num1, double num2, string op)
        {
            Number1 = num1;
            Number2 = num2;
            Operator = op;
        }

        public double DoOperation () {
            double result = double.NaN;

            switch (Operator)
            {
                case "a":
                    result = Number1 + Number2;
                    break;
                case "s":
                    result = Number1 - Number2;
                    break;
                case "m":
                    result = Number1 * Number2;
                    break;
                case "d":
                    // check for a non-zero divisor.
                    if (Number2 == 0)
                    {
                        throw new DivideByZeroException("Cannot divide by zero.");
                    }
                    break;
                default:
                    throw new Exception("Invalid operator selection.");
            }
            return result;
        }
    }
}
