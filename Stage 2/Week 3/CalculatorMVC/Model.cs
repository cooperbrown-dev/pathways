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

        public double DoOperation (double num1, double num2, string op) {
            double result = double.NaN;

            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    // check for a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
